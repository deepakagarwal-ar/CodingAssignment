using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanupApp.Tests
{
    internal class CleanupWorkerTests
    {

        // Add tests for CleanupWorker. The test should verify that the repository is called
        // when the worker executes.

        public CleanupWorkerTests()
        {
        }

        [Test]
        public void TestRepositoryInvoked()
        {
            Mock<IRepository> mockRepository = new Mock<IRepository>();

            mockRepository.Setup(x => x.Cleanup(It.IsAny<string>()));

            CleanupWorker worker = new CleanupWorker(mockRepository.Object);

            worker.Execute("TestIdentifiers");

            mockRepository.Verify(x => x.Cleanup(It.IsAny<string>()), Times.Once);
        }
    }
}
