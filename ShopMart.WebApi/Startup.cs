using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using ShopMart.Application.Implementations;
using ShopMart.Application.Interfaces;
using ShopMart.Data.EF;
using ShopMart.Data.EF.Repositiores;
using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using ShopMart.Infrastructure.Interfaces;
using Swashbuckle.AspNetCore.Swagger;


namespace ShopMart.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AppDbConnection"),
                o => o.MigrationsAssembly("ShopMart.Data.EF")));


            services.AddCors(o => o.AddPolicy("ShopMartCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            services.AddAutoMapper();


            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddTransient(typeof(IUnitOfWork), typeof(EFUnitOfWork));

            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductCategoryService, ProductCategoryService>();

            services.AddMvc().
                AddJsonOptions(options =>
                options.SerializerSettings.ContractResolver = new DefaultContractResolver());//tra ve json

            //services.AddSwaggerGen(s =>
            //{
            //    s.SwaggerDoc("v1", new Info
            //    {
            //        Version = "v1",
            //        Title = "ShopMart Project",
            //        Description = "TEDU API Swagger surface",
            //        Contact = new Microsoft.Azure.KeyVault.Models.Contact { Name = "ToanBN", Email = "shopmart.international@gmail.com", Url = "http://www.tedu.com.vn" },
            //        License = new License { Name = "MIT", Url = "https://github.com/teduinternational/teducoreapp" }
            //    });
            //});

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "ShopMart API",
                    Description = "ShopMart Web API Documentation",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "TlinhPhan",
                        Email = "tlinhphan201@gmail.com",
                        Url = "http://www.shopmart.com.vn"
                    },
                    License = new License
                    {
                        Name = "MIT",
                        Url = "https://github.com/Tlinhphan/tuhocappcore"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors("TeduCorsPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json",
                    "ShopMart API v1"
                );
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
