using BikePlatform.Application.CreateRepairRequest;
using BikePlatform.Application.Validators;
using BikePlatform.Application.Validators.Internal;
using BikePlatform.Domain;
using BikePlatform.Domain.BikeRepairAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Application
{
    public class CreateRepairRequestApplicationService : ApplicationService<CreateRepairRequestResponse, CreateRepairRequestCommand>, ICreateRepairRequestApplicationService
    {
        private readonly IRepairRequestRepository _repairRequestRepository;
        private readonly IValidator<CreateRepairRequestCommand> _validator;
        public CreateRepairRequestApplicationService(IRepairRequestRepository repairRequestRepository)
        {
            _repairRequestRepository = repairRequestRepository ?? throw new ArgumentNullException(nameof(repairRequestRepository));
            _validator = new CreateRepairRequestCommandValidator();
        }

        public override async Task<ApplicationResult<CreateRepairRequestResponse>> DoExecuteAsync(CreateRepairRequestCommand command)
        {
            var validationResult = _validator.Validate(command);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var repairRequest = new RepairRequest
            {
                Name = command.Name,
                Email = command.Email,
                Description = command.Description,
            };

            await _repairRequestRepository.CreateAsync(repairRequest).ConfigureAwait(false);

            return Created(new CreateRepairRequestResponse(repairRequest.Id));
        }
    }
}
