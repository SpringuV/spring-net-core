static void InsertionSort(int[] array)
{
    for (int i = 1; i < array.Length; i++)
    {
        int post = i - 1, value = array[i];
        while (post>= 0 && value < array[post])
        {
            array[post + 1] = array[post];
            --post;
        }
        array[post + 1] = value;
    }
}

Console.WriteLine("InsertionSort Algorithm Implementation");
Console.WriteLine("Input Length of Array:");
int length = int.Parse(Console.ReadLine());
int[] array = new int[length];
    
Console.WriteLine("Input Array:");
for (int i = 0; i < length; i++)
{
    array[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Array before sorting:" + string.Join(", ", array));
InsertionSort(array);
Console.WriteLine("Array after sorting:" + string.Join(", ", array));