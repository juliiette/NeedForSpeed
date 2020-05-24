using System;
using System.Configuration;
using System.Windows;
using AutoMapper;
using Business.Abstract.Services;
using Business.Implementation.Mapper;
using Business.Implementation.Services;
using Data.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ViewModel;

namespace View
{
    public partial class App : Application
    {
        public static IServiceProvider DependencyResolver { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            var connectionString = ConfigurationManager.ConnectionStrings["NeedForSpeedConnection"].ConnectionString;
            services.AddDbContext<NFSContext>(opt => opt.UseSqlServer(connectionString));

            var mapperConfig = new MapperConfiguration(cfg => { cfg.AddProfile(new MyAutoMapper()); });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddTransient<IDetailService, DetailService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<MainWindowVModel, MainWindowVModel>();

            DataServices.ConfigureServices(services);

            DependencyResolver = services.BuildServiceProvider();
        }
    }
}