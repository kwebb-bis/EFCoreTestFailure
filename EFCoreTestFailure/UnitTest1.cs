using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace EFCoreTestFailure
{
    [TestClass, TestCategory("Unit")]
    [ExcludeFromCodeCoverage]
    public class UnitTest1
    {
        TaskManagerContext _context;
        Task[] _tasks;

        [TestInitialize]
        public void SetUpTestBed()
        {
            var options = new DbContextOptionsBuilder<TaskManagerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new TaskManagerContext(options);
            _context.Statuses.AddRange(Status.GetAll());
            _context.SaveChanges();

            _tasks = new Task[]
            {
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = Status.Complete
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = Status.New
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = Status.Cancelled
                },
                new Task()
                {
                    EndDate = null,
                    Status = Status.InProgress
                },
                new Task()
                {
                    EndDate = null,
                    Status = Status.InProgress
                },
                new Task()
                {
                    EndDate = null,
                    Status = Status.InProgress
                },
            };
        }

        [TestCleanup]
        public void TearDownTestBed()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _context.Tasks.AddRange(_tasks.Take(3));
            _context.SaveChanges();
            Assert.AreEqual(3, _context.Tasks.Count());
        }

        [TestMethod]
        public void TestMethod2()
        {
            _context.Tasks.AddRange(_tasks);
            _context.SaveChanges();
            Assert.AreEqual(6, _context.Tasks.Count());
        }

        [TestMethod]
        public void TestMethod3()
        {
            _context.Tasks.AddRange(_tasks.Take(4));
            _context.SaveChanges();
            Assert.AreEqual(4, _context.Tasks.Count());
        }

        [TestMethod]
        public void TestMethod4()
        {
            _context.Tasks.AddRange(_tasks.Take(1));
            _context.SaveChanges();
            Assert.AreEqual(1, _context.Tasks.Count());
        }
    }
}
