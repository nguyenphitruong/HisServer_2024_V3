using Emr.Application.Common.Interfaces;
using Emr.Domain.Model;
using Emr.Domain.Model.Cache;
using Emr.Domain.Model.Cates;
using Emr.Domain.Model.Emr.Clinics;
using Emr.Domain.Model.Emr.Registers;
using Emr.Domain.Model.Pay.Services;
using Emr.Domain.Model.Share;
using Emr.Domain.Model.Share.Patient;
using Emr.Domain.Model.StoreProduce;
using Emr.Domain.Model.Sys;
using Emr.Infrastructure.Hepper.Provider;
using Emr.Infrastructure.Persistence;
using Emr.Infrastructure.Persistence.SchemaChange;
using Emr.Infrastructure.Repositories;
using Emr.Infrastructure.Repositories.Cache;
using Emr.Infrastructure.Repositories.Cates;
using Emr.Infrastructure.Repositories.Clinic;
using Emr.Infrastructure.Repositories.Emr.Registers;
using Emr.Infrastructure.Repositories.Pay.Services;
using Emr.Infrastructure.Repositories.Pha;
using Emr.Infrastructure.Repositories.Result;
using Emr.Infrastructure.Repositories.Share;
using Emr.Infrastructure.Repositories.Share.Patient;
using Emr.Infrastructure.Repositories.StoreProduce;
using Emr.Infrastructure.Repositories.Sys;
using Emr.Infrastructure.Services;
using Emr.Infrastructure.Services.Emr;
using Emr.Infrastructure.Services.Emr.Clinics;
using Emr.Infrastructure.Services.Handlers;
using Emr.Infrastructure.Services.Pay.Services;
using Emr.Infrastructure.Services.Pha;
using Emr.Infrastructure.Services.Result;
using Emr.Infrastructure.Services.Share.Patient;
using Emr.Infrastructure.Services.StoreProduce;
using Emr.Infrastructure.Services.Sys;
using Emr.Infrastructure.UniOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PT.DomainLayer.AggregatesModel.Pha;
using PT.DomainLayer.AggregatesModel.Result;
using System;
using System.IO;

