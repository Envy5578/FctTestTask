using FctTestTask.DAL.Interfaces;
using FctTestTask.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.DAL.Repositories
{
    public class LinkRepository : IBaseRepository<LinkEntity>
    {
        private readonly AppDbContext _appDbContext;
        public LinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Create(LinkEntity entity)
        {
            await _appDbContext.Links.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
