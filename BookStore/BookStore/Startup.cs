using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Data;
using BookStore.Repository;
using AutoMapper;
using BookStore.DTO;
using BookStore.ApplicationLogic;
using BookStore.DomainLogic;
namespace BookStore
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
            // register 
         

            services.AddScoped<IBookTypeRepository, BookTypeRepository>();

       

          

            //book
            services.AddScoped<IBookApplicationLogics, BookApplicationLogics>();
            services.AddScoped<IBookLogic, BookLogic>();
            services.AddScoped<IBookRepository, BookRepository>();

            //order
            services.AddScoped<IOrderApplicationLogics, OrderApplicationLogics>();
            services.AddScoped<IOrderLogic, OrderLogic>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            //order_detail 
            services.AddScoped<IOrder_DetailRepository, Order_DetailRepository>();

            // book_booktype
            services.AddScoped<IBook_BookTypeLogic, Book_BookTypeLogic>();
            services.AddScoped<IBook_BookTypeRepository, Book_BookTypeRepository>();


            //generic but not use 
           


            services.AddDbContext<BookStoredbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("BookStoredbContext")));

            // add auto mapper 
            services.AddAutoMapper
            (typeof(AutoMapperProfile).Assembly);

            
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
