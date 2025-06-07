using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.Domain.Enum
{
    public enum StatusCode
    {
        InvalidLink = 1,
        LinkNotFound = 2,
        OK = 200,
        InternalServerError = 500
    }
}
