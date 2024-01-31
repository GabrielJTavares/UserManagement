using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.Commom.Interfaces
{
    public interface ICommandRepository<T>
    {
        Task<bool> Create(T Entity);
        Task<bool> Update(T Entity);
        Task<bool> Delete(T UserId);
    }
}
