using System.Globalization;

namespace ServerDev;

internal class Program
{
    static void Main(string[] args)
    {
        var localizationManager = new LocalizationManager();

        var localSource = new LocalSource();

        var resourceStrings = new Dictionary<string, string>
        {
            {"HelloKey", "Hello from Resources!"}
        };
        localSource.AddResource(resourceStrings, new CultureInfo("en-US"));

        var resourceStringsRU = new Dictionary<string, string>
        {
            {"HelloKey", "Что-то на русском"}
        };
        localSource.AddResource(resourceStringsRU, new CultureInfo("ru-RU"));

        localizationManager.RegisterSource(localSource);

        string key = "HelloKey";
        CultureInfo cultureInfo = new CultureInfo("ru-RU");

        var localizedString = localizationManager.GetString(key, typeof(LocalSource), cultureInfo);

        Console.WriteLine(localizedString ?? "нет значения");
    }
}
