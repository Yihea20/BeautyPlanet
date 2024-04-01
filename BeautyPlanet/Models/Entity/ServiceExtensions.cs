using BeautyPlanet.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BeautyPlanet.Models.Entity
{
    public static class ServiceExtensions
    {
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

    }
}
