static void BubbleSort(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        for (int j = 0; j < array.Length - i - 1; j++)
        {
            if (array[j] > array[j + 1])
            {
                int tmp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = tmp;
            }
        }
    }
}

Console.WriteLine("BubbleSort Algorithm Implementation");
Console.WriteLine("Input Length of Array:");
int length = int.Parse(Console.ReadLine());
int[] array = new int[length];
    
Console.WriteLine("Input Array:");
for (int i = 0; i < length; i++)
{
    array[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Array before sorting:" + string.Join(", ", array));
BubbleSort(array);
Console.WriteLine("Array after sorting:" + string.Join(", ", array));