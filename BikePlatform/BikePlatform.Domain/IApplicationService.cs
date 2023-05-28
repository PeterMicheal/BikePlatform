using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Domain
{
    public interface IApplicationService<TResult, TRequest> where TResult : class
    {
        Task<ApplicationResult<TResult>> ExecuteAsync(TRequest request);
    }
}
