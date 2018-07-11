using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Focus.Api.Middlewares;
using Focus.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvcCore()
                    .AddAuthorization()
                    .AddJsonFormatters()
                    .AddJsonOptions(options =>//全局配置Json序列化处理
                    {
                        //设置时间格式
                        options.SerializerSettings.DateFormatString = "yyyy-MM-dd";
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

            //添加Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Focus API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FocusDbContext focusDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //focusDbContext.EnsureSeedDataForContext();//添加种子数据
            app.UseCors("default");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Focus API V1");
            });
            app.UseMvc();
        }
    }
}
