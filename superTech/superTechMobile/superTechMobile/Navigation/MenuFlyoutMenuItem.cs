using superTechMobile.Views.Products;
using System;

namespace superTechMobile.Navigation
{
    public class MenuFlyoutMenuItem
    {
        public MenuFlyoutMenuItem()
        {
            TargetType = typeof(ProductsPage);
        }
        public string  Image { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}