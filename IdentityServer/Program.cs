namespace IdentityServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddIdentityServer()
                .AddInMemoryClients(Config.Clients)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddDeveloperSigningCredential();
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");
            app.UseIdentityServer();
            app.Run();
        }
    }
}
