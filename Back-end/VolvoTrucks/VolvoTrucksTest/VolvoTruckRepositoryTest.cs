using AutoMapper;
using Domain.Entities;
using FluentAssertions;
using Infrastrucuture.Context;
using Infrastrucuture.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Configuration;

namespace VolvoTrucksTest
{
    [TestClass]
    public class VolvoTruckRepositoryTest
    {
        private IConfiguration _configuration;
        private VolvoTruckContext _Databasecontext;
        private DbContextOptions _options;
        private Mock<IMapper> _MockMapper;
        private ITruckRepository _repository;
        private Truck _expectedTruck;
        private Truck NewTruck;
        private List<Truck> _listTruck;

        [TestInitialize]
        public void Initialize()
        {

            _configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();

            _options = new DbContextOptionsBuilder<VolvoTruckContext>()
                               .UseInMemoryDatabase("InMemory")
                               .Options;

            _Databasecontext = new VolvoTruckContext(_configuration, _options);
            _Databasecontext.Database.EnsureCreated();

            _listTruck = new List<Truck>();
            _MockMapper = new Mock<IMapper>();
            _repository = new TruckRepository(_Databasecontext, _MockMapper.Object);

            _expectedTruck = new Truck()
            {
                Id = 2,
                Model = Domain.Enums.Model.FH,
                Fabricateyear = 2024,
                Chassi_Code = "0000",
                Color = "White",
                Plan = Domain.Enums.Plan.Brasil
            };

            NewTruck = new Truck()
            {
                Model = Domain.Enums.Model.FH,
                Fabricateyear = 2024,
                Chassi_Code = "0000",
                Color = "White",
                Plan = Domain.Enums.Plan.Brasil
            };

            // Add first element 
            _repository.Create(NewTruck);

        }


        [TestMethod]
        public async Task CreateTruckSucess()
        {

            var actionResult = await _repository.Create(new Truck()
            {
                Model = Domain.Enums.Model.FH,
                Fabricateyear = 2024,
                Chassi_Code = "0000",
                Color = "White",
                Plan = Domain.Enums.Plan.Brasil
            });

            actionResult.Should().NotBeNull()
                .And.BeOfType<Truck>()
                .Which.Should().BeEquivalentTo(_expectedTruck);
        }

        [TestMethod]
        public async Task TruckGetElementById()
        {

            var actionResult = await _repository.Get(_expectedTruck.Id);

            actionResult.Should().NotBeNull()
                .And.BeOfType<Truck>()
                .Which.Should().BeEquivalentTo(_expectedTruck);

        }

        [TestMethod]
        public async Task TruckGetElementByIdFail()
        {

            var actionResult = await _repository.Get(0);

            actionResult.Should().BeNull();

        }

        [TestMethod]
        public async Task TruckGetAllElement()
        {
            _listTruck.Add(NewTruck);

            var actionResult = await _repository.GetAllTrucks();

            actionResult.Should().NotBeNull()
               .And.BeOfType<List<Truck>>()
               .Which.Should().HaveCountGreaterThan(1);

        }

        [TestMethod]
        public async Task TruckDeleteElementById()
        {

            var actionResult = await _repository.Delete(1);

            actionResult.Should().BeTrue();
        }

        [TestMethod]
        public async Task TruckUpdateElementById()
        {
            
            var ModelTruck = new Truck()
            {
                Model = Domain.Enums.Model.FH,
                Fabricateyear = 2024,
                Chassi_Code = "ABCDE123456",
                Color = "White",
                Plan = Domain.Enums.Plan.Brasil
            };

            _repository.Create(ModelTruck);

            var UpdateTruck = await _repository.GetByChassiCode(ModelTruck.Chassi_Code);

            _MockMapper
                .Setup(e => e.Map<Truck>(It.IsAny<Truck>()))
                .Returns(UpdateTruck);

            var actionResult = await _repository.Update(UpdateTruck);

            actionResult.Should().NotBeNull()
              .And.BeOfType<Truck>()
              .Which.Should().BeEquivalentTo(UpdateTruck);
        }

        [TestMethod]
        public async Task TruckGetByChassiCode()
        {

            var ModelTruck = new Truck()
            {
                Model = Domain.Enums.Model.FH,
                Fabricateyear = 2024,
                Chassi_Code = "ABCDE123456",
                Color = "White",
                Plan = Domain.Enums.Plan.Brasil
            };

            _repository.Create(ModelTruck);

            var actionResult = await _repository.GetByChassiCode(ModelTruck.Chassi_Code);

            actionResult.Should().NotBeNull()
                .And.BeOfType<Truck>();

            actionResult.Chassi_Code.Should().Be(ModelTruck.Chassi_Code);
        }
    }
}
