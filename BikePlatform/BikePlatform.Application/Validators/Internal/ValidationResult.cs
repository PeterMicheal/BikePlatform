using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePlatform.Application.Validators.Internal
{
    public class ValidationResult
    {
        public ValidationResult(IEnumerable<string> failures)
        {
            Errors = failures.Where(failure => failure != null);
        }

        public virtual bool IsValid => !Errors.Any();

        public IEnumerable<string> Errors { get; }

        public override string ToString()
        {
            return ToString(Environment.NewLine);
        }

        public string ToString(string separator)
        {
            return string.Join(separator, Errors.Select(failure => failure));
        }

    }
}
