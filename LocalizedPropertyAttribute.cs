[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class LocalizedPropertyAttribute : Attribute
{
    public LocalizedPropertyAttribute()
    {
        KeyPrefix = string.Empty;
    }

    public string KeyPrefix { get; set; }

    public string? LocalizationKey { get; set; }
}