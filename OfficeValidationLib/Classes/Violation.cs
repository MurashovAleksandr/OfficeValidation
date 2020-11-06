using System.Collections.Generic;
using OfficeValidationLib.Enums;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class Violation : IViolation
    {
        public Violation(
            ICheckResult checkResult,
            IDocument document,
            object obj,
            ViolationLevel level = ViolationLevel.Error,
            Dictionary<string, object> data = null)
        {
            CheckResult = checkResult;
            Document = document;
            Object = obj;
            Level = level;

            Data.Add("Документ", Document);
            Data.Add("Объект", Object);

            if (data != null)
            {
                foreach (var dataItem in data)
                {
                    Data.Add(dataItem);
                }
            }
        }
        public ICheckResult CheckResult { get; }
        public IDocument Document { get; }
        public object Object { get; }
        public ViolationLevel Level { get; }
        public IDictionary<string, object> Data { get; } = new Dictionary<string, object>();
    }
}
