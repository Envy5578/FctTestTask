using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Create(T entity);
    }
}
