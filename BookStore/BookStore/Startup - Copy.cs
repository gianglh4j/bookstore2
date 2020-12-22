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
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace BookStore1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
       
            services.AddDbContext<BookStoredbContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("BookStoredbContext")));

            // add auto mapper 
            services.AddAutoMapper
            (typeof(AutoMapperProfile).Assembly);


            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            var builder = new ContainerBuilder();
            builder.Populate(services);
            //book
            builder.RegisterType<BookApplicationLogics>().As<IBookApplicationLogics>();
            builder.RegisterType<BookLogic>().As<IBookLogic>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();

            //order
            builder.RegisterType<OrderApplicationLogics>().As<IOrderApplicationLogics>();
            builder.RegisterType<OrderLogic>().As<IOrderLogic>();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();

            //order_detail 
            builder.RegisterType<Order_DetailRepository>().As<IOrder_DetailRepository>();

            //book_booktype
            builder.RegisterType<Book_BookTypeLogic>().As<IBook_BookTypeLogic>();
            builder.RegisterType<Book_BookTypeRepository>().As<IBook_BookTypeRepository>();

            //booktype
            builder.RegisterType<BookTypeRepository>().As<IBookTypeRepository>();
            builder.RegisterType<BookTypeLogic>().As<IBookTypeLogic>();
            builder.RegisterType<BookTypeApplicationLogic>().As<IBookTypeApplicationLogic>();

            this.ApplicationContainer = builder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);



          

       

         
            ////book
            //services.AddScoped<IBookApplicationLogics, BookApplicationLogics>();
            //services.AddScoped<IBookLogic, BookLogic>();
            //services.AddScoped<IBookRepository, BookRepository>();

            ////order
            //services.AddScoped<IOrderApplicationLogics, OrderApplicationLogics>();
            //services.AddScoped<IOrderLogic, OrderLogic>();
            //services.AddScoped<IOrderRepository, OrderRepository>();

            ////order_detail 
            //services.AddScoped<IOrder_DetailRepository, Order_DetailRepository>();

            //// book_booktype
            //services.AddScoped<IBook_BookTypeLogic, Book_BookTypeLogic>();
            //services.AddScoped<IBook_BookTypeRepository, Book_BookTypeRepository>();

            ////booktype
            //services.AddScoped<IBookTypeRepository, BookTypeRepository>();
            //services.AddScoped<IBookTypeLogic, BookTypeLogic>();
            //services.AddScoped<IBookTypeApplicationLogic, BookTypeApplicationLogic>();





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
