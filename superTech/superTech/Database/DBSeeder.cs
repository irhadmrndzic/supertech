using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using superTech.Services;
using System;
using System.Text;
using System.IO;
using superTech.Properties;

namespace superTech.Database
{
    public class DBSeeder
    {

        public static byte[] ReadFile(string sPath)
        {
            byte[] data = null;

            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fStream);

            data = br.ReadBytes((int)numBytes);

            return data;
        }

        public static void Init(superTechRSContext context)
        {
            context.Database.Migrate();

            if (context.Users.Any())
            {
                return;
            }

            

            City mostar = new City
            {
                Name = "Mostar",
                ZipCode = "88000"
            };

            context.Cities.Add(mostar);
            context.SaveChanges();

            City sarajevo = new City
            {
                Name = "Sarajevo",
                ZipCode = "71000"
            };

            context.Cities.Add(sarajevo);
            context.SaveChanges();




            Category mobiteli = new Category
            {
                Name = "Mobiteli"
            };

            context.Categories.Add(mobiteli);
            context.SaveChanges();

            Category laptopi = new Category
            {
                Name = "Laptopi"
            };

            context.Categories.Add(laptopi);
            context.SaveChanges();

            Role Administrator = new Role { Name = "Administrator", Description = "Administrator" };
            Role Kupac = new Role { Name = "Kupac", Description = "Kupac" };
            Role Dostavljac = new Role { Name = "Dostavljac", Description = "Dostavljac" };

            context.Roles.Add(Administrator);
            context.SaveChanges();
            context.Roles.Add(Kupac);
            context.SaveChanges();
            context.Roles.Add(Dostavljac);
            context.SaveChanges();


            UnitsOfMeasure komad = new UnitsOfMeasure { Name = "Komad" };
            UnitsOfMeasure metar = new UnitsOfMeasure { Name = "Metar" };

            context.UnitsOfMeasures.Add(komad);
            context.SaveChanges();
            context.UnitsOfMeasures.Add(metar);
            context.SaveChanges();

            var adminSalt = UsersService.GenerateSalt();

            var admin = new User()
            {
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "desktop",
                Active = true,
                FkCity =mostar,
                Address = "Marsala Tita",
                PhoneNumber = "124-456-789",
                Email = "mail@mail.com",
                Gender = "Muski",
                RegistrationDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                ProfilePicture = ReadFile("../supertech/Resources/admin.png"),
                PasswordSalt = adminSalt,
                PasswordHash = UsersService.GenerateHash(adminSalt, "test")
            };

            context.Users.Add(admin);
            context.SaveChanges();

            var mobileSalt = UsersService.GenerateSalt();

            var mobile = new User()
            {
                FirstName = "mobile",
                LastName = "mobile",
                UserName = "mobile",
                Active = true,
                FkCity = mostar,
                Address = "Bulevar M.S",
                PhoneNumber = "124-456-789",
                Email = "email@mail.com",
                Gender = "Muski",
                RegistrationDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                PasswordSalt = mobileSalt,
                PasswordHash = UsersService.GenerateHash(mobileSalt, "test"),
                ProfilePicture = ReadFile("../supertech/Resources/profilePhoto.jpg"),
            };

            context.Users.Add(mobile);
            context.SaveChanges();

            var testSalt = UsersService.GenerateSalt();

            var test = new User()
            {
                FirstName = "test",
                LastName = "test",
                UserName = "test",
                Active = true,
                FkCity = sarajevo,
                Address = "Bulevar M.S",
                PhoneNumber = "124-456-789",
                Email = "test@mail.com",
                Gender = "Muski",
                RegistrationDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                ProfilePicture = null,
                PasswordSalt = testSalt,
                PasswordHash = UsersService.GenerateHash(testSalt, "test")
            };

            context.Users.Add(test);
            context.SaveChanges();

            var delivererSalt = UsersService.GenerateSalt();

            var deliverer = new User()
            {
                FirstName = "deliverer",
                LastName = "deliverer",
                UserName = "deliverer",
                Active = true,
                FkCity =mostar,
                Address = "Bulevar M.S",
                PhoneNumber = "124-456-789",
                Email = "deliverer@mail.com",
                Gender = "Muski",
                RegistrationDate = DateTime.Now,
                DateOfBirth = DateTime.Now,
                ProfilePicture = ReadFile("../supertech/Resources/deliverer.jpg"),
                PasswordSalt = delivererSalt,
                PasswordHash = UsersService.GenerateHash(delivererSalt, "test")
            };

            context.Users.Add(deliverer);
            context.SaveChanges();

            var userRoles = new List<UsersRole> { new UsersRole
            {
                DateOfModification = DateTime.Now,
                FkUser = admin,
                FkRole =Administrator,

            },
            new UsersRole
            {
                DateOfModification = DateTime.Now,
                 FkUser = mobile,
                FkRole = Kupac,
            }
            ,new UsersRole
            {
                 DateOfModification = DateTime.Now,
                 FkUser = test,
                FkRole = Kupac,
            }
            ,new UsersRole
            {
                 DateOfModification = DateTime.Now,
                 FkUser = deliverer,
                FkRole = Dostavljac,
            }
            };

            context.UsersRoles.AddRange(userRoles);
            context.SaveChanges();

            var brands = new List<Brand> { new Brand
            {
                Name = "Samsung",
                Phone ="222-333-444",
                WebAddress="www.samsung.com"
            },
              new Brand
            {
                Name = "Dell",
                Phone ="222-333-444",
                WebAddress="www.dell.com"
            },
                new Brand
            {
                Name = "Apple",
                Phone ="222-232-444",
                WebAddress="www.apple.com"
            }

            };
            context.Brands.AddRange(brands);
            context.SaveChanges();

            var samsung = new Product
            {
                FkCategory =mobiteli,
                Name = "Samsung S21",
                Price = 2200,
                Brand = brands[0],
                Active = true,
                Code = "FKLSD3942",
                FkUnitOfMeasure =komad,
                Description = "Najbolji mobitel od Samsunga.",
                Image = ReadFile("../supertech/Resources/samsung.jpg"),
                ImageThumb = ReadFile("../supertech/Resources/samsung.jpg"),
            };

            var dell = new Product
            {
                FkCategory = laptopi,
                Name = "LAPTOP DELL INSPIRON15",
                Price = 1000,
                Brand = brands[1],
                Active = true,
                Code = "KGUID3942",
                FkUnitOfMeasure = komad,
                Description = "15.6'' FULL HD AG, INTEL I3-1005G1",
                Image = ReadFile("../supertech/Resources/dell.jpg"),
                ImageThumb = ReadFile("../supertech/Resources/dell.jpg"),
            };
            var apple = new Product
            {
                FkCategory = laptopi,
                Name = "APPLE MACBOOK AIR 13.3",
                Price = 3000,
                Brand = brands[2],
                Active = true,
                FkUnitOfMeasure = komad,
                Code = "LPUID2942",
                Description = "Procesor: Apple M1",
                Image = ReadFile("../supertech/Resources/mac.jpg"),
                ImageThumb = ReadFile("../supertech/Resources/mac.jpg"),
            };


            context.Products.Add(samsung);
            context.SaveChanges();
            context.Products.Add(dell);
            context.SaveChanges();
            context.Products.Add(apple);
            context.SaveChanges();

            var appleRating = new Rating
            {
                Date = DateTime.Now,
                Rating1 = 5,
                FkUser = mobile,
                FkProduct = apple
            };
            var appleRating2 = new Rating
            {
                Date = DateTime.Now,
                Rating1 = 3,
                FkUser = mobile,
                FkProduct = apple
            };

            context.Ratings.Add(appleRating);
            context.SaveChanges();
            context.Ratings.Add(appleRating2);
            context.SaveChanges();

            var samsungRating = new Rating
            {
                Date = DateTime.Now,
                Rating1 = 4,
                FkUser = mobile,
                FkProduct = samsung
            };
            var samsungRatin2 = new Rating
            {
                Date = DateTime.Now,
                Rating1 = 4,
                FkUser = mobile,
                FkProduct = samsung
            };

            context.Ratings.Add(samsungRating);
            context.SaveChanges();
            context.Ratings.Add(samsungRatin2);
            context.SaveChanges();

            var dellRating = new Rating
            {
                Date = DateTime.Now,
                Rating1 = 2,
                FkUser = mobile,
                FkProduct = dell
            };
            var dellRating2 = new Rating
            {
                Date = DateTime.Now,
                Rating1 = 5,
                FkUser = mobile,
                FkProduct = dell
            };

            context.Ratings.Add(dellRating);
            context.SaveChanges();
            context.Ratings.Add(dellRating2);
            context.SaveChanges();


            var news = new News
            {
                Title = "Obavijest o zastoju",
                Content = "Mogući zastoji u radu aplikacije na dan 1.8.2021. godine",
                DateOfCreation = DateTime.Now,
                Active = true,
                FkUser = admin,
            };

            context.News.Add(news);
            context.SaveChanges();

            var suppliers = new List<Supplier> { new Supplier {
                Name ="Media export import",
                Active = true,
                BankAccount ="18765656",
                Description ="Media export",
                Email ="media@export.com",
                PhoneNumber ="222-333-444",
                WebAddress = "www.media-export.com"

            }, new Supplier
            {
                Name ="Ultracomp",
                Active = true,
                BankAccount ="187653453",
                Description ="Ultracomp",
                Email ="ultracomp@export.com",
                PhoneNumber ="212-313-441",
                WebAddress = "www.ultracomp.com"

            }
            };

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();


            var order = new Order
            {
                OrderNumber = 2,
                Active = false,
                Amount = 4000,
                Canceled = false,
                Confirmed = true,
                Date = DateTime.Now,
                FkUser = admin,
                FkSupplier = suppliers[1]
            };


            context.Orders.Add(order);
            context.SaveChanges();


            var orderItems = new List<OrderItem> { new OrderItem {

                FkOrder = order,
                Quantity = 100,
                Amount = 22000,
                FkProduct = samsung
            },
            new OrderItem
            {
                FkOrder = order,
                FkProduct = dell,
                Amount = 100000,
                Quantity = 105,
            },

            new OrderItem
            {
                FkProduct = apple,
                Amount = 50000,
                Quantity = 100,
                FkOrder =order
            }

            };

            context.OrderItems.AddRange(orderItems);
            context.SaveChanges();


            var buyerOrders = new List<BuyerOrder> { new BuyerOrder
            {
                OrderNumber =3,
                Active = false,
                Confirmed = true,
                Amount = 5200,
                Canceled = false,
                Date = DateTime.Now,
                FkUser =mobile
            }, new BuyerOrder
            {
                OrderNumber =2,
                Active = true,
                Confirmed = false,
                Amount = 3000,
                Canceled = false,
                Date = DateTime.Now,
                FkUser =mobile
            }
            };

            context.BuyerOrders.AddRange(buyerOrders);
            context.SaveChanges();


            var buyerOrderItems = new List<BuyerOrderItem> { new BuyerOrderItem
            {
                Amount =2200,
                FkBuyerOrderNavigation = buyerOrders[0],
                FkProduct = samsung,
                Quantity = 1
            }
            ,new BuyerOrderItem
            {
                Amount = 3000,
                FkBuyerOrderNavigation = buyerOrders[0],
                Quantity = 1,
                FkProduct = apple,
            }
             ,new BuyerOrderItem
            {
                Amount = 1000,
                FkBuyerOrderNavigation = buyerOrders[1],
                Quantity = 1,
                FkProduct = dell,
            }
             ,new BuyerOrderItem
            {
                Amount = 2200,
                FkBuyerOrderNavigation = buyerOrders[1],
                Quantity = 1,
                FkProduct = samsung,
            }
             ,new BuyerOrderItem
            {
                Amount = 3000,
                FkBuyerOrderNavigation = buyerOrders[1],
                Quantity = 1,
                FkProduct = apple,
            }

            };

            context.AddRange(buyerOrderItems);
            context.SaveChanges();


            var bills = new List<Bill> { new Bill
            {
                BillNumber = 1,
                Amount = 5200,
                AmountWithTax =6084,
                Closed = false,
                FkBuyerOrderNavigation = buyerOrders[0],
                FkUser = mobile,
                IssuingDate = DateTime.Now,
                Tax =17
            },
                new Bill
                {
                BillNumber = 2,
                Amount = 4000,
                AmountWithTax =4680,
                Closed = true,
                FkBuyerOrderNavigation = buyerOrders[1],
                FkUser = mobile,
                IssuingDate = DateTime.Now,
                Tax =17
                },
                new Bill
                {
                BillNumber = 3,
                Amount = 3000,
                AmountWithTax =3510,
                Closed = false,
                FkBuyerOrderNavigation = buyerOrders[1],
                FkUser = test,
                IssuingDate = DateTime.Now,
                Tax =17
                }
            };

            context.AddRange(bills);
            context.SaveChanges();


            var billItems = new List<BillItem> {  new BillItem
            {
                Discount = 10,
                FkBill = bills[0],
                Price = 2200,
                FkProduct = samsung,
                Quantity = 1
            }
            ,new BillItem
            {
                Discount = 10,
                FkBill = bills[0],
                Price = 3000,
                Quantity = 1,
                FkProduct = apple,
            }
             ,new BillItem
            {
                Discount = 10,
                FkBill = bills[1],
                Price = 1000,
                Quantity = 1,
                FkProduct = dell,
            }
             ,new BillItem
            {
                Discount = 10,
                FkBill = bills[1],
                Price = 2200,
                Quantity = 1,
                FkProduct = samsung,
            }
             ,new BillItem
            {
                Discount = 10,
                FkBill = bills[2],
                Price = 3000,
                Quantity = 1,
                FkProduct = apple,
            }

            };

            context.AddRange(billItems);
            context.SaveChanges();



            var offers = new Offer { 
                
                Active =true,
                DateFrom =DateTime.Now,
                DateTo = DateTime.Now.AddDays(30),
                Description = "Samsung S21 po super povoljnoj cijeni !",
                Title ="Super ponuda Samsung S21"
            };

            context.Add(offers);
            context.SaveChanges();


            var offerItems = new List<ProductOffer> { new ProductOffer
            {Discount =10,
            FkOffer = offers,
            FkProduct = samsung,
            PriceWithDiscount =2000
            } };

            context.AddRange(offerItems);
            context.SaveChanges();
        }






    }
}
