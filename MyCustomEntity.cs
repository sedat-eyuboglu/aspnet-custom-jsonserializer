namespace aspnet_custom_jsonserializer;

public class MyCustomEntity
{
    public string? Name { get; set; }
    [SecureProperty("admin", default(int))]
    public int Value { get; set; }
}