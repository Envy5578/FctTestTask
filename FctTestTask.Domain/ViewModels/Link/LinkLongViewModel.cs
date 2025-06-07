using FctTestTask.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.Domain.ViewModels.Link
{
    public class LinkLongViewModel
    {
        [HttpsUrl]
        public string LinkLong { get; set; }
    }
}
