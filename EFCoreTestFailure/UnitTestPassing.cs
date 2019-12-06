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
    public class UnitTestPassing
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
            Status inprogress = new Status { DisplayName = "In Progress", Name = "inprogress" };
            _tasks = new Task[]
            {
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Complete", Name = "complete" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "New", Name = "new" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Cancelled", Name = "cancelled" }
                },
                new Task()
                {
                    EndDate = null,
                    Status = inprogress
                },
                new Task()
                {
                    EndDate = null,
                    Status = inprogress
                },
                new Task()
                {
                    EndDate = null,
                    Status = inprogress
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

        // Creating the context per test rather than during initialize
        // These tests still fail

        [TestMethod]
        public void TestMethod5()
        {
            var options = new DbContextOptionsBuilder<TaskManagerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            TaskManagerContext context = new TaskManagerContext(options);

            Task[] tasks = new Task[]
            {
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Complete", Name = "complete" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "New", Name = "new" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Cancelled", Name = "cancelled" }
                },
                new Task()
                {
                    EndDate = null,
                    Status = new Status { DisplayName = "In Progress", Name = "inprogress" }
                }
            };
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
            Assert.AreEqual(4, context.Tasks.Count());
        }

        [TestMethod]
        public void TestMethod6()
        {
            var options = new DbContextOptionsBuilder<TaskManagerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            TaskManagerContext context = new TaskManagerContext(options);

            Task[] tasks = new Task[]
            {
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Complete", Name = "complete" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "New", Name = "new" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Cancelled", Name = "cancelled" }
                }
            };
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
            Assert.AreEqual(3, context.Tasks.Count());
        }

        [TestMethod]
        public void TestMethod7()
        {
            var options = new DbContextOptionsBuilder<TaskManagerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            TaskManagerContext context = new TaskManagerContext(options);
            Status inprogress = new Status { DisplayName = "In Progress", Name = "inprogress" };
            Task[] tasks = new Task[]
            {
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Complete", Name = "complete" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "New", Name = "new" }
                },
                new Task()
                {
                    EndDate = DateTime.Now,
                    Status = new Status { DisplayName = "Cancelled", Name = "cancelled" }
                },
                new Task()
                {
                    EndDate = null,
                    Status = inprogress
                },
                new Task()
                {
                    EndDate = null,
                    Status = inprogress
                },
                new Task()
                {
                    EndDate = null,
                    Status = inprogress
                }
            };
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
            Assert.AreEqual(6, context.Tasks.Count());
        }
    }
}
