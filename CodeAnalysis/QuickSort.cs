namespace CodeAnalysis;

public class QuickSort
{
    //быстрая сортировка
    public void Start(ref KeyValuePair<int, string>[] pairArray, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return;
        }

        var pivotIndex = Partition(ref pairArray, minIndex, maxIndex);
        Start(ref pairArray, minIndex, pivotIndex - 1);
        Start(ref pairArray, pivotIndex + 1, maxIndex);

        return;
    }

    public void Start(ref KeyValuePair<int, string>[] pairArray)
    {
        Start(ref pairArray, 0, pairArray.Length - 1);
        return;
    }

    //метод для обмена элементов массива
    void Swap(ref KeyValuePair<int, string> x, ref KeyValuePair<int, string> y)
    {
        var t = x;
        x = y;
        y = t;
    }

    //метод возвращающий индекс опорного элемента
    int Partition(ref KeyValuePair<int, string>[] pairArray, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (pairArray[i].Key < pairArray[maxIndex].Key)
            {
                pivot++;
                Swap(ref pairArray[pivot], ref pairArray[i]);
            }
        }

        pivot++;
        Swap(ref pairArray[pivot], ref pairArray[maxIndex]);
        return pivot;
    }
}
