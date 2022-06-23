using AutoMapper;
using Proje.API.Infrastructor.Models;
using Proje.Common.WorkContext;
using Proje.Model.Context;
using Proje.Service.Repository.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Proje.Service.Repository.Category;
using Proje.Service.Repository.Brand;
using Proje.Service.Repository.BrandToCategory;
using Proje.Service.Repository.Product;
using Proje.Service.Repository.ProductImage;
using Proje.Service.Repository.SpecName;
using Proje.Service.Repository.SpecGroup;
using Proje.Service.Repository.SpecValue;
using Proje.Service.Repository.SpecToProduct;
using Proje.Service.Repository.PaymentGateway;
using Proje.Service.Repository.InstallmentRate;
using Proje.Service.Repository.CartItem;
using Proje.Service.Repository.Cart;
using Proje.Service.Repository.Payment;
using Proje.Service.Repository.PaymentType;
using Proje.Service.Repository.Currency;
using Proje.Service.Repository.CurrencyValue;
using Proje.Service.Repository.City;
using Proje.Service.Repository.County;
using Proje.Service.Repository.AddressType;
using Proje.Service.Repository.MemberAddress;
using Proje.Service.Repository.PaymentStatus;
using Proje.Service.Repository.Order;
using Proje.Service.Repository.Distributor;
using Proje.Service.Repository.DistributorToProduct;
using Proje.Service.Repository.FavouritedProduct;
using Proje.Service.Repository.ProductDetail;
using Proje.Service.Repository.ProductComment;
using Proje.Service.Repository.ShippingCompany;
using Proje.Service.Repository.OptionGroup;
using Proje.Service.Repository.Options;
using Proje.Service.Repository.OptionToProduct;
using Proje.Service.Repository.OrderItem;
using Proje.Service.Repository.PhoneNumber;
using Proje.Service.Repository.PhoneNumberType;
using Proje.Service.Repository.OrderRefundDemand;
using Proje.Service.Repository.DemandStatus;
using Proje.Service.Repository.DemandReason;
using Proje.Service.Repository.OrderStatus;

namespace Proje.API
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(env.ContentRootPath)
                              .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                              .AddEnvironmentVariables();
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            //API Modülünü sürecimize ekliyoruz...
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };

            //add-migration init
            //update-database
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:Conn"]);
            });

            //.Net Core yapýsý tamamiyle Dependency Injection yapýsýnyla çalýþtýðýndan Interface ile Service ve Repository classlarýnýn baðýmlýlýðýný tanýmlýyoruz.

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandToCategoryRepository, BrandToCategoryRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductImageRepository, ProductImageRepository>();
            services.AddTransient<ISpecNameRepository, SpecNameRepository>();
            services.AddTransient<ISpecGroupRepository, SpecGroupRepository>();
            services.AddTransient<ISpecValueRepository, SpecValueRepository>();
            services.AddTransient<ISpecToProductRepository, SpecToProductRepository>();
            services.AddTransient<IPaymentGatewayRepository, PaymentGatewayRepository>();
            services.AddTransient<IInstallmentRateRepository, InstallmentRateRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICurrencyValueRepository, CurrencyValueRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountyRepository, CountyRepository>();
            services.AddTransient<IAddressTypeRepository, AddressTypeRepository>();
            services.AddTransient<IMemberAddressRepository, MemberAddressRepository>();
            services.AddTransient<IPaymentStatusRepository, PaymentStatusRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IDistributorRepository, DistributorRepository>();
            services.AddTransient<IDistributorToProductRepository, DistributorToProductRepository>();
            services.AddTransient<IFavouritedProductRepository, FavouritedProductRepository>();
            services.AddTransient<IProductDetailRepository, ProductDetailRepository>();
            services.AddTransient<IProductCommentRepository, ProductCommentRepository>();
            services.AddTransient<IShippingCompanyRepository, ShippingCompanyRepository>();
            services.AddTransient<IOptionGroupRepository, OptionGroupRepository>();
            services.AddTransient<IOptionsRepository, OptionsRepository>();
            services.AddTransient<IOptionToProductRepository, OptionToProductRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddTransient<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();
            services.AddTransient<IOrderRefundDemandRepository, OrderRefundDemandRepository>();
            services.AddTransient<IDemandStatusRepository, DemandStatusRepository>();
            services.AddTransient<IDemandReasonRepository, DemandReasonRepository>();
            services.AddTransient<IOrderStatusRepository, OrderStatusRepository>();

            //Add AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //JWT Auth
            //using Microsoft.AspNetCore.Authentication.JwtBearer;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["Tokens:Issuer"],
                        ValidAudience = Configuration["Tokens:Audience"],
                        ValidateIssuerSigningKey = true,
                        //Microsoft.IdentityModel.Tokens
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"]))
                    };
                });

            //Swagger
            //Swashbuckle.AspNetCore.Swagger 5.4.1
            //Swashbuckle.AspNetCore.SwaggerGen 5.4.1
            //Swashbuckle.AspNetCore.SwaggerUI 5.4.1

            services.AddSwaggerGen(c =>
            {
                //using Microsoft.OpenApi.Models
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger on ASP.Net Core",
                    Version = "1.0.0",
                    Description = "Özgür Proje Backend Servis Projesi (Asp.Net Core 3.1)",
                    TermsOfService = new Uri("http://swagger.io/terms")
                });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description = "JWT Authorization header (Bearer) kullanýlmaktadýr. Örnek \"Authorization: Bearer {token}\"",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference{
                                Id = "Bearer",
                                Type= ReferenceType.SecurityScheme
                            }
                        },new List<string>()
                    }
                });

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "MY API V1");
                    c.RoutePrefix = "swagger";
                });
            }

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
