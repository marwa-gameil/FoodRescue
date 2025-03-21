using FoodRescue.Infrastructure;
using FoodRescue.Infrastructure.Data;
using FoodRescue.Presentation.Utilities;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
var builder = WebApplication.CreateBuilder(args);
Env.Load();
builder.Configuration.AddEnvironmentVariables();


builder.Services.Configure(builder.Configuration);


var app = builder.Build();



app.Configure();

app.Run();
