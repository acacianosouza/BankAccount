using System.Text;
using Api.Filters;
using Api.Provider;
using Application.Application;
using Application.Contract;
using Data.Repository;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Repository;
using Domain.Services;
using Domain.Services.Contracts;
using Infrastructure.Data.Context;
using Infrastructure.Options.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Api
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json");

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(config =>
                {
                    config.Filters.Add(typeof(CustomExceptionFilter));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("d71a5f83-8132-4c50-acd0-96ed6ebbf61d")),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.Configure<ContextOptions>(Configuration.GetSection("ConnectionStrings"));

            #region DB Context
            services.AddDbContext<SuperDigitalDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SuperDigitalDb"));
                
            }, contextLifetime: ServiceLifetime.Singleton);
            #endregion

            //Application
            services.AddTransient(typeof(IApplicationBase<>), typeof(ApplicationBase<>));
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<ITransactionApplication, TransactionApplication>();

            //Service
            services.AddTransient(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICheckingAccountService, CheckingAccountService>();
            services.AddTransient<ITransactionService, TransactionService>();

            //Repository
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICheckingAccountRepository, CheckingAccountRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            ConfigureAuth(app);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
