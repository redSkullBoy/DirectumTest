using System.Globalization;

namespace CodeAnalysis;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Сортировка, сортировка!");

        var keyValuePair = new KeyValuePair<int, string>[]
        {
            new KeyValuePair<int, string>(3,"Tom3"),
            new KeyValuePair<int, string>(4,"Tom4"),
            new KeyValuePair<int, string>(1,"Tom1"),
            new KeyValuePair<int, string>(2,"Tom2"),
        };

        //Func1(ref keyValuePair, 0, "Tom0"); //добавляет новый елемент и сортирует по ключу
        //FuncMy(ref keyValuePair, 0, "Tom0");
        Quicksort(ref keyValuePair, 0, "Tom0");

        foreach (KeyValuePair<int, string> innerpair in keyValuePair)
        {
            Console.WriteLine(innerpair.Key + " " + innerpair.Value);
        }
    }

    /// <summary>
    /// Обратный метод пузырька
    /// </summary>
    /// <param name="a"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    static void Func1(ref KeyValuePair<int, string>[] a, int key, string value)
    {
        Array.Resize(ref a, a.Length + 1);

        var keyValuePair = new KeyValuePair<int, string>(key, value);
        a[a.Length - 1] = keyValuePair;

        for (int i = 0; i < a.Length; i++)
        {
            for (int j = a.Length - 1; j > 0; j--)
            {
                if (a[j - 1].Key > a[j].Key)
                {
                    KeyValuePair<int, string> x;
                    x = a[j - 1];
                    a[j - 1] = a[j];
                    a[j] = x;
                }
            }
        }
    }

    /// <summary>
    /// Если не хочеться париться)
    /// </summary>
    /// <param name="pairArray"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    static void FuncMy(ref KeyValuePair<int, string>[] pairArray, int key, string value)
    {
        Array.Resize(ref pairArray, pairArray.Length + 1);

        var keyValuePair = new KeyValuePair<int, string>(key, value);
        pairArray[pairArray.Length - 1] = keyValuePair;

        Array.Sort(pairArray, (a, b) => a.Key.CompareTo(b.Key));
    }

    /// <summary>
    /// Быстрая сортировка
    /// </summary>
    /// <param name="pairArray"></param>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public static void Quicksort(ref KeyValuePair<int, string>[] pairArray, int key, string value)
    {
        Array.Resize(ref pairArray, pairArray.Length + 1);

        var keyValuePair = new KeyValuePair<int, string>(key, value);
        pairArray[pairArray.Length - 1] = keyValuePair;

        var quick = new QuickSort();
        quick.Start(ref pairArray);
    }
}
