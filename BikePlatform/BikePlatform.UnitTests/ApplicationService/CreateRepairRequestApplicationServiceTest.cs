using AutoFixture;
using BikePlatform.Application;
using BikePlatform.Application.CreateRepairRequest;
using BikePlatform.Domain;
using BikePlatform.Domain.BikeRepairAggregate;
using Castle.Core.Resource;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.UnitTests.ApplicationService
{
    public class CreateRepairRequestApplicationServiceTest
    {
        private readonly Mock<IRepairRequestRepository> _mockRepairRequestRepository;
        private readonly IFixture _fixture;
        private readonly ICreateRepairRequestApplicationService _createRepairRequestApplicationService;

        public CreateRepairRequestApplicationServiceTest()
        {
            _mockRepairRequestRepository = new Mock<IRepairRequestRepository>();
            _fixture = new Fixture();

            _createRepairRequestApplicationService = new CreateRepairRequestApplicationService(_mockRepairRequestRepository.Object);
        }

        [Fact]
        public async Task CreateRepairRequest_Success()
        {
            //Arrange
            var createRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john@mail.com", "First Issue");

            var mockRepairRequest = new RepairRequest()
            {
                Name = "John Dao",
                Email = "john@mail.com",
                Description = "First Issue"
            };

            _mockRepairRequestRepository.Setup(x => x.CreateAsync(It.IsAny<RepairRequest>())).ReturnsAsync(mockRepairRequest);

            //Act
            var result = await _createRepairRequestApplicationService.ExecuteAsync(createRepairRequestCommand);

            //Assert
            Assert.IsType<ApplicationResult<CreateRepairRequestResponse>>(result);
            Assert.True(result.Succeeded);
            Assert.Equal(StatusCode.Created, result.GetStatusCode());
        }

        [Fact]
        public async Task CreateRepairRequest_Failure_InvalidName()
        {
            //Arrange
            var createRepairRequestCommand = new CreateRepairRequestCommand("Joe", "john@mail.com", "First Issue");

            //Act
            var result = await _createRepairRequestApplicationService.ExecuteAsync(createRepairRequestCommand);

            //Assert
            Assert.IsType<ApplicationResult<CreateRepairRequestResponse>>(result);
            Assert.True(!result.Succeeded);
            _mockRepairRequestRepository.Verify(x => x.CreateAsync(It.IsAny<RepairRequest>()), Times.Never);
        }

        [Fact]
        public async Task CreateRepairRequest_Failure_InvalidEmail()
        {
            //Arrange
            var createRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john", "First Issue");

            //Act
            var result = await _createRepairRequestApplicationService.ExecuteAsync(createRepairRequestCommand);

            //Assert
            Assert.IsType<ApplicationResult<CreateRepairRequestResponse>>(result);
            Assert.True(!result.Succeeded);
            _mockRepairRequestRepository.Verify(x => x.CreateAsync(It.IsAny<RepairRequest>()), Times.Never);
        }

        [Fact]
        public async Task CreateRepairRequest_Failure_EmptyDescription()
        {
            //Arrange
            var createRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john@mail.com", string.Empty);

            //Act
            var result = await _createRepairRequestApplicationService.ExecuteAsync(createRepairRequestCommand);

            //Assert
            Assert.IsType<ApplicationResult<CreateRepairRequestResponse>>(result);
            Assert.True(!result.Succeeded);
            _mockRepairRequestRepository.Verify(x => x.CreateAsync(It.IsAny<RepairRequest>()), Times.Never);
        }
    }
}
