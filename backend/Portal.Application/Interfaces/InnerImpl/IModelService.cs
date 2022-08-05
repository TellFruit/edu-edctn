using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Interfaces.Inner
{
    public interface IModelService<TEntityDTO> where TEntityDTO : class
    {
        Task<TEntityDTO> Create(TEntityDTO entity);
        Task<ICollection<TEntityDTO>> GetAll();
        Task<TEntityDTO> Update(TEntityDTO entity);
        Task<int> Delete(int id);
    }
}
