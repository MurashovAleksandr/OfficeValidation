namespace OfficeValidationLib.Interfaces
{
    public interface ISessionLog
    {
        ISession Session { get; }
        ILogMessage[] Messages { get; }
        void AddMessage(ILogMessage message);
    }
}
