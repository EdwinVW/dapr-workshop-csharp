// create web-app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IVehicleInfoRepository, InMemoryVehicleInfoRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// configure web-app
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// configure routing
app.MapControllers();

// let's go!
app.Run("http://localhost:6002");
