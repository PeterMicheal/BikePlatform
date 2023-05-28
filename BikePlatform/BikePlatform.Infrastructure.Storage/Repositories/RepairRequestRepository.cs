using BikePlatform.Domain.BikeRepairAggregate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Infrastructure.Storage.Repositories
{
    public class RepairRequestRepository : IRepairRequestRepository
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public RepairRequestRepository(IServiceScopeFactory scopeFactory) { 
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }    

        public async Task<RepairRequest> CreateAsync(RepairRequest repairRequest)
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.AddAsync(repairRequest).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);

            return repairRequest;
        }
    }
}
