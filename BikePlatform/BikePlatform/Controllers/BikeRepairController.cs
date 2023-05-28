using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BikePlatform.Application.CreateRepairRequest;

namespace BikePlatform.Controllers
{

    [ApiController, Route("[controller]")]
    public class BikeRepairController : BaseController
    {
        private readonly ICreateRepairRequestApplicationService _createRepairRequestApplicationService;

        public BikeRepairController(ICreateRepairRequestApplicationService createRepairRequestApplicationService)
        {
            _createRepairRequestApplicationService = createRepairRequestApplicationService ?? 
                throw new ArgumentNullException(nameof(createRepairRequestApplicationService));   
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateRepairRequestCommand repairRequest)
        {
            return MapResponse(await _createRepairRequestApplicationService.ExecuteAsync(repairRequest));
        }
    }
}
