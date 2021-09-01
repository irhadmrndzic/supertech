
using System.ComponentModel.DataAnnotations;

namespace superTech.Models.Product
{
   public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        public string PriceString { get; set; }
        public decimal? Rating { get; set; }
        public bool Active { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }
        public string FkUnitOfMeasureString { get; set; }
        public string CategoryString { get; set; }
        public int CategoryId { get; set; }
        public int UnitOfMeasureId { get; set; }
        public int Inventory { get; set; }
        public int Quantity { get; set; }
        public string Brand { get; set; }

    }
}
