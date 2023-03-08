using ListingsMicroservice.Properties;
using MediatR;
using RealEstate.MediatR;

var builder = WebApplication.CreateBuilder(args);

// Run on port 9005
builder.WebHost.UseUrls("http://*:9005");

builder.Services
    .AddSwaggerGen()
    .AddServices()
    .Use_PostgreSQL_Listings_Context(builder.Configuration)
    .AddMediatR(typeof(MediatREntryPoint).Assembly); //Reference to the MediatR Assembly

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI();
}

app.UseHttpsRedirection().UseAuthorization().UseAuthentication();
app.MapControllers();

app.Run();
