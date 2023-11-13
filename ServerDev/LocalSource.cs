using System.Globalization;

namespace ServerDev;

public class LocalSource : ILocalizationSource
{
    private readonly Dictionary<string, string> localizedStrings = new Dictionary<string, string>();

    public LocalSource() { }

    public string? Find(string key, CultureInfo cultureInfo)
    {
        string fullKey = FullKeyGenerate(key, cultureInfo);

        if (localizedStrings.TryGetValue(fullKey, out var localizedString))
        {
            return localizedString;
        }

        return null;
    }

    public void AddResource(Dictionary<string, string> localizeds, CultureInfo cultureInfo)
    {
        foreach (var localized in localizeds)
        {
            string fullKey = FullKeyGenerate(localized.Key, cultureInfo);

            localizedStrings.Add(fullKey, localized.Value);
        }
    }

    private string FullKeyGenerate(string key, CultureInfo cultureInfo)
    {
        return $"{key}_{cultureInfo.Name}";
    }
}
