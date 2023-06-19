namespace aspnet_custom_jsonserializer;

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    
    [LocalizedProperty(KeyPrefix = "WeatherForecast_Summary")]
    [SecureProperty("customer", default(int))]
    public string? Summary { get; set; }
}
