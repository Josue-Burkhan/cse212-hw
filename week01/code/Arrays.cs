public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length'
        // Step 2: Use a loop to fill each position with the correct multiple
        // Step 3: For index i, the value should be number * (i + 1)
        // Step 4: Return the filled array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Find the index where the rotation should split the list: data.Count - amount
        // Step 2: Use GetRange to slice from that index to the end (this will go at the beginning)
        // Step 3: Use GetRange to slice from the start to that index (this will go after the first part)
        // Step 4: Clear the original list and use AddRange to add both parts in new order

        int splitIndex = data.Count - amount;
        List<int> tail = data.GetRange(splitIndex, amount);
        List<int> head = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
