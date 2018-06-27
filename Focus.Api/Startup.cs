﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Focus.Api.Middlewares;
using Focus.Infrastructure;
using Focus.Infrastructure.Configuration;
using Focus.Infrastructure.Security;
using Focus.Repository.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Focus.Api
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
            services.AddMvcCore()
                    .AddAuthorization()
                    .AddJsonFormatters()
                    .AddJsonOptions(options =>//全局配置Json序列化处理
                    {
                        //设置时间格式
                        options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
                    });

            services.AddMvc();

            services.AddAuthentication("Bearer")
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.Authority = "http://localhost:8000";
                        options.ApiName = "focus_api";
                    });

            //添加跨域支持
            services.AddCors(options =>
            {
                options.AddPolicy("default", builder =>
                {
                    builder.AllowAnyOrigin()//允许任何来源的主机访问
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            //添加数据库连接
            AppSettings.ConnectionString = SqlConnectionHelper.SqlConnectionString;
            //services.AddDbContext<FocusDbContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<FocusDbContext>();

            //添加Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Focus API", Version = "v1" });
            });

            new AutofacServiceProvider(IoCConfig.Register(services));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FocusDbContext focusDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            focusDbContext.EnsureSeedDataForContext();//添加种子数据
            app.UseCors("default");
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
        }
    }
}
