using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Domain
{
    public abstract class ApplicationService<TResult, TRequest> : IApplicationService<TResult, TRequest> where TResult : class
    {
        public async Task<ApplicationResult<TResult>> ExecuteAsync(TRequest request)
        {
            try
            {
                return await DoExecuteAsync(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public abstract Task<ApplicationResult<TResult>> DoExecuteAsync(TRequest request);

        protected ApplicationResult<TResult> Success(TResult data)
        {
            return ApplicationResult<TResult>.Success(data);
        }

        protected ApplicationResult<TResult> Fail()
        {
            return ApplicationResult<TResult>.Fail();
        }

        protected ApplicationResult<TResult> BadRequest(params string[] errors)
        {
            return ApplicationResult<TResult>.BadRequest(errors);
        }

        protected ApplicationResult<TResult> BadRequest(IEnumerable<string> errors)
        {
            return ApplicationResult<TResult>.BadRequest(errors);
        }

        protected ApplicationResult<TResult> Created(TResult data)
        {
            return ApplicationResult<TResult>.Created(data);
        }
    }
}
