[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class SecurePropertyAttribute : Attribute
{
    public SecurePropertyAttribute(string roles)
    {
        Roles = roles;
    }
    public string Roles { get; set; }
}