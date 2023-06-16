using System.Text.Json.Serialization.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<MyLocalizer>();
builder.Services.AddSingleton<LocalizedEntityDataContract>();
builder.Services.AddOptions<Microsoft.AspNetCore.Mvc.JsonOptions>().Configure<LocalizedEntityDataContract>((options, localizedEntityDataContract) =>
{
    options.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver()
    {
        Modifiers = 
        {
            localizedEntityDataContract.LocalizeAttribute
        }
    };
});

var app = builder.Build();

app.MapControllers();
app.Run();