namespace Emr.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)//, IWebHostEnvironment environment)
        {
            var ConnectionString = configuration.GetConnectionString("DefaultConnection");

            var configBuilder = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())      // file config ở thư mục hiện tại
          .AddJsonFile("appsettings.json");  // nạp config định dạng JSON

            configuration = configBuilder.Build();                // Tạo configurationroot
            services.AddOptions();
            services.Configure<ConnectionStringOptions>(configuration.GetSection("ConnectionStrings"));
            services.AddSingleton<ConnectionStrings>();




            ////Option connect---
            //var provider = configuration.GetValue("DbProvider", "SqlServer");
            //var migrationAssembly = $"Emr.Infrastructure.{provider}";


            //services.AddDbContext<MydbContext>(options => _ = provider switch
            //{
            //    "Sqlite" => options.UseSqlite(
            //        configuration.GetConnectionString("DefaultConnection_Sqlite"),
            //        b =>
            //        {
            //            b.MigrationsAssembly(migrationAssembly);
            //        }),

            //    "SqlServer" => options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b =>
            //        {
            //            b.MigrationsAssembly(migrationAssembly);
            //        }),

            //    "Npgsql" => options.UseNpgsql(
            //        configuration.GetConnectionString("DefaultConnection_Postgres"),
            //        b =>
            //        {
            //            b.MigrationsAssembly(migrationAssembly);
            //        }),


            //    _ => throw new Exception($"Unsupported provider: {provider}")
            //});
            ////Option connect---

            // services.AddScoped<IMydbContext>(provider => provider.GetService<MydbContext>());



            services.AddDbContext<MydbContext>(options =>
                     {
                         options.UseSqlServer(ConnectionString);

                     });

            services.AddDbContext<MyDbShareContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            //services.AddDbContext<MydbmmyyContext>(options =>
            //{
            //    options.UseSqlServer(ConnectionString);
            //});

            //       services.AddDbContext<MydbmmyyContext>(optionsBuilder => optionsBuilder.UseSqlServer(ConnectionString)
            //// here is where we replace the default customizer
            //.ReplaceService<IModelCustomizer, Persistence.CustomizeContext.SqlServerModelCustomizer>());




            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            //services.AddDbContext<ApplicationDbContext>(options => _ = provider switch
            //{
            //    "Sqlite" => options.UseSqlite(
            //        configuration.GetConnectionString("DefaultConnection_Sqlite"),
            //        b =>
            //        {
            //            b.MigrationsAssembly(migrationAssembly);
            //        }),

            //    "SqlServer" => options.UseSqlServer(
            //        configuration.GetConnectionString("DefaultConnection"),
            //        b =>
            //        {
            //            b.MigrationsAssembly(migrationAssembly);
            //        }),

            //    "Npgsql" => options.UseNpgsql(
            //        configuration.GetConnectionString("DefaultConnection_Postgres"),
            //        b =>
            //        {
            //            b.MigrationsAssembly(migrationAssembly);
            //        }),

            //    _ => throw new Exception($"Unsupported provider: {provider}")
            //});

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            //services.AddScoped<IDomainEventService, DomainEventService>();

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<MydbContext>();

            //services.AddIdentityServer()
            //    .AddApiAuthorization<ApplicationUser, MydbContext>();

            services.AddHttpClient("open-weather-api", c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("OpenWeatherApi:Url").Value);

                c.DefaultRequestHeaders.Add(configuration.GetSection("OpenWeatherApi:Key:Key").Value, configuration.GetSection("OpenWeatherApi:Key:Value").Value);

                c.DefaultRequestHeaders.Add(configuration.GetSection("OpenWeatherApi:Host:Key").Value, configuration.GetSection("OpenWeatherApi:Host:Value").Value);
            });

            #region Lay du lieu dua len cache memory
            //Console.WriteLine("Bat dau lay du lieu cache dua len memory");
            //Console.WriteLine();
            #endregion

            services.AddTransient<IHttpClientHandler, HttpClientHandler>();
            services.AddTransient<IDateTime, DateTimeService>();
            //services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IOpenWeatherService, OpenWeatherService>();
            //services.AddTransient<ICsvFileBuilder, CsvFileBuilder>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IDateTime, DateTimeService>();

            //---custom--
            services.AddTransient<SchemaCurent, SchemaCurent>();
            services.AddTransient<IUnitOfWorkShare, UnitOfWorkContextShare>();
            services.AddTransient<IUnitOfWork, UnitOfWork_Context>();

            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IHomeRepository, HomeRepository>();

            services.AddTransient<IRegistryServices, RegistryServices>();
            services.AddTransient<IRegistryRepository, RegistryRepository>();

            services.AddTransient<ICaShareRepository, CaShareRepository>();
            services.AddTransient<ICaShareRepository, CaShareRepository>();

            services.AddTransient<IMediClinicServices, MediClinicServices>();
            services.AddTransient<IMediClinicRepository, MediClinicRepository>();

            services.AddTransient<IResultServices, ResultServices>();
            services.AddTransient<IResultRepository, ResultRepository>();

            services.AddTransient<ISysServices, SysServices>();
            services.AddTransient<ISysRepository, SysRepository>();

            services.AddTransient<ICateServices, CateServices>();
            services.AddTransient<ICateRepository, CateRepository>();
            services.AddTransient<ICacheRepository, CacheRepository>();

            services.AddTransient<IServicesServices, ServicesServices>();
            services.AddTransient<IServicesRepository, ServicesRepository>();

            services.AddTransient<IPhaServices, PhaServices>();
            services.AddTransient<IPhaRepository, PhaRepository>();

            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IPatientRepository, PatientRepository>();

            services.AddTransient<ITestShareRepository, TestShareRepository>();

            services.AddTransient<IStoreProduceService, StoreProduceService>();
            services.AddTransient<IStoreProduceRepository, StoreProduceRepository>();

            services.AddMemoryCache();

            //------------

            //services.AddAuthentication(options =>
            //    {
            //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })
            //    .AddJwtBearer(options =>
            //    {
            //        options.SaveToken = true;
            //        options.RequireHttpsMetadata = false;
            //        options.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidateIssuer = true,
            //            ValidateAudience = true,
            //            ValidAudience = configuration["JWT:ValidAudience"],
            //            ValidIssuer = configuration["JWT:ValidIssuer"],
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
            //        };
            //    })
            //    .AddIdentityServerJwt();

            return services;
        }
    }
}
