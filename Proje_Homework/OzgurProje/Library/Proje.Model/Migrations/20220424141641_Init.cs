using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proje.Model.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    BrandName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    CityCode = table.Column<int>(nullable: false),
                    CityName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "County",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    CountyCode = table.Column<int>(nullable: false),
                    CountyName = table.Column<string>(maxLength: 50, nullable: false),
                    CityCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_County", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ShortName = table.Column<string>(maxLength: 10, nullable: false),
                    LongName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandReason",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Reason = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandReason", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DemandStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Distributor",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    ContactPerson = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumberTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumberTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 12, nullable: false),
                    LastIPAdress = table.Column<string>(maxLength: 15, nullable: true),
                    LastLogin = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    Price1 = table.Column<decimal>(nullable: false),
                    Warranty = table.Column<int>(nullable: false),
                    StockAmount = table.Column<decimal>(nullable: false),
                    Distributor = table.Column<string>(maxLength: 100, nullable: true),
                    Gift = table.Column<string>(maxLength: 100, nullable: true),
                    ShortDetails = table.Column<string>(maxLength: 200, nullable: true),
                    VolumetricWeight = table.Column<decimal>(nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    TypeName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AddressType_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AddressType_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BrandToCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false),
                    BrandId = table.Column<Guid>(nullable: false),
                    BrandName = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrandToCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrandToCategories_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandToCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrandToCategories_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrandToCategories_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cart_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cart_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    CurrencyId = table.Column<Guid>(nullable: false),
                    ShortName = table.Column<string>(maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    BuyingPrice = table.Column<decimal>(nullable: false),
                    SalePrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyValue_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrencyValue_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MemberAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    UserSurName = table.Column<string>(maxLength: 255, nullable: true),
                    UserPhoneNumber = table.Column<string>(maxLength: 32, nullable: true),
                    TCLD = table.Column<string>(maxLength: 32, nullable: true),
                    TaxNumber = table.Column<string>(maxLength: 50, nullable: true),
                    TaxOffice = table.Column<string>(maxLength: 50, nullable: true),
                    AddressName = table.Column<string>(maxLength: 50, nullable: false),
                    AddressTypeId = table.Column<Guid>(nullable: false),
                    CityCode = table.Column<int>(nullable: false),
                    CountyCode = table.Column<int>(nullable: false),
                    Address = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberAddress_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberAddress_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OptionGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionGroup_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionGroup_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentGateway",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentGateway", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentGateway_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentGateway_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentStatus_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentStatus_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PaymentType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentType_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PaymentType_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Number = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumberType = table.Column<string>(maxLength: 50, nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingCompanys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ExtraPrice = table.Column<decimal>(nullable: false),
                    ExtraVolumetricWeightPrice = table.Column<decimal>(nullable: false),
                    FreeShipmentOrderPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCompanys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingCompanys_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShippingCompanys_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecGroup",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    SpecGroupName = table.Column<string>(maxLength: 50, nullable: false),
                    ShortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecGroup_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecGroup_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DistributorToProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    DistributorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorToProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributorToProduct_Distributor_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DistributorToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritedProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritedProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritedProduct_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavouritedProduct_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavouritedProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Content = table.Column<string>(maxLength: 65535, nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComment_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComment_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductComment_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductComment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 250, nullable: false),
                    Details = table.Column<string>(maxLength: 65535, nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Revision = table.Column<string>(maxLength: 50, nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    CartId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItem_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    CustomerFirstname = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerSurname = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerEmail = table.Column<string>(maxLength: 250, nullable: true),
                    CustomerPhone = table.Column<string>(maxLength: 32, nullable: true),
                    PaymentTypeName = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentGatewayName = table.Column<string>(maxLength: 50, nullable: false),
                    PaymentGatewayCode = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    OrderStatus = table.Column<string>(maxLength: 50, nullable: false),
                    ErrorMessage = table.Column<string>(maxLength: 50, nullable: true),
                    GiftNote = table.Column<string>(maxLength: 250, nullable: true),
                    ShippingCompanyName = table.Column<string>(maxLength: 250, nullable: true),
                    ShippingTrackingCode = table.Column<string>(maxLength: 250, nullable: true),
                    ShippingAddressId = table.Column<Guid>(nullable: true),
                    BillingAddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_MemberAddress_BillingAddressId",
                        column: x => x.BillingAddressId,
                        principalTable: "MemberAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_MemberAddress_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "MemberAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(maxLength: 255, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    OptionGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Options_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Options_OptionGroup_OptionGroupId",
                        column: x => x.OptionGroupId,
                        principalTable: "OptionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Installment = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    PaymentGatewayId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentRate_PaymentGateway_PaymentGatewayId",
                        column: x => x.PaymentGatewayId,
                        principalTable: "PaymentGateway",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    UserFirstname = table.Column<string>(maxLength: 250, nullable: false),
                    UserSurname = table.Column<string>(maxLength: 255, nullable: false),
                    UserEmail = table.Column<string>(maxLength: 255, nullable: false),
                    UserPhone = table.Column<string>(maxLength: 50, nullable: true),
                    PaymentTypeName = table.Column<string>(maxLength: 255, nullable: true),
                    PaymentGatewayName = table.Column<string>(maxLength: 255, nullable: false),
                    PaymentGatewayCode = table.Column<string>(maxLength: 255, nullable: false),
                    FinalAmount = table.Column<decimal>(maxLength: 255, nullable: false),
                    SumOfGainedPoints = table.Column<decimal>(nullable: false),
                    Installment = table.Column<int>(nullable: false),
                    InstallmentRate = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: false),
                    UserNote = table.Column<string>(maxLength: 255, nullable: true),
                    PaymentStatusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecName",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    ShortOrder = table.Column<int>(nullable: false),
                    SpecGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecName_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecName_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecName_SpecGroup_SpecGroupId",
                        column: x => x.SpecGroupId,
                        principalTable: "SpecGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ProductName = table.Column<string>(maxLength: 255, nullable: false),
                    ProductWeight = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderRefundDemand",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Reason = table.Column<string>(maxLength: 50, nullable: false),
                    Details = table.Column<string>(maxLength: 255, nullable: false),
                    ResultStatus = table.Column<string>(maxLength: 50, nullable: false),
                    Fee = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRefundDemand", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderRefundDemand_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRefundDemand_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRefundDemand_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderRefundDemand_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionToProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ParentProductId = table.Column<Guid>(nullable: false),
                    OptionGroupId = table.Column<Guid>(nullable: false),
                    OptionId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionToProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionToProduct_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionToProduct_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OptionToProduct_OptionGroup_OptionGroupId",
                        column: x => x.OptionGroupId,
                        principalTable: "OptionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionToProduct_Options_OptionId",
                        column: x => x.OptionId,
                        principalTable: "Options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Slug = table.Column<string>(maxLength: 255, nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    SpecNameId = table.Column<Guid>(nullable: false),
                    SpecGroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecValue_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecValue_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecValue_SpecGroup_SpecGroupId",
                        column: x => x.SpecGroupId,
                        principalTable: "SpecGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecValue_SpecName_SpecNameId",
                        column: x => x.SpecNameId,
                        principalTable: "SpecName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecToProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedIP = table.Column<string>(maxLength: 15, nullable: true),
                    CreatedUserId = table.Column<Guid>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedComputer = table.Column<string>(maxLength: 255, nullable: true),
                    ModifiedIP = table.Column<string>(maxLength: 15, nullable: true),
                    ModifiedUserId = table.Column<Guid>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: false),
                    SpecGroupId = table.Column<Guid>(nullable: false),
                    SpecNameId = table.Column<Guid>(nullable: false),
                    SpecValueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecToProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecToProduct_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecToProduct_Users_ModifiedUserId",
                        column: x => x.ModifiedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SpecToProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecToProduct_SpecGroup_SpecGroupId",
                        column: x => x.SpecGroupId,
                        principalTable: "SpecGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecToProduct_SpecName_SpecNameId",
                        column: x => x.SpecNameId,
                        principalTable: "SpecName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecToProduct_SpecValue_SpecValueId",
                        column: x => x.SpecValueId,
                        principalTable: "SpecValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Status", "TypeName" },
                values: new object[,]
                {
                    { new Guid("6278fe0e-4e04-4dbe-b2d8-d6d2df22694d"), null, null, null, null, null, null, null, null, 1, "Ev Adresi" },
                    { new Guid("ef7428eb-9c56-49ce-907c-209ea650ac38"), null, null, null, null, null, null, null, null, 1, "İş Adresi" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "BrandName", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "Description", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("70291557-c137-4c6f-bd73-874ccc8d2994"), "Mavi", null, null, null, null, "Spor Giyim", null, null, null, null, 1 },
                    { new Guid("781a5242-96f5-463b-823e-ec601fdcd591"), "Koton", null, null, null, null, "Günlük Giyim", null, null, null, null, 1 },
                    { new Guid("91c05f73-4a1b-4256-84a0-3d6fe6ee46d3"), "Nike", null, null, null, null, "Spor Giyim", null, null, null, null, 1 },
                    { new Guid("d9913b9a-6d9f-4ecc-8562-e3fd687b7485"), "Adidas", null, null, null, null, "Spor Giyim", null, null, null, null, 1 },
                    { new Guid("ecb44058-2977-47b0-b143-abadddaa2e77"), "Polo", null, null, null, null, "Spor Giyim", null, null, null, null, 1 },
                    { new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), "Kiğılı", null, null, null, null, "Klasik Giyim", null, null, null, null, 1 },
                    { new Guid("3acb9af2-4983-45c8-9081-f6233a77f537"), "Pierre Cardin", null, null, null, null, "Klasik Giyim", null, null, null, null, 1 },
                    { new Guid("1d67d426-77d0-4359-9c8b-804c0d7890ff"), "Altın Yıldız", null, null, null, null, "Klasik Giyim", null, null, null, null, 1 },
                    { new Guid("2656565c-b55c-4996-8216-9ab2daa41792"), "Puma", null, null, null, null, "Spor Giyim", null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "Description", "ImageUrl", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), "Gömlek", null, null, null, null, "Günlük Giyim", "/", null, null, null, null, 1 },
                    { new Guid("6e5250ef-ca5a-4c6c-9c24-03bd5f16e854"), "Takım Elbise", null, null, null, null, "Klasik Giyim", "/", null, null, null, null, 1 },
                    { new Guid("6d66bd90-dabf-46a9-b75b-f206fbe5c7d9"), "Spor Ayakkabı", null, null, null, null, "Spor Giyim", "/", null, null, null, null, 1 },
                    { new Guid("8678a844-6811-4018-821c-a499d7a7761c"), "Eşofman", null, null, null, null, "Spor Giyim", "/", null, null, null, null, 1 },
                    { new Guid("220e9662-88cc-4b24-8c40-80d423553615"), "Kazak", null, null, null, null, "Günlük Giyim", "/", null, null, null, null, 1 },
                    { new Guid("74368c62-c748-483e-8b38-9a4302d32922"), "Pantolon", null, null, null, null, "Günlük Giyim", "/", null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CityCode", "CityName", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("ee05e832-798f-4ef3-9e75-cec81a015103"), 6, "Ankara", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("f1646e31-cae1-41c7-b7fa-5900651c5e69"), 34, "İstanbul", null, null, null, null, null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "County",
                columns: new[] { "Id", "CityCode", "CountyCode", "CountyName", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("e0ec0e46-1db0-4133-a1cf-6f98e28f6d5d"), 34, 9, "Kadıköy", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("ae1aebd8-c181-4464-8d96-808f4f47f196"), 6, 14, "Gölbaşı", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("2aae8f9f-3ea8-45a8-8bb2-10abe0cbfd5f"), 6, 13, "Demet Evler", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("7d0137d0-befe-4efa-84f9-1630a0217af3"), 6, 12, "Yeni Mahalle", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("4c3e1b47-2216-4e50-a214-c32ae2ee40e9"), 6, 11, "Sıhhıye", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("37073e80-ca18-4f49-b4b6-99eaeb67c9d8"), 6, 10, "Çankaya", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("20c3a4d8-42fa-42b9-a591-5cd12d52b94c"), 34, 8, "Fatih", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("a65a4934-a7a6-4f62-8f50-01be9b04d74b"), 34, 6, "Taksim", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("0191008f-672f-4754-83df-4330bad1eb52"), 34, 5, "Şişli", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("4cf528cc-8f34-4534-9229-c1e0fb7e533f"), 34, 4, "Beşktaş", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("da129d37-e7be-4340-987c-46a7c20429e2"), 34, 3, "Esenler", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("09aa8046-8f90-4f92-bdfe-f27fe643fef6"), 34, 2, "SarıYer", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("fd9f5f98-b7ec-4f3c-b256-2b32c1156f3f"), 34, 1, "Kağıthane", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("c909881e-4437-407e-bc64-15f350b45b2c"), 34, 7, "Bakırköy", null, null, null, null, null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "LongName", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "ShortName", "Status" },
                values: new object[,]
                {
                    { new Guid("acf0f314-3b7d-4d2c-bca7-7b0a195ce8a2"), null, null, null, null, "EURO", null, null, null, null, "EUR", 1 },
                    { new Guid("7b4fba26-c678-4b08-a43c-38ccdbe594ee"), null, null, null, null, "TÜRK LİRASI", null, null, null, null, "TL", 1 },
                    { new Guid("dc2dc16f-529a-4276-aa00-436bf2ca5b7f"), null, null, null, null, "DOLAR", null, null, null, null, "USD", 1 }
                });

            migrationBuilder.InsertData(
                table: "DemandReason",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Reason", "Status" },
                values: new object[,]
                {
                    { new Guid("bb16690b-9345-4fdb-bd45-f5f965cd3731"), null, null, null, null, null, null, null, null, "Diğer", 1 },
                    { new Guid("665f138d-3e77-495e-b2c7-3847f91545e2"), null, null, null, null, null, null, null, null, "Siparişimdeki Ürünler İle Gelen Ürünler Farklı", 1 },
                    { new Guid("21545434-6b7a-4235-b731-2ca45c187a24"), null, null, null, null, null, null, null, null, "Ürünü Değiştirmek İstiyorum", 1 },
                    { new Guid("9002b034-2862-4024-a2a2-12e287fb2c7c"), null, null, null, null, null, null, null, null, "Faturadaki Ürünler İle Gelen Ürünler Farklı", 1 },
                    { new Guid("f2b1dab9-d45d-4763-8970-48034a2d5f44"), null, null, null, null, null, null, null, null, "Ürünü İade Etmek İstiyorum", 1 }
                });

            migrationBuilder.InsertData(
                table: "DemandStatus",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("1d4a24ea-6cf0-4836-8777-94c8bba7e7da"), null, null, null, null, null, null, null, null, "Onay Bekliyor", 1 },
                    { new Guid("9c6dfb14-2d90-4f14-a0ce-c3b0e4c0f778"), null, null, null, null, null, null, null, null, "Onaylandı", 1 },
                    { new Guid("8a138711-7a9c-46bc-8ff4-b7fe87c86da3"), null, null, null, null, null, null, null, null, "İptal Edildi", 1 }
                });

            migrationBuilder.InsertData(
                table: "Distributor",
                columns: new[] { "Id", "ContactPerson", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "Email", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Phone", "Status" },
                values: new object[,]
                {
                    { new Guid("1852023f-2032-4954-af86-11fe9a21f609"), "Burak KIRMIZI", null, null, null, null, "samsung@samsung.com", null, null, null, null, "Samsung İstanbul Şube", "0555 555-55-59", 1 },
                    { new Guid("8db88a18-19ad-4648-a62a-9ff6c7080311"), "Burak SARI", null, null, null, null, "kigili@kigili.com", null, null, null, null, "Kiğılı İstanbul Şube", "0555 555-55-57", 1 },
                    { new Guid("263fa307-8b12-414f-8f7b-c5f359545150"), "Burak MAVİ", null, null, null, null, "nike@nike.com", null, null, null, null, "Nike İstanbul Şube", "0555 555-55-58", 1 },
                    { new Guid("6cfc425a-cea6-4079-b123-5b8116c55ad9"), "Burak YEŞİL", null, null, null, null, "altınyıldız@altınyıldız.com", null, null, null, null, "Altın Yıldız İstanbul Şube", "0555 555-55-55", 1 },
                    { new Guid("d32fcf25-4d38-4d99-b1e5-c3cab7606807"), "Burak KARA", null, null, null, null, "coton@coton.com", null, null, null, null, "Coton İstanbul Şube", "0555 555-55-56", 1 }
                });

            migrationBuilder.InsertData(
                table: "OptionGroup",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Slug", "SortOrder", "Status", "Title" },
                values: new object[] { new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), null, null, null, null, null, null, null, null, "Mevcut Diğer Renkler", 1, 1, "Renk" });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("1e2c06a2-188a-4ec9-948f-955966c1cd6d"), null, null, null, null, null, null, null, null, "Onay Bekliyor", 0 },
                    { new Guid("8f6c05a4-a7ad-4d74-b264-5514baadef13"), null, null, null, null, null, null, null, null, "Silindi", 0 },
                    { new Guid("be10f111-f4f6-4d58-9807-ec8c433d6b22"), null, null, null, null, null, null, null, null, "Siparişiniz Hazırlanıyor", 0 },
                    { new Guid("f00ad7dc-f3fe-4951-bda3-b90a6e29259d"), null, null, null, null, null, null, null, null, "İptal Edildi", 0 },
                    { new Guid("1d8c4aeb-ee04-4f5d-90b7-aee14b783b88"), null, null, null, null, null, null, null, null, "İade Edildi", 0 },
                    { new Guid("719d6e39-aee9-49f9-bfcf-dba7e28c0293"), null, null, null, null, null, null, null, null, "Kargoya Verildi", 0 }
                });

            migrationBuilder.InsertData(
                table: "PaymentGateway",
                columns: new[] { "Id", "Code", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("35af2ff3-8b97-43f3-8176-59982291b012"), "FnsBnk", null, null, null, null, null, null, null, null, "Finans Bank", 2, 1 },
                    { new Guid("eb183c77-cc12-45e0-9792-57f2318ddf71"), "VkfBnk", null, null, null, null, null, null, null, null, "Vakıf Bank", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentStatus",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("922f400a-9743-4508-80cf-c6c3bbb385c0"), null, null, null, null, null, null, null, null, "Onay Bekliyor", 0 },
                    { new Guid("06cbd5dc-b443-46c7-b984-1af819ac8453"), null, null, null, null, null, null, null, null, "Silindi", 0 },
                    { new Guid("294543a1-b385-4768-beda-cabcd5862364"), null, null, null, null, null, null, null, null, "Onaylandı", 0 },
                    { new Guid("5ade7dba-64ea-4de5-b624-3d599c29c066"), null, null, null, null, null, null, null, null, "İptal Edildi", 0 },
                    { new Guid("138679af-6368-4097-94a7-6c944f79cc24"), null, null, null, null, null, null, null, null, "İade Edildi", 0 },
                    { new Guid("c5273b25-59ea-4964-a4ed-099aef91a706"), null, null, null, null, null, null, null, null, "Hatalı Ödeme", 0 }
                });

            migrationBuilder.InsertData(
                table: "PaymentType",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("0d051727-896b-4c86-bfb5-980af28cdbc4"), null, null, null, null, null, null, null, null, "Kredi Kartı", 1 },
                    { new Guid("43d849a2-feba-4a79-aa14-6adcfdb19916"), null, null, null, null, null, null, null, null, "Hediye Çeki", 1 }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumberTypes",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("4726a3aa-3a0c-4ff3-b684-9b2c6766329e"), null, null, null, null, null, null, null, null, "Ev Telefonu", 1 },
                    { new Guid("fb820515-4fe0-45fb-8f52-501478dde166"), null, null, null, null, null, null, null, null, "İş Telefonu", 1 },
                    { new Guid("73738da4-b457-48cb-b35d-3f2f469614e4"), null, null, null, null, null, null, null, null, "Cep Telefonu", 1 },
                    { new Guid("58fad403-9c67-481b-a722-8ba260391e52"), null, null, null, null, null, null, null, null, "Fax", 1 },
                    { new Guid("69649c24-512c-463b-add1-25ec970d3d9e"), null, null, null, null, null, null, null, null, "Diğer", 1 }
                });

            migrationBuilder.InsertData(
                table: "ShippingCompanys",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ExtraPrice", "ExtraVolumetricWeightPrice", "FreeShipmentOrderPrice", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("db5fb4ab-653a-4d26-8346-b067b6ef5d44"), null, null, null, null, 10m, 1m, 100m, null, null, null, null, "Aras Kargo", 1 },
                    { new Guid("ed1f9d0a-87f4-4634-a9a6-40120a277bbf"), null, null, null, null, 11m, 1m, 100m, null, null, null, null, "PTT", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "Email", "FirstName", "ImageUrl", "LastIPAdress", "LastLogin", "LastName", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Password", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("9c0622f8-8a2a-4f16-8270-985e4fbf5762"), null, null, null, null, "admin@admin.com", "Admin", "/", "127.0.0.1", new DateTime(2022, 4, 24, 17, 16, 40, 149, DateTimeKind.Local).AddTicks(8768), "ADMIN", null, null, null, null, "123", 1, "Admin" },
                    { new Guid("cde63b92-aa7a-4c6e-949b-f8c4ab17f203"), null, null, null, null, "ozgur@ozgur.com", "Ozgur", "/", "127.0.0.1", new DateTime(2022, 4, 24, 17, 16, 40, 151, DateTimeKind.Local).AddTicks(4207), "EVREN", null, null, null, null, "123", 1, "Normal" }
                });

            migrationBuilder.InsertData(
                table: "BrandToCategories",
                columns: new[] { "Id", "BrandId", "BrandName", "CategoryId", "CategoryName", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Status" },
                values: new object[,]
                {
                    { new Guid("42ebec42-cdb6-4119-b9bb-bd4d31ed0645"), new Guid("1d67d426-77d0-4359-9c8b-804c0d7890ff"), "Altın Yıldız", new Guid("6e5250ef-ca5a-4c6c-9c24-03bd5f16e854"), "Takım Elbise", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("cf31a578-2636-4b08-8870-45ca237150a8"), new Guid("70291557-c137-4c6f-bd73-874ccc8d2994"), "Mavi", new Guid("74368c62-c748-483e-8b38-9a4302d32922"), "Pantolon", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("a1c7aeca-378e-4ea6-88c7-7c57eee5c472"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), "Kiğılı", new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), "Kazak", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("3ca840a1-11a1-47a9-bb29-91723f43f725"), new Guid("781a5242-96f5-463b-823e-ec601fdcd591"), "Koton", new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), "Kazak", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("64570dd2-b796-44ce-a8d6-fa41ea0ca738"), new Guid("70291557-c137-4c6f-bd73-874ccc8d2994"), "Mavi", new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), "Kazak", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("e98a356f-8e09-4eb1-adb4-8ad4aa34b429"), new Guid("781a5242-96f5-463b-823e-ec601fdcd591"), "Koton", new Guid("74368c62-c748-483e-8b38-9a4302d32922"), "Pantolon", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("315da381-0dd0-4f41-bf86-344633676b19"), new Guid("70291557-c137-4c6f-bd73-874ccc8d2994"), "Mavi", new Guid("220e9662-88cc-4b24-8c40-80d423553615"), "Kazak", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("fbbc0469-f74c-4c04-93c4-c6b2806bf078"), new Guid("781a5242-96f5-463b-823e-ec601fdcd591"), "Koton", new Guid("220e9662-88cc-4b24-8c40-80d423553615"), "Kazak", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("2f543e58-25c4-4f78-b9c9-3da55714bd90"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), "Kiğılı", new Guid("74368c62-c748-483e-8b38-9a4302d32922"), "Pantolon", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("846927ce-575d-4829-9184-0e5780d01208"), new Guid("d9913b9a-6d9f-4ecc-8562-e3fd687b7485"), "Adidas", new Guid("8678a844-6811-4018-821c-a499d7a7761c"), "Eşofman", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("e8dcb570-00ed-4535-99b2-55262224a077"), new Guid("2656565c-b55c-4996-8216-9ab2daa41792"), "Puma", new Guid("8678a844-6811-4018-821c-a499d7a7761c"), "Eşofman", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("b4f42fec-188a-429d-a166-2c3ea5b3f379"), new Guid("91c05f73-4a1b-4256-84a0-3d6fe6ee46d3"), "Nike", new Guid("6d66bd90-dabf-46a9-b75b-f206fbe5c7d9"), "Spor Ayakkabı", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("92a2f3e9-19ac-4541-a9d9-a2f78544c20d"), new Guid("d9913b9a-6d9f-4ecc-8562-e3fd687b7485"), "Adidas", new Guid("6d66bd90-dabf-46a9-b75b-f206fbe5c7d9"), "Spor Ayakkabı", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("8ad8b0fa-f7fa-4fdc-9869-d800d433ec47"), new Guid("2656565c-b55c-4996-8216-9ab2daa41792"), "Puma", new Guid("6d66bd90-dabf-46a9-b75b-f206fbe5c7d9"), "Spor Ayakkabı", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("00209cdb-6436-41e2-b6aa-927415501ad2"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), "Kiğılı", new Guid("6e5250ef-ca5a-4c6c-9c24-03bd5f16e854"), "Takım Elbise", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("3108c411-5107-4c40-8cbc-2dad9b57890f"), new Guid("3acb9af2-4983-45c8-9081-f6233a77f537"), "Pierre Cardin", new Guid("6e5250ef-ca5a-4c6c-9c24-03bd5f16e854"), "Takım Elbise", null, null, null, null, null, null, null, null, 1 },
                    { new Guid("d100a69e-4e1b-4e32-9365-58361a163233"), new Guid("91c05f73-4a1b-4256-84a0-3d6fe6ee46d3"), "Nike", new Guid("8678a844-6811-4018-821c-a499d7a7761c"), "Eşofman", null, null, null, null, null, null, null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "InstallmentRate",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "Installment", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "PaymentGatewayId", "Rate", "Status" },
                values: new object[,]
                {
                    { new Guid("bcbb2945-7340-4c66-9fe5-54d4da5465fc"), null, null, null, null, 3, null, null, null, null, new Guid("35af2ff3-8b97-43f3-8176-59982291b012"), 0.15m, 1 },
                    { new Guid("918d7196-ec1d-4fe0-a8d4-72df98ecf433"), null, null, null, null, 15, null, null, null, null, new Guid("eb183c77-cc12-45e0-9792-57f2318ddf71"), 0.30m, 1 },
                    { new Guid("6a23d070-9303-445c-87ad-92624cae21df"), null, null, null, null, 12, null, null, null, null, new Guid("eb183c77-cc12-45e0-9792-57f2318ddf71"), 0.25m, 1 },
                    { new Guid("fadaac3d-a3ae-42cd-94a1-d980917518ba"), null, null, null, null, 9, null, null, null, null, new Guid("eb183c77-cc12-45e0-9792-57f2318ddf71"), 0.23m, 1 },
                    { new Guid("df5846fa-84d6-4d4b-b47e-60b847cc1c3a"), null, null, null, null, 6, null, null, null, null, new Guid("eb183c77-cc12-45e0-9792-57f2318ddf71"), 0.20m, 1 },
                    { new Guid("c86c8cb4-4a3f-478a-9375-6efe790ae864"), null, null, null, null, 3, null, null, null, null, new Guid("eb183c77-cc12-45e0-9792-57f2318ddf71"), 0.18m, 1 },
                    { new Guid("415dd76e-8d3d-4ac8-a9bd-c4e24e7ba45f"), null, null, null, null, 6, null, null, null, null, new Guid("35af2ff3-8b97-43f3-8176-59982291b012"), 0.18m, 1 },
                    { new Guid("89d4e81c-7632-4c90-8e12-9b265b9baaee"), null, null, null, null, 15, null, null, null, null, new Guid("35af2ff3-8b97-43f3-8176-59982291b012"), 0.32m, 1 },
                    { new Guid("41effd73-3624-4185-a8eb-a37cd830585c"), null, null, null, null, 10, null, null, null, null, new Guid("35af2ff3-8b97-43f3-8176-59982291b012"), 0.22m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "OptionGroupId", "Slug", "SortOrder", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("ef12cea5-7ade-4f57-87f2-dadac3112c0b"), null, null, null, null, null, null, null, null, new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), "", 1, 1, "Kırmızı" },
                    { new Guid("d41b5341-0ad0-4e5f-9108-44a669cd7024"), null, null, null, null, null, null, null, null, new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), "", 2, 1, "Beyaz" },
                    { new Guid("42c7bebc-e7df-4de2-9ce4-9227451a2f5c"), null, null, null, null, null, null, null, null, new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), "", 3, 1, "Mavi" },
                    { new Guid("ac5ea607-20e2-4ced-889c-d229814d55aa"), null, null, null, null, null, null, null, null, new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), "", 4, 1, "Yeşil" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "BuyingPrice", "CategoryId", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "Distributor", "Gift", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "Price1", "ProductName", "ShortDetails", "Status", "StockAmount", "VolumetricWeight", "Warranty" },
                values: new object[,]
                {
                    { new Guid("5acb9af2-4983-45c8-9081-f6233a77f555"), new Guid("3acb9af2-4983-45c8-9081-f6233a77f537"), 199m, new Guid("74368c62-c748-483e-8b38-9a4302d32922"), null, null, null, null, null, null, null, null, null, null, 300m, "Kumaş Pantolon", "KUMAŞ PANTOLON", 1, 100m, 1m, 1 },
                    { new Guid("c98b184b-0fa0-4633-bb5f-cfbcc7b0e45b"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), 124m, new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), null, null, null, null, null, null, null, null, null, null, 250m, "Kırmızı Gömlek", "MAVİ KLASİK GÖMLEK", 1, 100m, 1m, 1 },
                    { new Guid("7acb9af2-4983-45c8-9081-f6233a77f777"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), 89m, new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), null, null, null, null, null, null, null, null, null, null, 200m, "Siyah Gömlek", "BEYAZ KLASİK GÖMLEK", 1, 100m, 1m, 1 },
                    { new Guid("6acb9af2-4983-45c8-9081-f6233a77f666"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), 89m, new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), null, null, null, null, null, null, null, null, null, null, 200m, "Beyaz Gömlek", "BEYAZ KLASİK GÖMLEK", 1, 100m, 1m, 1 },
                    { new Guid("3acb9af2-4983-45c8-9081-f6233a77f333"), new Guid("1d67d426-77d0-4359-9c8b-804c0d7890ff"), 100m, new Guid("220e9662-88cc-4b24-8c40-80d423553615"), null, null, null, null, null, null, null, null, null, null, 200m, "Kırmızı Kazak", "KIRMIZI KIŞLIK KAZAK", 1, 100m, 1.3m, 1 },
                    { new Guid("2acb9af2-4983-45c8-9081-f6233a77f222"), new Guid("1d67d426-77d0-4359-9c8b-804c0d7890ff"), 100m, new Guid("220e9662-88cc-4b24-8c40-80d423553615"), null, null, null, null, null, null, null, null, null, null, 200m, "Beyaz Kazak", "BEYAZ KIŞLIK KAZAK", 1, 100m, 1.3m, 1 },
                    { new Guid("1acb9af2-4983-45c8-9081-f6233a77f111"), new Guid("1d67d426-77d0-4359-9c8b-804c0d7890ff"), 100m, new Guid("220e9662-88cc-4b24-8c40-80d423553615"), null, null, null, null, null, null, null, null, null, null, 200m, "Siyah Kazak", "SİYAH KIŞLIK KAZAK", 1, 100m, 1.2m, 1 },
                    { new Guid("4acb9af2-4983-45c8-9081-f6233a77f444"), new Guid("70291557-c137-4c6f-bd73-874ccc8d2994"), 99m, new Guid("74368c62-c748-483e-8b38-9a4302d32922"), null, null, null, null, null, null, null, null, null, null, 200m, "Kot Pantolon", "KOT PANTOLON", 1, 100m, 1.2m, 1 },
                    { new Guid("8acb9af2-4983-45c8-9081-f6233a77f888"), new Guid("5819fd74-7ad3-4ac0-89e1-48f7a06e87e5"), 89m, new Guid("ff670e2d-c83c-4def-b5b7-35595a3c26cc"), null, null, null, null, null, null, null, null, null, null, 200m, "Mavi Gömlek", "MAVİ KLASİK GÖMLEK", 1, 100m, 1m, 1 }
                });

            migrationBuilder.InsertData(
                table: "DistributorToProduct",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "DistributorId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "ProductId", "Status" },
                values: new object[,]
                {
                    { new Guid("4e99dc58-b8d1-4f5a-a1a8-914e1364351f"), null, null, null, null, new Guid("6cfc425a-cea6-4079-b123-5b8116c55ad9"), null, null, null, null, new Guid("1acb9af2-4983-45c8-9081-f6233a77f111"), 1 },
                    { new Guid("3e165d70-e775-485d-ba89-ce7d22f6548c"), null, null, null, null, new Guid("d32fcf25-4d38-4d99-b1e5-c3cab7606807"), null, null, null, null, new Guid("2acb9af2-4983-45c8-9081-f6233a77f222"), 1 }
                });

            migrationBuilder.InsertData(
                table: "OptionToProduct",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "OptionGroupId", "OptionId", "ParentProductId", "ProductId", "Status" },
                values: new object[,]
                {
                    { new Guid("ef12cea5-7ade-4f57-87f2-dadac3112c0b"), null, null, null, null, null, null, null, null, new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), new Guid("ef12cea5-7ade-4f57-87f2-dadac3112c0b"), new Guid("8acb9af2-4983-45c8-9081-f6233a77f888"), new Guid("3acb9af2-4983-45c8-9081-f6233a77f333"), 1 },
                    { new Guid("50a5f086-42c9-4ef3-9873-7021eebe1017"), null, null, null, null, null, null, null, null, new Guid("3e8e39b5-8e99-46b4-88cc-b3126367b365"), new Guid("d41b5341-0ad0-4e5f-9108-44a669cd7024"), new Guid("8acb9af2-4983-45c8-9081-f6233a77f888"), new Guid("7acb9af2-4983-45c8-9081-f6233a77f777"), 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "CreatedComputer", "CreatedDate", "CreatedIP", "CreatedUserId", "FileName", "ModifiedComputer", "ModifiedDate", "ModifiedIP", "ModifiedUserId", "ProductId", "Revision", "SortOrder", "Status" },
                values: new object[,]
                {
                    { new Guid("cfb5b2a1-38e9-4e35-ba30-1af9e5b7def5"), null, null, null, null, "/blog/images/product_images/Siyah_Kazak/5_org_zoom.jpg", null, null, null, null, new Guid("1acb9af2-4983-45c8-9081-f6233a77f111"), "Siyah Kazak_4", 4, 1 },
                    { new Guid("bde1098d-04b6-44d8-9bf8-660bb95735f4"), null, null, null, null, "/blog/images/product_images/Kumas_Pantolon/3_org_zoom.jpg", null, null, null, null, new Guid("5acb9af2-4983-45c8-9081-f6233a77f555"), "Kumas_Pantolon_3", 3, 1 },
                    { new Guid("c9e17b8c-dd1e-427f-a977-248e15aea3fd"), null, null, null, null, "/blog/images/product_images/Kumas_Pantolon/2_org_zoom.jpg", null, null, null, null, new Guid("5acb9af2-4983-45c8-9081-f6233a77f555"), "Kumas_Pantolon_2", 2, 1 },
                    { new Guid("39db4cc0-2c68-4e83-a691-3d8458c11437"), null, null, null, null, "/blog/images/product_images/Kumas_Pantolon/1_org_zoom (1).jpg", null, null, null, null, new Guid("5acb9af2-4983-45c8-9081-f6233a77f555"), "Kumas_Pantolon_1", 1, 1 },
                    { new Guid("2fc7f2f0-401f-427d-b09e-4fa9e5f83bc8"), null, null, null, null, "/blog/images/product_images/Kot_Pantolon/4_org_zoom.jpg", null, null, null, null, new Guid("4acb9af2-4983-45c8-9081-f6233a77f444"), "Kot_Pantolon_3", 3, 1 },
                    { new Guid("f88af012-589f-4fbe-9b32-04da771c58ad"), null, null, null, null, "/blog/images/product_images/Kot_Pantolon/1_org_zoom.jpg", null, null, null, null, new Guid("4acb9af2-4983-45c8-9081-f6233a77f444"), "Kot_Pantolon_2", 2, 1 },
                    { new Guid("ca950a33-efcd-422f-b32c-27620b69945d"), null, null, null, null, "/blog/images/product_images/Kot_Pantolon/0_org_zoom.jpg", null, null, null, null, new Guid("4acb9af2-4983-45c8-9081-f6233a77f444"), "Kot_Pantolon_1", 1, 1 },
                    { new Guid("e8885fb6-9e94-4ed9-a73b-eb1581970d53"), null, null, null, null, "/blog/images/product_images/Kirmizi_Gomlek/3_org_zoom.jpg", null, null, null, null, new Guid("c98b184b-0fa0-4633-bb5f-cfbcc7b0e45b"), "Kırmızı_Gömlek_3", 3, 1 },
                    { new Guid("ca83f04e-45fb-4c5b-8fb7-f56fde1f58d0"), null, null, null, null, "/blog/images/product_images/Kirmizi_Gomlek/1_org_zoom.jpg", null, null, null, null, new Guid("c98b184b-0fa0-4633-bb5f-cfbcc7b0e45b"), "Kırmızı_Gömlek_2", 2, 1 },
                    { new Guid("5c7e932b-358b-493b-9545-534bd8a86270"), null, null, null, null, "/blog/images/product_images/Kirmizi_Gomlek/1_org_zoom (1).jpg", null, null, null, null, new Guid("c98b184b-0fa0-4633-bb5f-cfbcc7b0e45b"), "Kırmızı_Gömlek_1", 1, 1 },
                    { new Guid("d9daea35-f288-425a-8d75-a1d14f2a510b"), null, null, null, null, "/blog/images/product_images/Mavi_Gomlek/3_org_zoom.jpg", null, null, null, null, new Guid("8acb9af2-4983-45c8-9081-f6233a77f888"), "Mavi_Gömlek_3", 3, 1 },
                    { new Guid("b9eaf18a-e280-4d84-92de-0e99bee8ac89"), null, null, null, null, "/blog/images/product_images/Mavi_Gomlek/2_org_zoom.jpg", null, null, null, null, new Guid("8acb9af2-4983-45c8-9081-f6233a77f888"), "Mavi_Gömlek_2", 2, 1 },
                    { new Guid("1fc89776-7537-4348-9aff-cbdc5776f002"), null, null, null, null, "/blog/images/product_images/Mavi_Gomlek/1_org_zoom.jpg", null, null, null, null, new Guid("8acb9af2-4983-45c8-9081-f6233a77f888"), "Mavi_Gömlek_1", 1, 1 },
                    { new Guid("3c405fb8-3355-4934-a1b5-8f0f9dbc2b4c"), null, null, null, null, "/blog/images/product_images/Siyah_Kazak/4_org_zoom.jpg", null, null, null, null, new Guid("1acb9af2-4983-45c8-9081-f6233a77f111"), "Siyah Kazak_3", 3, 1 },
                    { new Guid("969278ca-46ba-48d1-a0c3-f9a253a1e5ff"), null, null, null, null, "/blog/images/product_images/Siyah_Gomlek/94_org_zoom.jpg", null, null, null, null, new Guid("7acb9af2-4983-45c8-9081-f6233a77f777"), "Siyah_Gömlek_3", 3, 1 },
                    { new Guid("8e99496e-665f-49eb-b9f5-daf9efdabd94"), null, null, null, null, "/blog/images/product_images/Siyah_Kazak/1_org.jpg", null, null, null, null, new Guid("1acb9af2-4983-45c8-9081-f6233a77f111"), "Siyah Kazak_1", 1, 1 },
                    { new Guid("638dae02-6d9d-4a46-838a-7e3e5f790f1e"), null, null, null, null, "/blog/images/product_images/Beyaz_Gomlek/5_org_zoom.jpg", null, null, null, null, new Guid("6acb9af2-4983-45c8-9081-f6233a77f666"), "Beyaz_Gömlek_3", 3, 1 },
                    { new Guid("960f4a34-422a-4846-9c83-882e9ec2dd0d"), null, null, null, null, "/blog/images/product_images/Beyaz_Gomlek/3_org_zoom.jpg", null, null, null, null, new Guid("6acb9af2-4983-45c8-9081-f6233a77f666"), "Beyaz_Gömlek_2", 2, 1 },
                    { new Guid("660eedd2-f0a1-429c-8ec9-beaa3964a183"), null, null, null, null, "/blog/images/product_images/Beyaz_Gomlek/1_org_zoom.jpg", null, null, null, null, new Guid("6acb9af2-4983-45c8-9081-f6233a77f666"), "Beyaz_Gömlek_1", 1, 1 },
                    { new Guid("d44bdbfb-e792-46b1-b810-740d012ca9d8"), null, null, null, null, "/blog/images/product_images/Kirmizi_Kazak/5_org_zoom.jpg", null, null, null, null, new Guid("3acb9af2-4983-45c8-9081-f6233a77f333"), "Kırmızı Kazak_3", 3, 1 },
                    { new Guid("dbccc3ef-931c-45fe-ae32-013ccfab10ca"), null, null, null, null, "/blog/images/product_images/Kirmizi_Kazak/2_org_zoom.jpg", null, null, null, null, new Guid("3acb9af2-4983-45c8-9081-f6233a77f333"), "Kırmızı Kazak_2", 2, 1 },
                    { new Guid("94cd44dc-c981-4688-8e0b-f65e5ba461e6"), null, null, null, null, "/blog/images/product_images/Kirmizi_Kazak/1_org_zoom (1).jpg", null, null, null, null, new Guid("3acb9af2-4983-45c8-9081-f6233a77f333"), "Kırmızı Kazak_1", 1, 1 },
                    { new Guid("e5552ff1-0932-4d95-9e90-827d9f388c89"), null, null, null, null, "/blog/images/product_images/Beyaz_Kazak/6_org_zoom.jpg", null, null, null, null, new Guid("2acb9af2-4983-45c8-9081-f6233a77f222"), "Beyaz Kazak_4", 8, 1 },
                    { new Guid("7d081144-3b3b-4dcc-b842-48ccf13f8cd3"), null, null, null, null, "/blog/images/product_images/Beyaz_Kazak/5_org_zoom.jpg", null, null, null, null, new Guid("2acb9af2-4983-45c8-9081-f6233a77f222"), "Beyaz Kazak_3", 7, 1 },
                    { new Guid("466327bb-b102-4293-9435-02bb8d7a7d4e"), null, null, null, null, "/blog/images/product_images/Beyaz_Kazak/2_org_zoom.jpg", null, null, null, null, new Guid("2acb9af2-4983-45c8-9081-f6233a77f222"), "Beyaz Kazak_2", 6, 1 },
                    { new Guid("8195165c-5afa-4165-ac79-6151acbf771e"), null, null, null, null, "/blog/images/product_images/Beyaz_Kazak/1_org_zoom.jpg", null, null, null, null, new Guid("2acb9af2-4983-45c8-9081-f6233a77f222"), "Beyaz Kazak_1", 5, 1 },
                    { new Guid("86e49ba0-0d47-4bb4-85e5-014e5241e3e7"), null, null, null, null, "/blog/images/product_images/Siyah_Kazak/2_org_zoom.jpg", null, null, null, null, new Guid("1acb9af2-4983-45c8-9081-f6233a77f111"), "Siyah Kazak_2", 2, 1 },
                    { new Guid("98c93c9f-90bd-4867-ab12-2965df684aed"), null, null, null, null, "/blog/images/product_images/Siyah_Gomlek/90_org_zoom.jpg", null, null, null, null, new Guid("7acb9af2-4983-45c8-9081-f6233a77f777"), "Siyah_Gömlek_2", 2, 1 },
                    { new Guid("43237839-639b-46f3-a314-f702a602c40d"), null, null, null, null, "/blog/images/product_images/Siyah_Gomlek/2_org_zoom.jpg", null, null, null, null, new Guid("7acb9af2-4983-45c8-9081-f6233a77f777"), "Siyah_Gömlek_1", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressType_CreatedUserId",
                table: "AddressType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AddressType_ModifiedUserId",
                table: "AddressType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandToCategories_BrandId",
                table: "BrandToCategories",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandToCategories_CategoryId",
                table: "BrandToCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandToCategories_CreatedUserId",
                table: "BrandToCategories",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BrandToCategories_ModifiedUserId",
                table: "BrandToCategories",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_CreatedUserId",
                table: "Cart",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ModifiedUserId",
                table: "Cart",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CreatedUserId",
                table: "CartItem",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ModifiedUserId",
                table: "CartItem",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductId",
                table: "CartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyValue_CreatedUserId",
                table: "CurrencyValue",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyValue_ModifiedUserId",
                table: "CurrencyValue",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorToProduct_DistributorId",
                table: "DistributorToProduct",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorToProduct_ProductId",
                table: "DistributorToProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProduct_CreatedUserId",
                table: "FavouritedProduct",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProduct_ModifiedUserId",
                table: "FavouritedProduct",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritedProduct_ProductId",
                table: "FavouritedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentRate_PaymentGatewayId",
                table: "InstallmentRate",
                column: "PaymentGatewayId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_CreatedUserId",
                table: "MemberAddress",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberAddress_ModifiedUserId",
                table: "MemberAddress",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionGroup_CreatedUserId",
                table: "OptionGroup",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionGroup_ModifiedUserId",
                table: "OptionGroup",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_CreatedUserId",
                table: "Options",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_ModifiedUserId",
                table: "Options",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Options_OptionGroupId",
                table: "Options",
                column: "OptionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionToProduct_CreatedUserId",
                table: "OptionToProduct",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionToProduct_ModifiedUserId",
                table: "OptionToProduct",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionToProduct_OptionGroupId",
                table: "OptionToProduct",
                column: "OptionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionToProduct_OptionId",
                table: "OptionToProduct",
                column: "OptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionToProduct_ProductId",
                table: "OptionToProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BillingAddressId",
                table: "Order",
                column: "BillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CreatedUserId",
                table: "Order",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ModifiedUserId",
                table: "Order",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ShippingAddressId",
                table: "Order",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_CreatedUserId",
                table: "OrderItem",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ModifiedUserId",
                table: "OrderItem",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_UserId",
                table: "OrderItem",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRefundDemand_CreatedUserId",
                table: "OrderRefundDemand",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRefundDemand_ModifiedUserId",
                table: "OrderRefundDemand",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRefundDemand_OrderId",
                table: "OrderRefundDemand",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRefundDemand_UserId",
                table: "OrderRefundDemand",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_CreatedUserId",
                table: "Payment",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ModifiedUserId",
                table: "Payment",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentStatusId",
                table: "Payment",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGateway_CreatedUserId",
                table: "PaymentGateway",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentGateway_ModifiedUserId",
                table: "PaymentGateway",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_CreatedUserId",
                table: "PaymentStatus",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_ModifiedUserId",
                table: "PaymentStatus",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_CreatedUserId",
                table: "PaymentType",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_ModifiedUserId",
                table: "PaymentType",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_CreatedUserId",
                table: "PhoneNumbers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ModifiedUserId",
                table: "PhoneNumbers",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_UserId",
                table: "PhoneNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_CreatedUserId",
                table: "ProductComment",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ModifiedUserId",
                table: "ProductComment",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_ProductId",
                table: "ProductComment",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_UserId",
                table: "ProductComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductId",
                table: "ProductDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_CreatedUserId",
                table: "ProductImages",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ModifiedUserId",
                table: "ProductImages",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCompanys_CreatedUserId",
                table: "ShippingCompanys",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingCompanys_ModifiedUserId",
                table: "ShippingCompanys",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecGroup_CreatedUserId",
                table: "SpecGroup",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecGroup_ModifiedUserId",
                table: "SpecGroup",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecName_CreatedUserId",
                table: "SpecName",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecName_ModifiedUserId",
                table: "SpecName",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecName_SpecGroupId",
                table: "SpecName",
                column: "SpecGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecToProduct_CreatedUserId",
                table: "SpecToProduct",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecToProduct_ModifiedUserId",
                table: "SpecToProduct",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecToProduct_ProductId",
                table: "SpecToProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecToProduct_SpecGroupId",
                table: "SpecToProduct",
                column: "SpecGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecToProduct_SpecNameId",
                table: "SpecToProduct",
                column: "SpecNameId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecToProduct_SpecValueId",
                table: "SpecToProduct",
                column: "SpecValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecValue_CreatedUserId",
                table: "SpecValue",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecValue_ModifiedUserId",
                table: "SpecValue",
                column: "ModifiedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecValue_SpecGroupId",
                table: "SpecValue",
                column: "SpecGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecValue_SpecNameId",
                table: "SpecValue",
                column: "SpecNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedUserId",
                table: "Users",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedUserId",
                table: "Users",
                column: "ModifiedUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "BrandToCategories");

            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "County");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "CurrencyValue");

            migrationBuilder.DropTable(
                name: "DemandReason");

            migrationBuilder.DropTable(
                name: "DemandStatus");

            migrationBuilder.DropTable(
                name: "DistributorToProduct");

            migrationBuilder.DropTable(
                name: "FavouritedProduct");

            migrationBuilder.DropTable(
                name: "InstallmentRate");

            migrationBuilder.DropTable(
                name: "OptionToProduct");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderRefundDemand");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PaymentType");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "PhoneNumberTypes");

            migrationBuilder.DropTable(
                name: "ProductComment");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ShippingCompanys");

            migrationBuilder.DropTable(
                name: "SpecToProduct");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Distributor");

            migrationBuilder.DropTable(
                name: "PaymentGateway");

            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpecValue");

            migrationBuilder.DropTable(
                name: "OptionGroup");

            migrationBuilder.DropTable(
                name: "MemberAddress");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "SpecName");

            migrationBuilder.DropTable(
                name: "SpecGroup");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
