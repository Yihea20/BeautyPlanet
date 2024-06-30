using BeautyPlanet.DataAccess;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BeautyPlanet.Models.Entity
{
    public static class ServiceExtensions
    {
        public static void ConfigureNotification(this IServiceCollection services, IWebHostEnvironment environment)
        {
            string path = environment.WebRootPath + "\\FireBase\\beauty-planet-81ece-firebase-adminsdk-jwf55-49bde94bd2.json";
            string json = File.ReadAllText(path);
            var order = GoogleCredential.FromFile(path);
            FirebaseApp.Create(new AppOptions { Credential = order, });
        }
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<Person>(q =>
            {
                q.User.RequireUniqueEmail = true;
                q.SignIn.RequireConfirmedPhoneNumber = true;
                q.Password.RequiredUniqueChars = 0;
                q.Password.RequireNonAlphanumeric = false;
                q.Password.RequireUppercase = false;
            })
                ;
            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
            builder.AddTokenProvider("BeautyPlanetApi", typeof(DataProtectorTokenProvider<Person>));

            builder.AddEntityFrameworkStores<BeautyDbContext>().AddDefaultTokenProviders();
        }
        public static void ConfigureJwt(this IServiceCollection services, IConfiguration Configuration)
        {

            var jwtSetting = Configuration.GetSection("jwt");
            var key = JWTKey.KEY;
            services.AddAuthentication(
                o =>
                {
                    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSetting.GetSection("Issuer").Value,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                    };
                });
        }
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {
                error.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something Want Wrong in the {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorHandling
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString()
                        );
                    }
                });
            });
        }

    }
}
