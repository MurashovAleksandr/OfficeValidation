using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
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
                        // check assembly
                        var assembly = Assembly.LoadFrom(instance.Assembly);
                        type = assembly.GetType(instance.ClassName);
                    }
                    if (Activator.CreateInstance(type) is ICheck check)
                    {
                        session.Log.AddMessage(new LogMessage(LogMessageSeverity.Information, 
                            $"Загружена проверка \"{instance.Name}\" (сборка {type.FullName})"));

                        check.Name = instance.Name;

                        //add visualization
                        check.DisplayName = instance.DisplayName;
                        check.Description = instance.Description;

                        //add parameters
                        check.InitializeParameters(instance.Parameters);

                        //initialize documents
                        check.InitializeDocuments(session.Documents);

                        //add tags
                        foreach (var tag in instance.Tags)
                        {
                            if (!check.Tags.Contains(tag))
                            {
                                check.Tags.Add(tag);
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
    }
}
