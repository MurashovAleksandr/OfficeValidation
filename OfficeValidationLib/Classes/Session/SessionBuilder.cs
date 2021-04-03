using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class SessionBuilder
    {
        public Session Build(IEnumerable<Instance> instances, IEnumerable<IDocument> documents)
        {
            var session = new Session();
            session.Log = new MultiLog(session);
            session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, $"Начало создания сессии"));

            foreach (var doc in documents)
            {
                session.Documents.Add(doc);
                session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, $"Добавлен документ {doc.Name}"));
            }

            foreach (var instance in instances)
            {
                if (instances.Count(x => string.Equals(x.Name, instance.Name)) > 1)
                {
                    session.Log.AddMessage(new ErrorLogMessage("Ошибка построения списка проверок. Проверки должны иметь уникальные имена", instance));
                }
            }

            foreach (var instance in instances)
            {
                try
                {
                    var type = Type.GetType(instance.ClassName, false);
                    if (type == null)
                    {
                        var assembly = Assembly.LoadFrom(instance.Assembly);
                        type = assembly.GetType(instance.ClassName);
                    }
                    if (Activator.CreateInstance(type) is ICheck check)
                    {
                        session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, 
                            $"Загружена проверка \"{instance.Name}\" (сборка {type.FullName})"));

                        check.Name = instance.Name;

                        //визуализация
                        check.DisplayName = instance.DisplayName;
                        check.Description = instance.Description;

                        //параметры
                        check.InitializeParameters(instance.Parameters);

                        //инициализация документов
                        check.InitializeDocuments(session.Documents);

                        //aдобавление меток
                        if (instance.Tags != null)
                        {
                            foreach (var tag in instance.Tags)
                            {
                                if (!check.Tags.Contains(tag))
                                {
                                    check.Tags.Add(tag);
                                }
                            }
                        }

                        session.Checks.Add(check);
                    }
                    else
                    {
                        session.Log.AddMessage(new ErrorLogMessage($"Класс {type} не удовлетворяет правила контракта {typeof(ICheck)}"));
                    }
                }
                catch (Exception e)
                {
                    session.Log.AddMessage(new ErrorLogMessage(new Exception($"Ошибка при создании проверки {instance.ClassName}", e)));
                }
            }
            session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, "Создание сессии завершено"));
            return session;
        }

        public SessionHistory Build(IEnumerable<CheckResultHistory> checkResultHistories, DateTime startDateTime)
        {
            var session = new SessionHistory(startDateTime);
            session.Log = new MultiLog(session);
            session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, $"Начало создания сессии"));

            foreach (var doc in checkResultHistories.SelectMany(x=>x.Violations.Select(y=>y.Document)))
            {
                session.Documents.Add(doc);
                session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, $"Добавлен документ {doc.Name}"));
            }

            foreach (var check in checkResultHistories.Select(x=>x.Check))
            {
                session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information,
                    $"Загружена проверка \"{check.Name}\""));
            }

            session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, "Создание сессии завершено"));

            return session;
        }
    }
}
