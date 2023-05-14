using CoreBrew.Threading.Interfaces;

namespace CoreBrew.Threading;

public class BrewedUpReaderWriterLock : IReaderWriterLock
{
    private readonly ReaderWriterLock _lock = new ();
    
    public void EnterReadLock(int milliSeconds)
    {
        _lock.AcquireReaderLock(milliSeconds);
    }

    public void ExitReadLock()
    {
        _lock.ReleaseReaderLock();
    }

    public void EnterWriteLock(int milliSeconds)
    {
        _lock.AcquireWriterLock(milliSeconds);
    }

    public void ExitWriteLock()
    {
        _lock.ReleaseWriterLock();
    }
}