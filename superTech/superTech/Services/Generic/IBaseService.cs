using System.Collections.Generic;

namespace superTech.Services.Generic
{
   public interface IBaseService<T, TSearchFilter>
    {
        List<T> Get(TSearchFilter searchFilter);
        T GetById(int id);
    }
}
