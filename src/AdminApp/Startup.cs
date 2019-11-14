using AdminApp.Data;
using IdentityServerAspNetIdentity.Data.Residentes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;

namespace AdminApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;


            // ******
            // BLAZOR COOKIE Auth Code (begin)
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                //local
                options.Authority = "http://localhost:5000";
                //DESA 
                //options.Authority = "http://192.168.1.216:5000";

                options.RequireHttpsMetadata = false;
                options.ClientId = "blazor";
                options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
                options.ResponseType = "code id_token";                
                
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;

                options.Scope.Add("api1");
                options.Scope.Add("offline_access");
                options.Scope.Add("roles");
                
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                    NameClaimType = "name",
                    RoleClaimType = "role", 
                                                           
                };
            });

            services.AddMvcCore(options =>
            {
               var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()                                                         
                   .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
                
            });
            // BLAZOR COOKIE Auth Code (end)
            // ******

            services.AddRazorPages();
            services.AddServerSideBlazor();            
            services.AddSingleton<WeatherForecastService>();
            services.AddSingleton<TokenContainer>();
            
            services.AddHttpContextAccessor();
            //services.AddScoped<IResidentesService, ResidentesService>();
            services.AddSingleton<ResidentesService>();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
                        
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();                
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            
        }
        
    }
}
