using System;

namespace OfficeValidationLib.Classes.Session
{
    public class SessionHistory : Session
    {
        public new DateTime CreationDateTime { get; }

        public SessionHistory(DateTime creationDateTime)
        {
            this.CreationDateTime = creationDateTime;
        }
    }
}
