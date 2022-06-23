using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Proje.Core.Entity;
using Proje.Core.Map;
using Proje.Model.Entities;
using Proje.Model.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proje.Model.Context
{
    public class DataContext : DbContext
    {
        //Microsoft.AspNetCore.Http.Abstractions 2.2.0
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DataContext(DbContextOptions<DataContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandToCategory> BrandToCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<SpecName> SpecNames { get; set; }
        public DbSet<SpecGroup> SpecGroups { get; set; }
        public DbSet<SpecValue> SpecValues { get; set; }
        public DbSet<SpecToProduct> SpecToProducts { get; set; }
        public DbSet<PaymentGateway> PaymentGateways { get; set; }
        public DbSet<InstallmentRate> InstallmentRates { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyValue> CurrencyValues { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<County> Counties { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<MemberAddress> MemberAddresses { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<DistributorToProduct> DistributorToProducts { get; set; }
        public DbSet<FavouritedProduct> FavouritedProducts { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ShippingCompany> ShippingCompanies { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<OptionGroup> OptionGroups { get; set; }
        public DbSet<OptionToProduct> OptionToProducts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterMapping(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserSeedData());
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new BrandSeedData());
            modelBuilder.ApplyConfiguration(new BrandToCategorySeedData());
            modelBuilder.ApplyConfiguration(new ProductSeedData());
            modelBuilder.ApplyConfiguration(new PaymentStatusSeedData());
            modelBuilder.ApplyConfiguration(new OrderStatusSeedData());
            modelBuilder.ApplyConfiguration(new DistributorSeedData());
            modelBuilder.ApplyConfiguration(new DistributorToProductSeedData());
            modelBuilder.ApplyConfiguration(new OptionGroupSeedData());
            modelBuilder.ApplyConfiguration(new OptionsSeedData());
            modelBuilder.ApplyConfiguration(new OptionToProductSeedData());
            modelBuilder.ApplyConfiguration(new PhoneNumberTypeSeedData());
            modelBuilder.ApplyConfiguration(new DemandReasonSeedData());
            modelBuilder.ApplyConfiguration(new DemandStatusSeedData());
            modelBuilder.ApplyConfiguration(new CitySeedData());
            modelBuilder.ApplyConfiguration(new CountySeedData());
            modelBuilder.ApplyConfiguration(new AddressTypeSeedData());
            modelBuilder.ApplyConfiguration(new PaymentGatewaySeedData());
            modelBuilder.ApplyConfiguration(new InstallmentRateSeedData());
            modelBuilder.ApplyConfiguration(new PaymentTypeSeedData());
            modelBuilder.ApplyConfiguration(new CurrencySeedData());
            modelBuilder.ApplyConfiguration(new ShippingCompanySeedData());
            modelBuilder.ApplyConfiguration(new ProductImageSeedData());

        }

        private void RegisterMapping(ModelBuilder modelBuilder)
        {
            var typeToRegister = new List<Type>();
            var dataAssembly = Assembly.GetExecutingAssembly();

            typeToRegister.AddRange(dataAssembly.DefinedTypes.Select(x => x.AsType()));
            foreach (var builderType in typeToRegister.Where(x => typeof(IEntityBuilder).IsAssignableFrom(x)))
            {
                if (builderType != null && builderType != typeof(IEntityBuilder))
                {
                    var builder = (IEntityBuilder)Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();

            string computerName = Dns.GetHostEntry(_httpContextAccessor.HttpContext.Connection.RemoteIpAddress).HostName;
            string ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            foreach (var item in modifiedEntities)
            {
                CoreEntity entity = item.Entity as CoreEntity;
                if (item != null)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            entity.CreatedComputer = computerName;
                            entity.CreatedIP = ipAddress;
                            entity.CreatedDate = DateTime.Now;
                            entity.CreatedUserId = GetUserId();
                            break;
                        case EntityState.Modified:
                            entity.ModifiedComputer = computerName;
                            entity.ModifiedIP = ipAddress;
                            entity.ModifiedDate = DateTime.Now;
                            entity.ModifiedUserId = GetUserId();
                            break;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private Guid? GetUserId()
        {
            string userId = "";
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();
                userId = claims?.FirstOrDefault(x => x.Type.Equals("jti", StringComparison.OrdinalIgnoreCase))?.Value;
            }

            if (!string.IsNullOrEmpty(userId))
                return Guid.Parse(userId);
            else
                return null;
        }
    }
}
