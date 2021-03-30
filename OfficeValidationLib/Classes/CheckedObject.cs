using System;
using OfficeValidationLib.Interfaces;

namespace OfficeValidationLib.Classes
{
    public class CheckedObject : ICheckedObject
    {
        public ICheckResult CheckResult { get; }
        public object Object { get; }
        public CheckedObject(object obj, ICheckResult checkResult)
        {
            Object = obj;
            CheckResult = checkResult;
        }

        public override string ToString() => $"{Object}";
    }
}
