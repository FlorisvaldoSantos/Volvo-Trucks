using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using VolvoTrucks.Api.Services;
using VolvoTrucks.Controllers;


namespace VolvoTrucksTest
{
    [TestClass]
    public class VolvoTrucksControllerTest
    {
        private Mock<ILogger<TrucksController>> _MockLogger;
        private Mock<ITruckService> _MockTruckService;
        private TrucksController _controller;
        private Truck _expectedTruck;
        private List<Truck> _listExpectedTruck;

        [TestInitialize]
        public void Initialize() 
        {
            _MockLogger = new Mock<ILogger<TrucksController>>();
            _MockTruckService = new Mock<ITruckService>();
            _controller = new TrucksController(_MockLogger.Object, _MockTruckService.Object)
                .EnsureHttpContext();

            _expectedTruck = new Truck()
            {
                Model = Domain.Enums.Model.FH,
                Fabricateyear = 2024,
                Chassi_Code = "0000",
                Color = "White",
                Plan = Domain.Enums.Plan.Brasil
            };

            _listExpectedTruck = new();
            _listExpectedTruck.Add(_expectedTruck);
            _listExpectedTruck.Add(_expectedTruck);
        }

        [TestMethod]
        public async Task CreateTruckSucess()
        {
            _MockTruckService
                .Setup(e => e.Create(It.IsAny<Truck>()))
                .ReturnsAsync(_expectedTruck);

            var NewTruck = new Truck() { 
                Chassi_Code = "11111",
                Color = "black",
                Fabricateyear = 2024,
                Model = Domain.Enums.Model.FH,
                Plan = Domain.Enums.Plan.Brasil
            };
            var actionResult = await _controller.Create(NewTruck);

            actionResult.Should().NotBeNull()
                .And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(_expectedTruck);
        }

        [TestMethod]
        public async Task CreateTruckThrow()
        {
            _MockTruckService
                .Setup(e => e.Create(It.IsAny<Truck>()))
                .ThrowsAsync(new Exception("New Exception was throw."));

            var NewTruck = new Truck()
            {
                Chassi_Code = "11111",
                Color = "black",
                Fabricateyear = 2024,
                Model = Domain.Enums.Model.FH,
                Plan = Domain.Enums.Plan.Brasil
            };
            var actionResult = await _controller.Create(NewTruck);

            actionResult.Should().NotBeNull()
                .And.BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeOfType<Exception>()
                .Which.Message.Should().Be("New Exception was throw.");
        }

        [TestMethod]
        public async Task GetTruckByIdSucess()
        {
            _MockTruckService
                .Setup(e => e.Get(It.IsAny<int>()))
                .ReturnsAsync(_expectedTruck);
                        
            var actionResult = await _controller.GetById(1);

            actionResult.Should().NotBeNull()
                .And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(_expectedTruck);
        }

        [TestMethod]
        public async Task GetTruckByIdThrow()
        {
            _MockTruckService
                .Setup(e => e.Get(It.IsAny<int>()))
                .ThrowsAsync(new Exception("New Exception was throw."));

            var actionResult = await _controller.GetById(1);

            actionResult.Should().NotBeNull()
                .And.BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeOfType<Exception>()
                .Which.Message.Should().Be("New Exception was throw.");
        }

        [TestMethod]
        public async Task GetAllTruckSucess()
        {
            _MockTruckService
                .Setup(e => e.GetAllTrucks())
                .ReturnsAsync(_listExpectedTruck);

            var actionResult = await _controller.GetAll();

            actionResult.Should().NotBeNull()
                .And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<List<Truck>>()
                .Which.Should().BeEquivalentTo(_listExpectedTruck);
        }

        [TestMethod]
        public async Task GetAllTruckThrow()
        {
            _MockTruckService
                .Setup(e => e.GetAllTrucks())
                .ThrowsAsync(new Exception("New Exception was throw."));

            var actionResult = await _controller.GetAll();

            actionResult.Should().NotBeNull()
                .And.BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeOfType<Exception>()
                .Which.Message.Should().Be("New Exception was throw.");
        }

        [TestMethod]
        public async Task UpdateTruckSucess()
        {
            _MockTruckService
                .Setup(e => e.Update(It.IsAny<Truck>()))
                .ReturnsAsync(_expectedTruck);

            var TruckUpdate = new Truck()
            {
                Id = 1,
                Chassi_Code = "11111",
                Color = "black",
                Fabricateyear = 2024,
                Model = Domain.Enums.Model.FH,
                Plan = Domain.Enums.Plan.Brasil
            };

            var actionResult = await _controller.Update(TruckUpdate);

            actionResult.Should().NotBeNull()
                .And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<Truck>()
                .Which.Should().BeEquivalentTo(_expectedTruck);
        }

        [TestMethod]
        public async Task UpdateTruckThrow()
        {
            _MockTruckService
                .Setup(e => e.Update(It.IsAny<Truck>()))
                .ThrowsAsync(new Exception("New Exception was throw."));

            var TruckUpdate = new Truck()
            {
                Id = 1,
                Chassi_Code = "11111",
                Color = "black",
                Fabricateyear = 2024,
                Model = Domain.Enums.Model.FH,
                Plan = Domain.Enums.Plan.Brasil
            };

            var actionResult = await _controller.Update(TruckUpdate);

            actionResult.Should().NotBeNull()
                .And.BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeOfType<Exception>()
                .Which.Message.Should().Be("New Exception was throw.");
        }

        [TestMethod]
        public async Task DeleteTruckSucess()
        {
            _MockTruckService
                .Setup(e => e.Delete(It.IsAny<int>()))
                .ReturnsAsync(true);

            var actionResult = await _controller.Delete(1);

            actionResult.Should().NotBeNull()
                .And.BeOfType<OkObjectResult>()
                .Which.Value.Should().BeOfType<bool>()
                .Which.Should().BeTrue();
        }

        [TestMethod]
        public async Task DeleteTruckThrow()
        {
            _MockTruckService
                .Setup(e => e.Delete(It.IsAny<int>()))
                .ThrowsAsync(new Exception("New Exception was throw."));

            var actionResult = await _controller.Delete(1);

            actionResult.Should().NotBeNull()
                .And.BeOfType<BadRequestObjectResult>()
                .Which.Value.Should().BeOfType<Exception>()
                .Which.Message.Should().Be("New Exception was throw.");
        }
    }
}