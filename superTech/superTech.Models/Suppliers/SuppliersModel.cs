namespace superTech.Models.Suppliers
{
   public  class SuppliersModel
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string WebAddress { get; set; }
        public string BankAccount { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

    }
}
