using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace superTech.Database
{
    public partial class Product
    {
        public Product()
        {
            BillItems = new HashSet<BillItem>();
            BuyerOrderItems = new HashSet<BuyerOrderItem>();
            OrderItems = new HashSet<OrderItem>();
            ProductOffers = new HashSet<ProductOffer>();
            Ratings = new HashSet<Rating>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
        public byte[] Image { get; set; }
        public byte[] ImageThumb { get; set; }
        public int? FkUnitOfMeasureId { get; set; }
        public int? FkCategoryId { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category FkCategory { get; set; }
        public virtual UnitsOfMeasure FkUnitOfMeasure { get; set; }
        public virtual ICollection<BillItem> BillItems { get; set; }
        public virtual ICollection<BuyerOrderItem> BuyerOrderItems { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<ProductOffer> ProductOffers { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
