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
using NLog;
using System.IO;
using LoggerService;
using Contracts;
using BookStore.Extensions;

namespace BookStore
{
    public class Startup
    {
   
        //public Startup(IWebHostEnvironment env)
        //{

        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(env.ContentRootPath)
        //        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        //        .AddEnvironmentVariables();
        //    this.Configuration = builder.Build();
        //}

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
        }


        public IConfiguration Configuration { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
       
            services.AddDbContext<BookStoredbContext>(options =>
options.UseSqlServer(Configuration.GetConnectionString("BookStoredbContext")));

            // add auto mapper 
            services.AddAutoMapper
            (typeof(AutoMapperProfile).Assembly);


            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Nlog 
            builder.RegisterType<LoggerManager>().As<ILoggerManager>();

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            // If, for some reason, you need a reference to the built container, you
            // can use the convenience extension method GetAutofacRoot.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ConfigureExceptionHandler(logger);
            app.ConfigureCustomExceptionMiddleware();
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
