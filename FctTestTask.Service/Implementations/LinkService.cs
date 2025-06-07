using FctTestTask.DAL.Interfaces;
using FctTestTask.Domain.Entity;
using FctTestTask.Domain.ViewModels.Link;
using FctTestTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.Service.Implementations
{
    public class LinkService : ILinkService
    {
        private readonly IBaseRepository<LinkEntity> _linksRepository;
        
        public LinkService(IBaseRepository<LinkEntity> linksRepository) { _linksRepository = linksRepository; }
        public Task<IBaseRepository<LinkEntity>> Create(LinkLongViewModel link)
        {
            throw new NotImplementedException();
        }
    }
}
