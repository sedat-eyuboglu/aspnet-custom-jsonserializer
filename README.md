# Customize ASP.Net JSON Serialization to Localize Data
Localization of UI is one of the key points in a global application and there are numerous solutions for it. In some cases you may want to localize data. As for the localization of data, it is more custom requirement and there is no so common options for it. In this case we localized the `Summary` property of `WeatherForecast` entity. To apply a more custom logic you can modify `LocalizedPropertyAttribute` attribute or `LocalizeAttribute` method of the `AppEntityDataContract`.
>It is important to store localization values in a fast place like an inmemory dictionary.

# Customize ASP.Net JSON Serialization to Apply Column Based Security
`SecurePropertyAttribute` can be used to appy column based security. If current user is not in the one of desired roles, the property returns `maskedValue`. `ApplyColumnSecurity` is used to check roles and set value of the property. As in the previous case, we used json serialization modifiers in the `Program.cs`.

```csharp
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
```

# Run Demo
1. Press `F5`.
2. Call `GetWeatherForecast`.
3. Check `Summary` field. Since you have not logged in yet and declare the property as secure, expect to see `null`.
4. Call `Login`.
5. Call `GetWeatherForecast`.
6. Check `Summary` field. Expect to see localized value instead set inside the action.
7. Call `GetMyCustomEntity`.
8. Check `Value` field. Since you have logged in as `customer`, expect to see `0`.
9. Call `LoginAsAdmin`.
10. Call `GetMyCustomEntity`.
11. Check `Value` field. Expect to see a random integer value.