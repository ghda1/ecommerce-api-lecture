
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.MapGet("/", () => "Api running well");


app.UseHttpsRedirection();
app.MapControllers();
app.Run();






// MVC => Models, Views, Controllers
