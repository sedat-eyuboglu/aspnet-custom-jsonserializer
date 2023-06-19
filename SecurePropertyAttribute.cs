[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class SecurePropertyAttribute : Attribute
{
    public SecurePropertyAttribute(string roles, object? maskValue)
    {
        Roles = roles;
        MaskValue = maskValue;
    }

    public string Roles { get; set; }
    public object? MaskValue { get; set; }
}