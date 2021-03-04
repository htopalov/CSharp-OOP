using System;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyList myList = new MyList();
            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int removeCount = int.Parse(Console.ReadLine());
            int[,] addOpsMatrix = new int[3, input.Length];
            string[,] removeOpsMatrix = new string[2, removeCount];
            for (int i = 0; i < input.Length; i++)
            {  
                addOpsMatrix[0,i] = addCollection.Add(input[i]);
                addOpsMatrix[1,i] = addRemoveCollection.Add(input[i]);
                addOpsMatrix[2,i] = myList.Add(input[i]);
            }
            for (int i = 0; i < removeCount; i++)
            {
                removeOpsMatrix[0, i] = addRemoveCollection.Remove();
                removeOpsMatrix[1, i] = myList.Remove();
            }

            for (int row = 0; row < addOpsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < addOpsMatrix.GetLength(1); col++)
                {
                    Console.Write(addOpsMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
            for (int row = 0; row < removeOpsMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < removeOpsMatrix.GetLength(1); col++)
                {
                    Console.Write(removeOpsMatrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
