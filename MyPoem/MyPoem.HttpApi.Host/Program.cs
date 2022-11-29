namespace MyPoem.HttpApi.Host
{

    public class Program
    {
        public async static Task<int> Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseAutofac();
            await builder.AddApplicationAsync<MyPoemHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;

        }
    }
}
