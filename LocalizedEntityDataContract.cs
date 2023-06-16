using System.Text.Json.Serialization.Metadata;
public class LocalizedEntityDataContract
{
    private const string HEADER_DFAPI_CONTENT_CULTURE = "DfApi_Content_Culture";
    private const string LOCALIZATION_KEY_SEP = "_";
    
    private readonly IHttpContextAccessor? httpContextAccessor;
    private readonly MyLocalizer? localizer;
    public LocalizedEntityDataContract(IHttpContextAccessor httpContextAccessor, MyLocalizer localizer)
    {
        this.httpContextAccessor = httpContextAccessor;
        this.localizer = localizer;
    }

    public void LocalizeAttribute(JsonTypeInfo typeInfo)
    {
        if(localizer is not null && typeInfo.Kind == JsonTypeInfoKind.Object)
        {
            foreach(var propertyInfo in typeInfo.Properties)
            {
                var localizablePropertyAttributes = propertyInfo.AttributeProvider?.GetCustomAttributes(typeof(LocalizablePropertyAttribute), true) ?? Array.Empty<object>();
                var localizablePropertyAttribute = localizablePropertyAttributes.Length == 1 ? (LocalizablePropertyAttribute)localizablePropertyAttributes[0] : null;
                if(localizablePropertyAttribute is not null)
                {
                    var getProperty = propertyInfo.Get;
                    if(getProperty is not null)
                    {
                        var contentCulture = ResolveCulture();
                        if(contentCulture.Length > 0)
                        {
                            propertyInfo.Get = (obj) => 
                            {
                                var noneLocalizedValue = getProperty.Invoke(obj);
                                var localizationKey = string.Concat(localizablePropertyAttribute.KeyPrefix, LOCALIZATION_KEY_SEP, noneLocalizedValue);
                                var result = localizer.GetString(localizationKey, contentCulture);
                                return result;
                            };
                        }
                    }
                }
            }
        }
    }

    private string ResolveCulture()
    {
        if(httpContextAccessor is not null)
        {
            var headers = httpContextAccessor.HttpContext?.Request.Headers;
            if(headers is not null && headers.ContainsKey(HEADER_DFAPI_CONTENT_CULTURE))
            {
                return headers[HEADER_DFAPI_CONTENT_CULTURE].ToString();
            }
            else
            {
                return "tr-TR";
            }
        }
        return string.Empty;
    }
}