using System.Globalization;

namespace ServerDev;

public class LocalizationManager
{
    public LocalizationManager() { }

    private readonly List<ILocalizationSource> sources = new List<ILocalizationSource>();

    public void RegisterSource(ILocalizationSource source)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        sources.Add(source);
    }

    public string? GetString(string key, Type sourceType, CultureInfo? cultureInfo = null)
    {
        if (cultureInfo == null)
        {
            cultureInfo = CultureInfo.CurrentCulture;
        }

        var selectedSource = sources.FirstOrDefault(s => s.GetType() == sourceType);
        if (selectedSource != null)
        {
            return GetString(key, cultureInfo, selectedSource);
        }

        return null;
    }

    public string? GetString(string key, CultureInfo? cultureInfo = null)
    {
        if (cultureInfo == null)
        {
            cultureInfo = CultureInfo.CurrentCulture;
        }

        foreach (var source in sources)
        {
            return GetString(key, cultureInfo, source);
        }

        return null;
    }

    private string? GetString(string key, CultureInfo cultureInfo, ILocalizationSource source)
    {
        var localizedString = source.Find(key, cultureInfo);

        if (localizedString != null)
        {
            return localizedString;
        }

        return null;
    }
}
