namespace TeknoramaBackOffice.Infrastructure.Tools
{
    public class JwtSettings
    {
        //Bu ayarları program.cs üzerinde düzenledik !
        /*
        ValidAudience = "http://localhost",
        ValidIssuer = "http://localhost",
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ardailhannnn.net6")),
        ValidateIssuerSigningKey = true
         */


        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "ardailhannnn.net6;";
        public const int Expire = 30;
    }
}
