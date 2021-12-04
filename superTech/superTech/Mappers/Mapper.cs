using System.Linq;
using AutoMapper;
using superTech.Database;
using superTech.Models.Bills;
using superTech.Models.Bills.BillItems;
using superTech.Models.Brands;
using superTech.Models.BuyerOrders;
using superTech.Models.BuyerOrders.BuyerOrderItems;
using superTech.Models.Category;
using superTech.Models.City;
using superTech.Models.News;
using superTech.Models.Offers;
using superTech.Models.Offers.OfferItems;
using superTech.Models.Orders;
using superTech.Models.Orders.OrderItems;
using superTech.Models.Product;
using superTech.Models.Ratings;
using superTech.Models.ReportsModel;
using superTech.Models.Roles;
using superTech.Models.Suppliers;
using superTech.Models.UnitsOfMeasures;
using superTech.Models.User;

namespace superTech.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Role, RolesModel>().ReverseMap();
            CreateMap<Brand, BrandsModel>().ReverseMap();

            CreateMap<User, UserModel>().ForMember(x => x.DateOfBirth, src => src.MapFrom(x => x.DateOfBirth.ToShortDateString())).ReverseMap();
            CreateMap<UsersRole, UsersRolesModel>().ReverseMap();
            CreateMap<Rating, RatingsModel>().ReverseMap();



            CreateMap<User, UserModel>()
                .ForMember(x => x.Roles, a => a.MapFrom(src => src.UsersRoles.Select(s => s.FkRole.Name)))
                .ForMember(g => g.City, gr => gr.MapFrom(sr => sr.FkCity.CityId))
                .ForMember(c => c.CityString, c => c.MapFrom(c => c.FkCity.Name))
                .ForMember(a => a.ProfilePicture, sr => sr.MapFrom(q => q.ProfilePicture))
                .ForMember(r => r.RolesString, rs => rs.MapFrom(src => string.Join(",", src.UsersRoles.Select(x => x.FkRole.Name))))
                .ForMember(c => c.Roles, c => c.MapFrom(c => c.UsersRoles.Select(q => q.FkRoleId)))
                .ReverseMap();



            CreateMap<User, UserUpsertRequest>().ReverseMap();

            CreateMap<UnitsOfMeasure, UnitsOfMeasuresModel>().ReverseMap();
            CreateMap<UnitsOfMeasure, UnitsOfMeasuresUpsertRequest>().ReverseMap();

            CreateMap<News, NewsModel>().ReverseMap();
            CreateMap<News, NewsUpsertRequest>().ReverseMap();

            CreateMap<User, UserUpsertRequest>()
                .ForMember(x => x.CityId, q => q.MapFrom(src => src.FkCityId))
                .ReverseMap();

            CreateMap<Product, ProductModel>().ForMember(x => x.CategoryString, src => src.MapFrom(x => x.FkCategory.Name)).
                ForMember(y => y.FkUnitOfMeasureString, m => m.MapFrom(src => src.FkUnitOfMeasure.Name)).
                ForMember(m => m.CategoryId, sr => sr.MapFrom(a => a.FkCategory.CategoryId)).
                ForMember(s => s.UnitOfMeasureId, sr => sr.MapFrom(um => um.FkUnitOfMeasure.UnitOfMeasureId)).
                ForMember(r => r.Rating, ra => ra.MapFrom(srr => srr.Ratings.Average(ra => (decimal?)ra.Rating1)))
                .ForMember(i => i.Inventory, sri => sri.MapFrom(mf => mf.OrderItems.Where(f => f.FkOrder.Confirmed == true).Sum(e => e.Quantity) - mf.BuyerOrderItems.Sum(o => o.Quantity)))
                .ForMember(b => b.Brand, sr => sr.MapFrom(x => x.Brand.Name))
                .ForMember(b => b.PriceString, sr => sr.MapFrom(x => x.Price + " KM"))
                .ForMember(q=>q.Image,sr=>sr.MapFrom(a=>a.Image))
                .ForMember(b=>b.BrandId,src=>src.MapFrom(x=>x.BrandId))
                .ReverseMap();


            CreateMap<Product, ProductUpsertRequest>().ReverseMap();
            CreateMap<City, CityModel>().ReverseMap();

            CreateMap<City, CityUpsertRequest>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Category, CategoryUpsertRequest>().ReverseMap();

            CreateMap<Supplier, SuppliersModel>().ReverseMap();

            CreateMap<OrderItem, OrderItemModel>()
                .ForMember(x => x.FkOrderId, src => src.MapFrom(a => a.FkOrder.OrderId))
                .ForMember(x => x.FkProductId, src => src.MapFrom(a => a.FkProduct.ProductId))
                .ForMember(x => x.ProductName, src => src.MapFrom(a => a.FkProduct.Name))
                .ForMember(x => x.ProductCode, src => src.MapFrom(a => a.FkProduct.Code));

            CreateMap<Order, OrdersModel>()
                .ForMember(x => x.FkSupplierId, src => src.MapFrom(a => a.FkSupplier.SupplierId))
                .ForMember(x => x.FkUserId, src => src.MapFrom(a => a.FkUser.UserId))
                .ForMember(q => q.UserString, w => w.MapFrom(src => src.FkUser.UserName))
                .ForMember(q => q.SupplierString, w => w.MapFrom(src => src.FkSupplier.Name))
                .ForMember(l => l.OrderItems, k => k.MapFrom(src => src.OrderItems))
                .ForMember(l => l.Confirmed, k => k.MapFrom(src => src.Confirmed))
                .ReverseMap();


            CreateMap<ProductOffer, OfferItemsModel>()
                .ForMember(x => x.FkOfferId, src => src.MapFrom(q => q.FkOffer.OfferId))
                .ForMember(x => x.FkProductId, src => src.MapFrom(q => q.FkProduct.ProductId))
                .ForMember(x => x.ProductName, src => src.MapFrom(q => q.FkProduct.Name))
                .ForMember(x => x.PriceNoDiscount, src => src.MapFrom(q => q.FkProduct.Price))
                .ReverseMap();

            CreateMap<OfferItemsUpsertRequest, ProductOffer>()
                .ForMember(x => x.FkProductId, src => src.MapFrom(q => q.FkProductId))
                .ForMember(x => x.FkOfferId, src => src.MapFrom(q => q.FkOfferId))
                .ForMember(x => x.Discount, src => src.MapFrom(q => q.Discount))
                .ForMember(x => x.PriceWithDiscount, src => src.MapFrom(q => q.PriceWithDiscount)).ReverseMap();


            CreateMap<Offer, OffersModel>()
                    .ForMember(x => x.OfferItems, src => src.MapFrom(x => x.ProductOffers)).ReverseMap();

            CreateMap<BuyerOrder, BuyerOrdersModel>()
                .ForMember(x => x.FkUserId, src => src.MapFrom(a => a.FkUser.UserId))
                .ForMember(q => q.UserString, w => w.MapFrom(src => src.FkUser.UserName + ", " + src.FkUser.FirstName + " " + src.FkUser.LastName))
                .ForMember(q => q.BuyerOrderItems, w => w.MapFrom(src => src.BuyerOrderItems))
                .ForMember(a => a.ShippingAddress, src => src.MapFrom(q => q.FkUser.Address))
                .ReverseMap();


            CreateMap<BuyerOrderItem, BuyerOrderItemsModel>()
                .ForMember(x => x.ProductName, src => src.MapFrom(q => q.FkProduct.Name))
                .ForMember(x => x.ProductCode, src => src.MapFrom(q => q.FkProduct.Code))
                .ForMember(x => x.ProductPrice, opt => opt.MapFrom(src => src.FkProduct.ProductOffers
                .Where(x => x.FkProduct.ProductId == src.FkProductId && x.FkOffer.Active == true).Count() > 0 ? src.FkProduct.ProductOffers
                .Where(a => a.FkProduct.ProductId == src.FkProductId).Select(f => f.PriceWithDiscount).FirstOrDefault() : src.FkProduct.Price))

               .ReverseMap();


            CreateMap<Bill, BillsModel>()
              .ForMember(x => x.BillItems, src => src.MapFrom(x => x.BillItems))
              .ForMember(q=>q.UserString,src=>src.MapFrom(k=>k.FkUser.UserName + ", " + k.FkUser.UserName + " " +k.FkUser.LastName))
              .ForMember(f=>f.ShippingAddress, src=>src.MapFrom(q=>q.FkUser.Address))
              .ForMember(f=>f.OrderNumber, src=>src.MapFrom(q=>q.FkBuyerOrderNavigation.OrderNumber.ToString()))
              .ReverseMap();

            CreateMap<BillItem, BillItemsModel>()
                .ForMember(x => x.ProductString, src => src.MapFrom(x => x.FkProduct.Name))
                 .ForMember(x => x.Price, src => src.MapFrom(q => q.Price))
                .ReverseMap();


            CreateMap<Bill, BillsUpsertRequest>()
                .ReverseMap();



            CreateMap<BuyerOrderItem, ReportsBuyerItemsModel>()
                .ForMember(x => x.ProductName, src => src.MapFrom(q => q.FkProduct.Name))
                .ForMember(x => x.ProductCode, src => src.MapFrom(q => q.FkProduct.Code))
                .ForMember(x => x.ProductPrice, opt => opt.MapFrom(src => src.FkProduct.ProductOffers
                .Where(x => x.FkProduct.ProductId == src.FkProductId && x.FkOffer.Active == true).Count() > 0 ? src.FkProduct.ProductOffers
                .Where(a => a.FkProduct.ProductId == src.FkProductId).Select(f => f.PriceWithDiscount).FirstOrDefault() : src.FkProduct.Price))
               .ForMember(q=>q.Quantity,src=>src.MapFrom(s=>s.FkBuyerOrderNavigation.BuyerOrderItems.Sum(y=>y.Quantity)))
               .ForMember(q=>q.Amount,src=>src.MapFrom(s=>s.FkBuyerOrderNavigation.BuyerOrderItems.Sum(y=>y.Amount)))
                .ReverseMap();

        }
    }
}
