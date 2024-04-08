using FaceCounter;
using FaceCounter.Controllers;
using FaceCounter.Models;
using FaceCounter.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Reflection.Metadata.Ecma335;

namespace FaceCounterTest
{
    [TestClass]
    public class HistoryTest
    {
        private Mock<IRepository<Recognize>> historyMock;
        private Mock<HistoryContext> historyContextMock;
        private HistoryController controller;

        public HistoryTest() 
        {
            historyContextMock = new Mock<HistoryContext>();
            historyMock = new Mock<IRepository<Recognize>>();

            controller = new HistoryController(historyMock.Object);
        }

        [TestMethod]
        public void GetOneTestSuccessfully()
        {
            //data          
            historyMock.Setup(x => x.GetOne(It.IsAny<int>())).Returns(new Recognize { Id = 1, Image = [], Result = 1 });

            //action
            var result = controller.GetOne(1);

            //assert
            Assert.IsInstanceOfType<JsonResult>(result);
        }

        [TestMethod]
        public void GetAllTest()
        {
            //data          
            historyMock.Setup(x => x.GetAll()).Returns(
                new Recognize[] {
                    new Recognize() { Id = 1, Image = [], Result = 1 }, 
                    new Recognize() { Id = 2, Image = [], Result = 0 } 
                });

            //action
            var result = controller.GetAll();

            //assert
            Assert.IsInstanceOfType<JsonResult>(result);
        }

        [TestMethod]
        public void DeleteTestOk()
        {
            //data          
            historyMock.Setup(x => x.Delete(1)).Returns(true);

            //action
            var result = controller.Delete(1);

            //assert
            Assert.IsInstanceOfType<OkResult>(result);
        }

        [TestMethod]
        public void DeleteTestNotFound()
        {
            //data          
            historyMock.Setup(x => x.Delete(1000)).Returns(false);

            //action
            var result = controller.Delete(1000);

            //assert
            Assert.IsInstanceOfType<NotFoundResult>(result);
        }
    }
}