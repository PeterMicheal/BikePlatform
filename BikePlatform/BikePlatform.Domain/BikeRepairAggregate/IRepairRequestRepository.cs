using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Domain.BikeRepairAggregate
{
    public interface IRepairRequestRepository
    {
        Task<RepairRequest> CreateAsync(RepairRequest repairRequest);
    }
}
