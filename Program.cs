using System.Text.Json.Serialization.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAuthentication().AddCookie();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<MyLocalizer>();
builder.Services.AddSingleton<AppEntityDataContract>();
builder.Services.AddOptions<Microsoft.AspNetCore.Mvc.JsonOptions>().Configure<AppEntityDataContract>((options, dataContract) =>
{
    options.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver()
    {
        Modifiers = 
        {
            dataContract.LocalizeAttribute,
            dataContract.ApplyColumnSecurity
        }
    };
});

var app = builder.Build();
app.UseAuthentication();
app.MapControllers();
app.Run();
