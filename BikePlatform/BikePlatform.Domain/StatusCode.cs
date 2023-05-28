using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Domain
{
    public enum StatusCode
    {
        Success,
        BadRequest,
        Unauthorized,
        Error,
        NotFound,
        Created,
        NoContent
    }
}
