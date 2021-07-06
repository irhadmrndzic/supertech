using AutoMapper;
using superTech.Database;
using superTech.Models.Suppliers;
using superTech.Services.GenericCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace superTech.Services
{
    public class SuppliersService : BaseCRUDService<SuppliersModel, SuppliersSearchRequest, Supplier, SuppliersModel, SuppliersModel>, ICRUDService<SuppliersModel, SuppliersSearchRequest, SuppliersModel, SuppliersModel>
    {
        public SuppliersService(superTechRSContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public override List<SuppliersModel> Get(SuppliersSearchRequest searchFilter)
        {

            var query = _dbContext.Suppliers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchFilter.Name))
            {
                query = query.Where(x => x.Name.ToLower().Contains(searchFilter.Name.ToLower()));
            }

            var list = query.ToList();

            return _mapper.Map<List<SuppliersModel>>(list);
        }

    }
}
