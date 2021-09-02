using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace superTech.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    WebAddress = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DateFrom = table.Column<DateTime>(type: "date", nullable: true),
                    DateTo = table.Column<DateTime>(type: "date", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WebAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "UnitsOfMeasure",
                columns: table => new
                {
                    UnitOfMeasureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UnitsOfM__F36083F1EE73BD8B", x => x.UnitOfMeasureId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "date", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FK_CityId = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK__Users__FK_CityId__3B75D760",
                        column: x => x.FK_CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    ImageThumb = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    FK_UnitOfMeasureId = table.Column<int>(type: "int", nullable: true),
                    FK_CategoryId = table.Column<int>(type: "int", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Products__BrandI__160F4887",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Products__FK_Cat__4BAC3F29",
                        column: x => x.FK_CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Products__FK_Uni__4AB81AF0",
                        column: x => x.FK_UnitOfMeasureId,
                        principalTable: "UnitsOfMeasure",
                        principalColumn: "UnitOfMeasureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyerOrders",
                columns: table => new
                {
                    BuyerOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Canceled = table.Column<bool>(type: "bit", nullable: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: true),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerOrders", x => x.BuyerOrderId);
                    table.ForeignKey(
                        name: "FK__BuyerOrde__FK_Us__5812160E",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "date", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK__News__FK_UserId__440B1D61",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: true),
                    FK_SupplierId = table.Column<int>(type: "int", nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: true),
                    Canceled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__Orders__FK_Suppl__693CA210",
                        column: x => x.FK_SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Orders__FK_UserI__68487DD7",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfModification = table.Column<DateTime>(type: "datetime", nullable: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: true),
                    FK_RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UsersRol__3D978A354EF9B121", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK__UsersRole__FK_Ro__412EB0B6",
                        column: x => x.FK_RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UsersRole__FK_Us__403A8C7D",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOffers",
                columns: table => new
                {
                    ProductOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceWithDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FK_ProductId = table.Column<int>(type: "int", nullable: true),
                    FK_OfferId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOffers", x => x.ProductOfferId);
                    table.ForeignKey(
                        name: "FK__ProductOf__FK_Of__5535A963",
                        column: x => x.FK_OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ProductOf__FK_Pr__5441852A",
                        column: x => x.FK_ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    FK_UserId = table.Column<int>(type: "int", nullable: true),
                    FK_ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK__Ratings__FK_Prod__4F7CD00D",
                        column: x => x.FK_ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Ratings__FK_User__4E88ABD4",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    BillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillNumber = table.Column<int>(type: "int", nullable: false),
                    IssuingDate = table.Column<DateTime>(type: "date", nullable: false),
                    Closed = table.Column<bool>(type: "bit", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountWithTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FK_UserId = table.Column<int>(type: "int", nullable: true),
                    FK_BuyerOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.BillId);
                    table.ForeignKey(
                        name: "FK__Bills__FK_BuyerO__5FB337D6",
                        column: x => x.FK_BuyerOrder,
                        principalTable: "BuyerOrders",
                        principalColumn: "BuyerOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Bills__FK_UserId__5EBF139D",
                        column: x => x.FK_UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuyerOrderItems",
                columns: table => new
                {
                    BuyerOrderItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    FK_ProductId = table.Column<int>(type: "int", nullable: true),
                    FK_BuyerOrder = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BuyerOrd__8E1D118BEDBD0F49", x => x.BuyerOrderItemsId);
                    table.ForeignKey(
                        name: "FK__BuyerOrde__FK_Bu__5BE2A6F2",
                        column: x => x.FK_BuyerOrder,
                        principalTable: "BuyerOrders",
                        principalColumn: "BuyerOrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__BuyerOrde__FK_Pr__5AEE82B9",
                        column: x => x.FK_ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FK_OrderId = table.Column<int>(type: "int", nullable: true),
                    FK_ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK__OrderItem__FK_Or__6C190EBB",
                        column: x => x.FK_OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__OrderItem__FK_Pr__6D0D32F4",
                        column: x => x.FK_ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillItems",
                columns: table => new
                {
                    BillItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    FK_BillId = table.Column<int>(type: "int", nullable: true),
                    FK_ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillItems", x => x.BillItemId);
                    table.ForeignKey(
                        name: "FK__BillItems__FK_Bi__628FA481",
                        column: x => x.FK_BillId,
                        principalTable: "Bills",
                        principalColumn: "BillId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__BillItems__FK_Pr__6383C8BA",
                        column: x => x.FK_ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_FK_BillId",
                table: "BillItems",
                column: "FK_BillId");

            migrationBuilder.CreateIndex(
                name: "IX_BillItems_FK_ProductId",
                table: "BillItems",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_FK_BuyerOrder",
                table: "Bills",
                column: "FK_BuyerOrder");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_FK_UserId",
                table: "Bills",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerOrderItems_FK_BuyerOrder",
                table: "BuyerOrderItems",
                column: "FK_BuyerOrder");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerOrderItems_FK_ProductId",
                table: "BuyerOrderItems",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerOrders_FK_UserId",
                table: "BuyerOrders",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_News_FK_UserId",
                table: "News",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FK_OrderId",
                table: "OrderItems",
                column: "FK_OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FK_ProductId",
                table: "OrderItems",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_SupplierId",
                table: "Orders",
                column: "FK_SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FK_UserId",
                table: "Orders",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOffers_FK_OfferId",
                table: "ProductOffers",
                column: "FK_OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOffers_FK_ProductId",
                table: "ProductOffers",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FK_CategoryId",
                table: "Products",
                column: "FK_CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FK_UnitOfMeasureId",
                table: "Products",
                column: "FK_UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FK_ProductId",
                table: "Ratings",
                column: "FK_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FK_UserId",
                table: "Ratings",
                column: "FK_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_FK_CityId",
                table: "Users",
                column: "FK_CityId");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__A9D1053469742187",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Users__C9F28456803E0209",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_FK_RoleId",
                table: "UsersRoles",
                column: "FK_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_FK_UserId",
                table: "UsersRoles",
                column: "FK_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillItems");

            migrationBuilder.DropTable(
                name: "BuyerOrderItems");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductOffers");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "BuyerOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UnitsOfMeasure");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
