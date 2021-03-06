﻿using AsyncInn.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;

namespace AsyncInn
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public IHostingEnvironment Environment { get; }

		public Startup(IHostingEnvironment environment)
		{
			Environment = environment;
			var builder = new ConfigurationBuilder().AddEnvironmentVariables();
			builder.AddUserSecrets<Startup>();
			Configuration = builder.Build();
		}

		// This method gets called by the runtime and is used to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();

			var connectionString = Environment.IsDevelopment()
							? Configuration["ConnectionStrings:DefaultConnection"]
							: Configuration["ConnectionStrings:ProductionConnection"];

			// Instantiates database // Implements singleton design pattern (standard for DBs in MVC)
			services.AddDbContext<AsyncInnDbContext>(options => options.UseSqlServer(connectionString));

			// Mappings between interface and service provider
			services.AddScoped<IHotelManager, HotelService>();
			services.AddScoped<IRoomManager, RoomService>();
			services.AddScoped<IAmenitiesManager, AmenitiesService>();
		}

		// This method gets called by the runtime and is used to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			
			// Set default route map
			app.UseMvc(route =>
			{
				route.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}"
					);
			});

			// Fallback or proof-of-life in case we haven't added sth more specific like app.UseMvc
			// Anything below app.Run will not be run
			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("Hello World!");
			});
		}
	}
}
