using AutoFixture;
using BikePlatform.Application.CreateRepairRequest;
using BikePlatform.Controllers;
using BikePlatform.Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.UnitTests.Controllers
{
    public class BikeRepairControllerTest
    {
        
        private readonly Mock<ICreateRepairRequestApplicationService> _mockCreateRepairRequestApplicationService;

        private readonly IFixture _fixture;
        private readonly BikeRepairController _bikeRepairController;

        public BikeRepairControllerTest()
        {
            _mockCreateRepairRequestApplicationService = new Mock<ICreateRepairRequestApplicationService>();

            _fixture = new Fixture();
            _bikeRepairController = new BikeRepairController(_mockCreateRepairRequestApplicationService.Object);
        }

        [Fact]
        public async Task CreateRepairRequest_Success()
        {
            //Arrange
            var mockCreateRepairRequestResponse = _fixture.Create<CreateRepairRequestResponse>();
            var mockAppServiceResponse = ApplicationResult<CreateRepairRequestResponse>.Success(mockCreateRepairRequestResponse);

            _mockCreateRepairRequestApplicationService.Setup(x => x.ExecuteAsync(It.IsAny<CreateRepairRequestCommand>()))
                .ReturnsAsync(mockAppServiceResponse);

            var createRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john@mail.com", "First Issue");

            //Act
            var result = await _bikeRepairController.CreateAsync(createRepairRequestCommand).ConfigureAwait(false);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var repairRequest = Assert.IsType<ApplicationResult<CreateRepairRequestResponse>>(okResult.Value);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(repairRequest, mockAppServiceResponse);
        }

    }
}
