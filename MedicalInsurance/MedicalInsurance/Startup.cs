using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MedicalInsurance.ConfigModel;
using MedicalInsurance.Helper;
using MedicalInsurance.Service.Interfaces;
using MedicalInsurance.Service.Providers;
using MedicalInsurance.WebService.Basic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using Quote.Core.Exceptions;
using Quote.Service.Interfaces;
using Quote.Service.Providers;
using Swashbuckle.AspNetCore.Swagger;

namespace MedicalInsurance
{/// <summary>
/// 
/// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="env"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //    // Configuration = configuration;
            //    var builder = new ConfigurationBuilder()
            //       .SetBasePath(env.ContentRootPath)
            //       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //    this.Configuration = builder.Build();
            //    var test = Configuration.ToString();
            //    BaseConfigModel.SetBaseConfig(Configuration, env.ContentRootPath, env.WebRootPath);
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(x =>
                {
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    x.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });
            //依赖注入

            var connection = Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connection))
                throw StandardException.Caused("10000", "未配置数据库连接字符串");
            //依赖注入
            services.AddScoped<IDataBaseHelpService>(sp => new DataBaseHelpService(connection));
            services.AddScoped<IDataBaseSqlServerService>(sp => new DataBaseSqlServerService(connection));
            services.AddScoped<IGrammarNewService, GrammarNewService>();
            services.AddScoped<IWebServiceBasic, WebServiceBasic>();
            services.AddScoped<IWebServiceBasicService, WebServiceBasicService>();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            #region Swagger

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "消息管理 API"
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "MedicalInsurance.xml");
                options.IncludeXmlComments(xmlPath);
                options.DescribeAllEnumsAsStrings();//枚举呈现为字符串
                options.DocInclusionPredicate((docName, description) => true);
                options.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "请输入带有Bearer的Token", Name = "Authorization", Type = "apiKey" });
                options.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> { { "Bearer", Enumerable.Empty<string>() } });
                //options.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
            });
            #endregion
            #region 认证
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false; //获取或设置元数据地址或权限是否需要HTTPS。默认值为true。这应该仅在开发环境中禁用。
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "User",
                        ValidAudiences = new[] { "yyy", "User" },
                        ValidateAudience = true,
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecurityKey"])),
                        ValidateLifetime = true,//是否验证失效时间

                    };
                });

            #endregion
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowAnyOrigin", policy =>
            //    {
            //        policy.AllowAnyOrigin()//允许任何源
            //        .AllowAnyMethod()//允许任何方式
            //        .AllowAnyHeader()//允许任何头
            //        .AllowCredentials();//允许cookie
            //    });
            //c.AddPolicy("AllowSpecificOrigin", policy =>
            //{
            //    policy.WithOrigins("http://localhost:8083")
            //    .WithMethods("GET", "POST", "PUT", "DELETE")
            //    .WithHeaders("authorization");
            //});
            //});

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseDeveloperExceptionPage();
            }
            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion
            //认证

            app.UseCors(options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                    options.AllowAnyOrigin();
                });
            app.UseAuthentication();
            app.UseMvc();
        }
    }

}
