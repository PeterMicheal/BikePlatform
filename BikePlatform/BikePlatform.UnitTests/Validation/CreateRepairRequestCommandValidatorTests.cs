using BikePlatform.Application.CreateRepairRequest;
using BikePlatform.Application.Validators;
using BikePlatform.Application.Validators.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.UnitTests.Validation
{
    public class CreateRepairRequestCommandValidatorTests
    {

        private readonly IValidator<CreateRepairRequestCommand> _createRepairRequestCommandValidator;

        public CreateRepairRequestCommandValidatorTests()
        {
            _createRepairRequestCommandValidator = new CreateRepairRequestCommandValidator();
        }

        [Fact]
        public void CreateRepairRequestValidator_Success()
        {
            //Arrange
            var mockCreateRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john@mail.com", "First Issue");

            //Act
            var result = _createRepairRequestCommandValidator.Validate(mockCreateRepairRequestCommand);

            //Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public void CreateRepairRequestValidator_Failure_InvalidName()
        {
            //Arrange
            var mockCreateRepairRequestCommand = new CreateRepairRequestCommand("Joa", "john@mail.com", "First Issue");

            //Act
            var result = _createRepairRequestCommandValidator.Validate(mockCreateRepairRequestCommand);

            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count() == 1);
        }

        [Fact]
        public void CreateRepairRequestValidator_Failure_InvalidEmail()
        {
            //Arrange
            var mockCreateRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john", "First Issue");

            //Act
            var result = _createRepairRequestCommandValidator.Validate(mockCreateRepairRequestCommand);

            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count() == 1);
        }

        [Fact]
        public void CreateRepairRequestValidator_Failure_EmptyDescription()
        {
            //Arrange
            var mockCreateRepairRequestCommand = new CreateRepairRequestCommand("John Dao", "john@mail.com", string.Empty);

            //Act
            var result = _createRepairRequestCommandValidator.Validate(mockCreateRepairRequestCommand);

            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count() == 1);
        }

        [Fact]
        public void CreateRepairRequestValidator_Failure_AllInvalid()
        {
            //Arrange
            var mockCreateRepairRequestCommand = new CreateRepairRequestCommand("John", "john", string.Empty);

            //Act
            var result = _createRepairRequestCommandValidator.Validate(mockCreateRepairRequestCommand);

            //Assert
            Assert.False(result.IsValid);
            Assert.True(result.Errors.Count() == 3);
        }
    }
}
