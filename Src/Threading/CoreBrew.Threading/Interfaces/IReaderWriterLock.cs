namespace CoreBrew.Threading.Interfaces;

public interface IReaderWriterLock
{
    public void EnterReadLock(int milliSeconds);
    public void ExitReadLock();
    public void EnterWriteLock(int milliSeconds);
    public void ExitWriteLock();
}