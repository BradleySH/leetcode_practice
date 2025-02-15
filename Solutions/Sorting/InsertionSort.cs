namespace NeetcodeSolutions.Solutions.Sorting;

public class InsertionSort
{
    public static int[] Sort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int j = i - 1;
            while (j >= 0 && arr[j + 1] < arr[j])
            {
                int tmp = arr[j + 1];
                arr[j + 1] = arr[j];
                arr[j] = tmp;
                j--;
            }
        }

        return arr;
    }

    public static int[] Recursive(int[] arr)
    {
        return Recursive(arr, 1);
    }

    private static int[] Recursive(int[] arr, int i)
    {
        if (i >= arr.Length) return arr;

        int j = i - 1;
        while (j >= 0 && arr[j + 1] < arr[j])
        {
            int tmp = arr[j + 1];
            arr[j + 1] = arr[j];
            arr[j] = tmp;
            j--;
        }

        return Recursive(arr, i + 1);
    }

}