namespace BookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Här kan vi lägga till services
            builder.Services.AddControllers();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Mycors", builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseCors("Mycors");

            //Här kan vi lägga till mapping
            app.MapControllers();  
            

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/books"); //om man är på default page så blir man redirectad till denna adress ist
            });

            app.Run();
        }
    }
}
