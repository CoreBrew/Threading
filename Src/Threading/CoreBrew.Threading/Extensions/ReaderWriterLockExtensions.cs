namespace CoreBrew.Threading.Extensions;

public static class ReaderWriterLockExtensions
{
    public static void EnterReadLock(this ReaderWriterLock readerWriterLock, int milliseconds)
    {
        readerWriterLock.AcquireReaderLock(milliseconds);
    }

    public static void ExitReadLock(this ReaderWriterLock readerWriterLock)
    {
        readerWriterLock.ReleaseReaderLock();
    }

    public static void EnterWriteLock(this ReaderWriterLock readerWriterLock, int milliseconds)
    {
        readerWriterLock.AcquireWriterLock(milliseconds);
    }

    public static void ExitWriteLock(this ReaderWriterLock readerWriterLock)
    {
        readerWriterLock.ReleaseWriterLock();
    }
}