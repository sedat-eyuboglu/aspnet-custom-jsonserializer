# Customize ASP.Net JSON Serialization to Localize Data
Localization of UI is one of the key points in a global application. In some cases you may want to localize data. In this case we localized the `Summary` property of `WeatherForecast`. To apply a more custom logic you can modify `LocalizableProperty` attribute or `LocalizeAttribute` method of `LocalizedEntityDataContract`.
It is important to store localization values in a fast place like an inmemory dictionary. 
# Customize ASP.Net JSON Serialization to Apply Column Based Security
`SecurePropertyAttribute` can be used to appy column security. If current user is not in the desired role, the property returns default value of the type. `ApplyColumnSecurity` is used to check roles and clear value of the property. As in the previous case, we used json serialization modifiers in the `Program.cs`.

    builder.Services.AddOptions<Microsoft.AspNetCore.Mvc.JsonOptions>().Configure<LocalizedEntityDataContract>((options, localizedEntityDataContract) =>
    {
        options.JsonSerializerOptions.TypeInfoResolver = new DefaultJsonTypeInfoResolver()
        {
            Modifiers = 
            {
                localizedEntityDataContract.LocalizeAttribute,
                localizedEntityDataContract.ApplyColumnSecurity
            }
        };
    });