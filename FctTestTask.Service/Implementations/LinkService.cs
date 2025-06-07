using FctTestTask.DAL.Interfaces;
using FctTestTask.Domain.Entity;
using FctTestTask.Domain.Enum;
using FctTestTask.Domain.Response;
using FctTestTask.Domain.ViewModels.Link;
using FctTestTask.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        private readonly IShortLinkGenerationService _shortLinkGenerationService;
        public LinkService(IBaseRepository<LinkEntity> linksRepository, IShortLinkGenerationService shortLinkGenerationService)
        { 
            _linksRepository = linksRepository; 
            _shortLinkGenerationService = shortLinkGenerationService;
        }
        public async Task<IBaseResponse<LinkShortViewModel>> Create(LinkLongViewModel linkLong)
        {
            try
            {
                var links = await _linksRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.LinkLong == linkLong.LinkLong);
                if (links != null)
                {
                    return new BaseResponse<LinkShortViewModel>
                    {
                        Description = "Short Link already exists",
                        StatusCode = Domain.Enum.StatusCode.OK,
                        Data = new LinkShortViewModel
                        {
                            LinkShort = links.LinkShort
                        }
                    };
                }
                links = new LinkEntity()
                {
                    LinkLong = linkLong.LinkLong,
                    LinkShort = _shortLinkGenerationService.GenerateLink(linkLong).LinkShort
                };
                await _linksRepository.Create(links);
                return new BaseResponse<LinkShortViewModel>
                {
                    Description = "Link Created",
                    StatusCode = Domain.Enum.StatusCode.OK,
                    Data = new LinkShortViewModel
                    {
                        LinkShort = links.LinkShort
                    }
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<LinkShortViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = Domain.Enum.StatusCode.InternalServerError
                };
            }

        }

        public async Task<IBaseResponse<LinkLongViewModel>> GetLink(LinkShortViewModel link)
        {
            try
            {                
                var entity = await _linksRepository.GetAll()
                    .FirstOrDefaultAsync(x => x.LinkShort == link.LinkShort);

                if (entity == null)
                {
                    return new BaseResponse<LinkLongViewModel>
                    {
                        Description = "Link not found",
                        StatusCode = StatusCode.LinkNotFound
                    };
                }

                return new BaseResponse<LinkLongViewModel>
                {
                    StatusCode = StatusCode.OK,
                    Data = new LinkLongViewModel
                    {
                        LinkLong = entity.LinkLong
                    }
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<LinkLongViewModel>
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

    }
}
