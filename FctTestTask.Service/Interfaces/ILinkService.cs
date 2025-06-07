using FctTestTask.DAL.Interfaces;
using FctTestTask.Domain.Entity;
using FctTestTask.Domain.ViewModels.Link;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.Service.Interfaces
{
    public interface ILinkService
    {
        Task<IBaseRepository<LinkEntity>> Create(LinkLongViewModel link);
    }
}
