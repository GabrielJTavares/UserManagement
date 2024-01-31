using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Commom.Interfaces
{
    public interface IReadRepository<T>
    {
        Task<T> GetById(Guid EntityId);
        Task<IEnumerable<T>> GetAll();
        Task<bool> IsExist(Guid id);

    }
}
