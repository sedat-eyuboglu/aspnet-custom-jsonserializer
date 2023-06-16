[AttributeUsage(AttributeTargets.Property)]
public class LocalizablePropertyAttribute : Attribute
{
    public LocalizablePropertyAttribute()
    {
        KeyPrefix = string.Empty;
    }

    public string KeyPrefix { get; set; }

    public string? LocalizationKey { get; set; }

}