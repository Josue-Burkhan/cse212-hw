public static class ArraySelector
{
    public static void Run()
    {
        var l1 = new[] { 1, 2, 3, 4, 5 };
        var l2 = new[] { 2, 4, 6, 8, 10};
        var select = new[] { 1, 1, 1, 2, 2, 1, 2, 2, 2, 1};
        var intResult = ListSelector(l1, l2, select);
        Console.WriteLine("<int[]>{" + string.Join(", ", intResult) + "}"); // <int[]>{1, 2, 3, 2, 4, 4, 6, 8, 10, 5}

        var a1 = new[] {1, 2, 3, 4};
        var a2 = new[] {10, 20, 30, 40};
        var selectArray = new[] {1, 1, 2, 2, 1, 1, 2, 2};
        var resultArray = ListSelector(a1, a2, selectArray);
        Console.WriteLine("<int[]>{" + string.Join(", ", resultArray) + "}"); // {1, 2, 10, 20, 3, 4, 30, 40}
    }

    private static int[] ListSelector(int[] list1, int[] list2, int[] select)
    {
        List <int> result = new List<int>();
        int i = 0, ii = 0;

        foreach (int s in select)
        {
            if (s == 1)
            {
                result.Add(list1[i]);
                i++;
            }
            else if (s == 2)
            {
                result.Add(list2[ii]);
                ii++;
            }
        }
        return result.ToArray();
    }
}