using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SeeWebMail.Common.Configuration;
using SeeWebMail.Core.Abstract;
using SeeWebMail.Core.Services;
using SeeWebMail.Infrastructure.Abstract;
using SeeWebMail.Infrastructure.Repositories;
using System;
using System.Text;

namespace SeeWebMail.Web
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();

			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "Angular/dist";
			});
			services.AddHttpContextAccessor();

			services.Configure<Authorization>(Configuration.GetSection(nameof(Authorization)));
			services.Configure<Mailbox>(Configuration.GetSection(nameof(Mailbox)));

			services.AddSingleton<ISqliteRepository>(new SqliteRepository(Configuration["ConnectionStrings:WebmailDatabase"]));
			services.AddTransient<IMailKitRepository, MailKitRepository>();

			services.AddTransient<IAuthorizationService, AuthorizationService>();
			services.AddTransient<IMailboxService, MailboxService>();

			//services.AddCors();
			services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Authorization:Secret"])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();

			//app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "api/{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "Angular";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
		}
	}
}
