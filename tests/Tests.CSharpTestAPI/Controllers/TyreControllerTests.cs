using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpTest.ApplicationServices;
using CSharpTest.Model;
using CSharpTestAPI.Controllers;
using Moq;
using NUnit.Framework;

namespace Tests.CSharpTestAPI.Controllers
{
    [TestFixture]
    public class TyreControllerTests
    {
        [Test]
        public void GetAllTtyres_ShouldReturnNotNullResult()
        {
            //Arrange
            var mockTyreService = new Mock<ITyreService>();
            IEnumerable<Tyre> tyres = new List<Tyre>();
            mockTyreService.Setup(x => x.GetAllTyres()).ReturnsAsync(tyres);
            var controller = new TyreController(mockTyreService.Object);

            //Act
            var result = controller.GetAllTyres().Result;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task GivenTyreController_WhenGetAllTyresIsCalled_ThenReturnListOfTyres()
        {
            //Arrange
            var expected = new List<Tyre>();
            var mockTyreService = new Mock<ITyreService>();
            mockTyreService.Setup(x => x.GetAllTyres()).ReturnsAsync(expected);
            var sut = new TyreController(mockTyreService.Object);

            //Act
            var result = await sut.GetAllTyres();

            //Assert
            Assert.AreEqual(expected, result);
        }
    }
}