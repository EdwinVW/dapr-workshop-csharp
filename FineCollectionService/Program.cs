// create web-app
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IFineCalculator, HardCodedFineCalculator>();

builder.Services.AddHttpClient();
builder.Services.AddSingleton<VehicleRegistrationService>();

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
app.Run("http://localhost:6001");
