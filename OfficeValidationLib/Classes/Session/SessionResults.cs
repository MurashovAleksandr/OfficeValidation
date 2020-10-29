using System.Collections.Generic;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes.Session
{
    public class SessionResults : ISessionResults
    {
        /// <summary>
        /// Результат
        /// </summary>
        public IEnumerable<ICheckResult> Results { get; protected set; }

        /// <summary>
        /// Сессия
        /// </summary>
        public ISession Session { get; protected set; }

        /// <summary>
        /// Создание нового экземпляра результата сессии
        /// </summary>
        /// <param name="results">Результат</param>
        /// <param name="session">Сессия</param>
        public SessionResults(IEnumerable<ICheckResult> results, ISession session)
        {
            Results = results;
            Session = session;
        }
    }
}
