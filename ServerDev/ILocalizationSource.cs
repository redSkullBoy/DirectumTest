using System.Globalization;

namespace ServerDev;

public interface ILocalizationSource
{
    string? Find(string key, CultureInfo cultureInfo);
}
