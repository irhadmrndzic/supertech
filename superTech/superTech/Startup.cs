using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using superTech.Database;
using superTech.Filters;
using superTech.Models.Category;
using superTech.Models.City;
using superTech.Models.Product;
using superTech.Models.Roles;
using superTech.Models.User;
using superTech.Services;
using superTech.Services.Generic;
using superTech.Services.GenericCRUD;

namespace superTech
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

      
        public void ConfigureServices(IServiceCollection services)
        {
          //  services.AddMvc().AddJsonOptions(options => options.SerializerSettings
          //.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers();
            services.AddMvc(x=>x.Filters.Add<ErrorFilter>());

            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();

            var connection = Configuration.GetConnectionString("ConnString");
            services.AddDbContext<superTechRSContext>(opt => opt.UseSqlServer(connection));


            services.AddScoped<IBaseService<UserModel, object>, BaseService<UserModel, object, User>>();
            services.AddScoped<IBaseService<ProductModel, object>, BaseService<ProductModel, object, Product>>();


            services
                .AddScoped<ICRUDService<UserModel, UserSearchRequest, UserUpsertRequest, UserUpsertRequest>,
                    UsersService>();
            //services
            //    .AddScoped<ICRUDService<UserModel, object, UserUpsertRequest, UserUpsertRequest>,
            //        BaseCRUDService<UserModel, object, User, UserUpsertRequest, UserUpsertRequest>>();


            services
                .AddScoped<ICRUDService<ProductModel, object, ProductUpsertRequest, ProductUpsertRequest>,
                    BaseCRUDService<ProductModel, object, Product, ProductUpsertRequest, ProductUpsertRequest>>();
            services
                .AddScoped<ICRUDService<CityModel, object, CityUpsertRequest, CityUpsertRequest>,
                    BaseCRUDService<CityModel, object, City, CityUpsertRequest, CityUpsertRequest>>();

            services
                .AddScoped<ICRUDService<CategoryModel, object, CategoryUpsertRequest, CategoryUpsertRequest>,
                    BaseCRUDService<CategoryModel, object, Category, CategoryUpsertRequest, CategoryUpsertRequest>>();

            services
                .AddScoped<ICRUDService<RolesModel, object, RolesModel, RolesModel>,
                    BaseCRUDService<RolesModel, object, Role, RolesModel, RolesModel>>();



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {  
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
