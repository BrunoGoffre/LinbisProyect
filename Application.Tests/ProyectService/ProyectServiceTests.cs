using Moq;
using Application.Interfaces;
using Application.Proyects.Queries.Response;
using Application.Developers.Queries;

namespace Application.Tests.ProyectService
{

    [TestFixture]
    public class ProyectServiceTests
    {
        private Mock<IProyectService> _proyectService;
        private GetProyectsRequestHandler _requestHandler;

        [SetUp]
        public void Init()
        {
            _proyectService = new Mock<IProyectService>();
            _requestHandler = new(_proyectService.Object);
        }

        [Test]
        public async Task GetProyectById_WhenProyectExists_ShouldReturnProyectResponse()
        {
            var request = new GetProyectsRequest { ProyectId = 2 };
             _proyectService.Setup(x => x.GetProyectById(It.IsAny<int>()))
                .Returns(new GetProyectResponse() 
                {
                    Name = "Linbis",
                    IsActive = true,
                    addedDate = 11111111,
                    developmentCost = 100,
                    effortRequireInDays = 10,
                    Developers = new ()

                });
            
            var response = await _requestHandler.Handle(request, new CancellationToken());

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetProyectById_WhenProyectDoesNotExist_ShouldReturnNull()
        {
            _proyectService.Setup(x => x.GetProyectById(It.IsAny<int>()))
                .Returns((GetProyectResponse)null);

            var request = new GetProyectsRequest { ProyectId = 4 }; 
            var response = await _requestHandler.Handle(request, new CancellationToken());

            Assert.IsNull(response);
        }
    }
}
