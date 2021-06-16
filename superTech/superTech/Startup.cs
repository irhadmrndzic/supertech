using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using superTech.AuthHandlers;
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
using Newtonsoft;
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

            services.AddMvc(x => x.Filters.Add<ErrorFilter>());
            ;
            services.AddControllers().AddNewtonsoftJson(x =>
             x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "superTech", Version = "v1" });

                c.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basicAuth" }
                        },
                        new string[]{}
                    }
                });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var connection = Configuration.GetConnectionString("ConnString");
            services.AddDbContext<superTechRSContext>(opt => opt.UseSqlServer(connection));


            services.AddScoped<IBaseService<UserModel, object>, BaseService<UserModel, object, User>>();
            services.AddScoped<IUsersService,UsersService>();

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

         

            app.UseHttpsRedirection();

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
