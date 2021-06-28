namespace superTech.Models.Product
{
  public  class ProductsSearchRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int? CategoryId { get; set; }
    }
}
