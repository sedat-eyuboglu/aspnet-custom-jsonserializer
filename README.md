# Customize ASP.Net JSON Serialization to Localize Data
Localization of UI is one of the key points in a global application. In some cases you may want to localize data. In this case we localized the `Summary` property of `WeatherForecast`. To apply a more custom logic you can modify `LocalizableProperty` attribute or `LocalizeAttribute` method of `LocalizedEntityDataContract`.
It is important to store localization values in a fast place like an inmemory dictionary. 
# Customize ASP.Net JSON Serialization to Apply Column Based Security