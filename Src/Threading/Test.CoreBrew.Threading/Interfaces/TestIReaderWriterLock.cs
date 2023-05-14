using CoreBrew.Threading;
using CoreBrew.Threading.Interfaces;

namespace Test.CoreBrew.Threading.Interfaces;

public class TestIReaderWriterLock
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestReadLockIsRespected()
    {
        var readerWriterLocks = new List<IReaderWriterLock>()
        {
            new BrewedUpReaderWriterLock(),
            new BrewedUpReaderWriterLockSlim()
        };

        foreach (var readerWriterLock in readerWriterLocks)
        {
            var autoResetEvent = new AutoResetEvent(false);
            readerWriterLock.EnterReadLock(-1);

            Task.Run(() =>
            {
                Assert.That(() => readerWriterLock.EnterWriteLock(100), Throws.Exception);
                autoResetEvent.Set();
            });

            autoResetEvent.WaitOne();
            readerWriterLock.ExitReadLock();
            
            Assert.That(() => readerWriterLock.EnterWriteLock(100), Throws.Nothing);
        }
    }

    [Test]
    public void TestWriteLockIsRespected()
    {
        var readerWriterLocks = new List<IReaderWriterLock>()
        {
            new BrewedUpReaderWriterLock(),
            new BrewedUpReaderWriterLockSlim()
        };

        foreach (var readerWriterLock in readerWriterLocks)
        {
            var autoResetEvent = new AutoResetEvent(false);

            readerWriterLock.EnterWriteLock(-1);
            Task.Run(() =>
            {
                Assert.That(() => readerWriterLock.EnterReadLock(100), Throws.Exception);
                autoResetEvent.Set();
            });

            autoResetEvent.WaitOne();
            readerWriterLock.ExitWriteLock();

            Assert.That(() => readerWriterLock.EnterReadLock(100), Throws.Nothing);
        }
    }
}