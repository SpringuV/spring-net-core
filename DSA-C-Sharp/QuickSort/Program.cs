static void Swap(int[] array, int i, int j)
{
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}

static int Partition(int[] array, int left, int right)
{
    int pivotValue = array[right];
    int i = left;
    for (int j = left; j < right; j++)
    {
        // Compare each element with the pivot value
        // if less, it should go to the left side
        if (array[j] <= pivotValue)
        {
            Swap(array, i, j);
            i++;
        }
    }
    
    Swap(array, i, right);
    return i; // final pivot index
}

static void QuickSort(int[] array, int left, int right)
{
    if (left < right)
    {
        int pivotIndex = Partition(array, left, right);
        QuickSort(array, left, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, right);
    }
}


Console.WriteLine("QuickSort Algorithm Implementation");
Console.WriteLine("Input Length of Array:");
int length = int.Parse(Console.ReadLine());
int[] array = new int[length];
    
Console.WriteLine("Input Array:");
for (int i = 0; i < length; i++)
{
    array[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Array before sorting:" + string.Join(", ", array));
// sort the array
QuickSort(array, 0, array.Length - 1);
Console.WriteLine("Array after sorting:" + string.Join(", ", array));


