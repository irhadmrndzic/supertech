
using superTech.Services.Generic;

namespace superTech.Services.GenericCRUD
{
    public interface ICRUDService<T,TSearch, TInsert, TUpdate>:IBaseService<T,TSearch>
    {
        T Insert(TInsert request);
        T Update(int id, TUpdate request);

    }
}
