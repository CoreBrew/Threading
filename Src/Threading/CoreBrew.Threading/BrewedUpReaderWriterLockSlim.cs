using CoreBrew.Threading.Interfaces;

namespace CoreBrew.Threading;

public class BrewedUpReaderWriterLockSlim : IReaderWriterLock
{
    private readonly ReaderWriterLockSlim _lock = new ();
    
    public void EnterReadLock(int milliSeconds)
    {
        var entered = _lock.TryEnterReadLock(milliSeconds);
        if (!entered)
        {
            throw new ApplicationException("Timed out before getting the lock");
        }
    }

    public void ExitReadLock()
    {
        _lock.ExitReadLock();
    }

    public void EnterWriteLock(int milliSeconds)
    {
        var entered = _lock.TryEnterWriteLock(milliSeconds);
        if (!entered)
        {
            throw new ApplicationException("Timed out before getting the lock");
        }
    }

    public void ExitWriteLock()
    {
        _lock.ExitWriteLock();
    }
}