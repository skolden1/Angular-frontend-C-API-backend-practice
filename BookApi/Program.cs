namespace BookApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //H�r kan vi l�gga till services
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

            //H�r kan vi l�gga till mapping
            app.MapControllers();  //S� fort en httpreq skickas s� k�nner denna kod av alla httpget/httpost attributer
            //Och d� letar han upp r�tt get/postmetod s� att dom k�rs

            app.MapGet("/", () =>
            {
                return Results.Redirect("/api/books"); //om man �r p� default page s� blir man redirectad till denna adress ist
            });

            app.Run();
        }
    }
}
