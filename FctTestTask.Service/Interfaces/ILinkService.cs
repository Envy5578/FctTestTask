using FctTestTask.DAL.Interfaces;
using FctTestTask.Domain.Entity;
using FctTestTask.Domain.Response;
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
        Task<IBaseResponse<LinkShortViewModel>> Create(LinkLongViewModel link);
        Task<IBaseResponse<LinkLongViewModel>> GetLink(LinkShortViewModel link);
    }
}
