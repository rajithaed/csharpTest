using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpTest.ApplicationServices;
using CSharpTest.Data;
using CSharpTest.Model;
using Moq;
using NUnit.Framework;

namespace Tests.CSharpTest.ApplicationServices
{
    [TestFixture]
    public class TyreServiceTests
    {
        private readonly Mock<ITyreRepository> _mockTyreRepository;
        private ITyreService _tyreService;

        public TyreServiceTests()
        {
            _mockTyreRepository = new Mock<ITyreRepository>();
        }

        [Test]
        public async Task GivenTyreService_WhenGetAllTyresIsCalled_ThenRepositoryIsCalled()
        {
            //Arrange
            var tyres = GetSampleTyres();
            _mockTyreRepository.Setup(x => x.GetAllTyres()).ReturnsAsync(tyres);
            _tyreService = new TyreService(_mockTyreRepository.Object);

            //Act
            await _tyreService.GetAllTyres();

            //Assert
            _mockTyreRepository.Verify(x => x.GetAllTyres(), Times.AtLeastOnce);
        }

        [Test]
        public async Task GivenTyreService_WhenGetAllTyresIsCalled_ThenReturnListTyres()
        {
            //Arrange
            var expected = GetSampleTyres();
            _mockTyreRepository.Setup(x => x.GetAllTyres()).ReturnsAsync(expected);
            _tyreService = new TyreService(_mockTyreRepository.Object);

            //Act
            var result = await _tyreService.GetAllTyres();

            //Assert
            Assert.IsInstanceOf<IEnumerable<Tyre>>(result);
            Assert.AreEqual(expected.Count(), result.Count());
        }

        [Test]
        public async Task GivenAllTyres_ItShouldOrder_AmountByAscending()
        {
            //Arrange
            var tyres = GetSampleTyres();
            _mockTyreRepository.Setup(x => x.GetAllTyres()).ReturnsAsync(tyres);
            _tyreService = new TyreService(_mockTyreRepository.Object);

            //Act
            var result = await _tyreService.GetAllTyres();

            //Assert
            const int expectedFirstItemId = 1;
            const int expectedSecondItemId = 3;
            const int expectedThirdItemId = 2;
            var enumerable = result as Tyre[] ?? result.ToArray();
            Assert.AreEqual(expectedFirstItemId, enumerable.First().Id);
            Assert.AreEqual(expectedSecondItemId, enumerable.ElementAt(1).Id);
            Assert.AreEqual(expectedThirdItemId, enumerable.ElementAt(2).Id);
        }


        private static List<Tyre> GetSampleTyres()
        {
            var tyres = new List<Tyre>
            {
                new Tyre {Id = 1, Description = "Continental", BuyPriceExVAT = 250M},
                new Tyre {Id = 2, Description = "Michelin", BuyPriceExVAT = 260M},
                new Tyre {Id = 3, Description = "Pirelli", BuyPriceExVAT = 255M}
            };
            return tyres;
        }
    }
}