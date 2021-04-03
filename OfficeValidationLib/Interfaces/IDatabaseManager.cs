using OfficeValidationLib.Classes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OfficeValidationLib.Database.Entities;
using SQLite.Net;

namespace OfficeValidationLib.Interfaces
{
    /// <summary>
    /// Для загрузки проверок, настройки проверок и сохранения результатов
    /// </summary>
    public interface IDatabaseManager: IDisposable
    {
        /// <summary>
        /// Подключение к БД
        /// </summary>
        SQLiteConnection Db { get; }
        /// <summary>
        /// Получает из БД все настройки проверок
        /// </summary>
        /// <returns>Настройки проверок</returns>
        IEnumerable<Instance> GetInstances();
        /// <summary>
        /// Получает из БД результаты всех проверок
        /// </summary>
        /// <returns>Результаты проверок</returns>
        IEnumerable<CheckResultEntity> GetResults();
        /// <summary>
        /// Получает из БД типы документов, которые поддерживаются
        /// </summary>
        /// <returns>Список типов документов</returns>
        IEnumerable<string> GetDocumentFactoryNames();
        /// <summary>
        /// Добавляет результаты проверок в БД
        /// </summary>
        /// <param name="result">Результат проверки</param>
        void AddResults(IEnumerable<ICheckResult> result);
    }
}
