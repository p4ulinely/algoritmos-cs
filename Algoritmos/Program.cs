using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Algoritmos;

public class Programa
{
    public static int NormalSearch(int[] arr, int target)
    {
        Console.WriteLine("NormalSearch:");
        for(int i = 0; i<arr.Length; i++)
        {
            if (arr[i] == target)
                return i;
        }

        return -1;
    }

    public static int BinarySearch(int[] arr, int target)
    {
        Console.WriteLine("BinarySearch:");
        int
            low = 0,
            high = arr.Length - 1;

        while (low <= high)
        {
            int middle = (low+high)/2;

            if (arr[middle] == target)
                return middle;
            else if (target < arr[middle])
                high = middle - 1;
            else if (target > arr[middle])
                low = middle + 1;
        }

        return -1;
    }

    public static int Returning1() => 1;
    public static int Returning2() => 2;

    public static T ReturningAnyType<T>(Func<T> data)
    {
        return data.Invoke();
    }

    public static IList<IList<int>> BreadthFirstSearch_LeetCodexxx(Node<int> root)
    {
        IList<IList<int>> result = new List<IList<int>>();
        
        var myQ = new Queue<Node<int>>();
        myQ.Enqueue(root);

        // var arr = new int[] {10, 25, 15, 8, 9, 6, 18, 11};
        while (myQ.Count > 0)
        {
            var row = new List<int>();
            int qCount = myQ.Count;
            for (int i = 0; i < qCount; i++)
            {
                var current = myQ.Dequeue();
                row.Add(current.Value);

                if (current.LeftNode != null)
                    myQ.Enqueue(current.LeftNode);

                if (current.RightNode != null)
                    myQ.Enqueue(current.RightNode);
            }
            
            result.Add(row);
        }
        // result.Add(new List<int>());

        return result;
    }

    public static int DepthFirstSearch_LeetCode129(Node<int> root)
    {
        int result = 0;
        var resultAsText = new List<string>();
        string currentValue = "";

        var myStack = new Stack<Tuple<Node<int>, string>>();
        myStack.Push(new Tuple<Node<int>, string>(root, ""));

        while (myStack.Count > 0)
        {
            var current = myStack.Pop();

            var currentNode = current.Item1;
            currentValue = current.Item2;

            if (currentNode == null)
                continue;

            currentValue += currentNode.Value;

            if (currentNode.LeftNode == null
                && currentNode.RightNode == null)
            {
                resultAsText.Add(currentValue);
            }
            else
            {
                myStack.Push(
                    new Tuple<Node<int>, string>(currentNode.RightNode, currentValue));

                myStack.Push(
                    new Tuple<Node<int>, string>(currentNode.LeftNode, currentValue));
            }
        }

        foreach (var path in resultAsText)
        {
            Console.WriteLine(path);
            int.TryParse(path, out int pathAsInt);
            result += pathAsInt;
        }

        return result;
    }

    public static IList<int> DepthFirstSearchRecursive(Node<int> root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        Console.WriteLine(root.Value);

        DepthFirstSearchRecursive(root.LeftNode);
        DepthFirstSearchRecursive(root.RightNode);

        return result;
    }

    public static int[] BubbleSortOfInts(int[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {

            for (int j = 0; j < i; j++)
            {
                //Console.WriteLine(i + ": " + string.Join(", ", arr));
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        return arr;
    }

    public static string DepthFirstSearch(Node<int> root, int target = int.MinValue)
    {
        var result = new List<int>();
        var myStack = new Stack<Node<int>>();

        myStack.Push(root);
        int depth = 0;

        while (myStack.Count > 0)
        {
            var current = myStack.Pop();
            result.Add(current.Value);

            //if (target > int.MinValue)
            //{
            //    if (target == current.Value)
            //    {
            //        return depth.ToString();
            //    }

            //    if (current.LeftNode == null
            //        && current.RightNode == null)
            //    {

            //        depth--;
            //    }
            //    else
            //        depth++;
            //}

            if (current.RightNode != null)
                myStack.Push(current.RightNode);
            if (current.LeftNode != null)
                myStack.Push(current.LeftNode);
        }

        return string.Join(", ", result);
    }

    public static string DFSDifferent(Node<int> root)// Same as DepthFirstSearch_LeetCode129()
    {
        // 10, 25, 15, 8, 9, 6
        var result = new List<string>();
        string store = "";
        var myStack = new Stack<Tuple<Node<int>, string>>();

        myStack.Push(new Tuple<Node<int>, string>(root, store));
        // 10 | "" "10"
        //  | "" "10"
        // 8 25 | "" "10"
        //  25 | "10" "108"
        while (myStack.Count > 0)
        {
            var current = myStack.Pop();
            var currentNode = current.Item1;
            var currentStore = current.Item2;

            if (currentNode == null)
                continue;

            store = currentStore + currentNode.Value;

            if (currentNode.RightNode == null
                && currentNode.LeftNode == null)
            {
                result.Add(store);
            }
            else
            {
                if (currentNode.RightNode != null)
                    myStack.Push(new Tuple<Node<int>, string>(currentNode.RightNode, store));
                if (currentNode.LeftNode != null)
                    myStack.Push(new Tuple<Node<int>, string>(currentNode.LeftNode, store));
            }

        }

        return string.Join(", ", result);
    }

    public static string BreadthFirstSearch(Node<int> root)
    {
        var result = new List<int>();
        var myQueue = new Queue<Node<int>>();

        myQueue.Enqueue(root);

        while (myQueue.Count > 0)
        {
            int qCount = myQueue.Count;

            for (int i = 0; i < qCount; i++)
            {
                var current = myQueue.Dequeue();

                result.Add(current.Value);

                if (current.LeftNode != null)
                    myQueue.Enqueue(current.LeftNode);
                if (current.RightNode != null)
                    myQueue.Enqueue(current.RightNode);
            }
        }

        return string.Join(", ", result);
    }

    public static void Main()
    {
        string name = "Paulinely";
        Console.WriteLine(name.GetHashCode());

        using (var sha = new SHA256Managed())
        {
            var data = Encoding.UTF8.GetBytes(name);
            var hash = sha.ComputeHash(data);
            
            Console.WriteLine(BitConverter.ToString(hash).Replace("-", ""));
        }
        return;
        //var arr99 = new int[] { 10, 25, 15, 8, 9, 6, 18, 11 };

        //var arr55 = new NewOrder[2] { new NewOrder(4, DateTime.Now), new NewOrder(2, DateTime.Now) };
        ///////////////
        //Console.WriteLine($"{string.Join(", ", arr55.Select(o => o.Id))}");
        //var ggg = BubbleSort.Sort(arr55);
        //foreach (var item in ggg)
        //{
        //    Console.WriteLine(item.Id);
        //}

        //Console.WriteLine($"{string.Join(", ", arr99)}");
        ////Console.WriteLine($"{string.Join(", ", BubbleSortOfInts(arr99))}");
        //Console.WriteLine($"{string.Join(", ", BubbleSort.Sort(arr99))}");
        //return;

        ///////////////
        //var myStack = new Stack<Node<int>>();
        //myStack.Push(new Node<int>(10));
        //myStack.Push(new Node<int>(8));
        //myStack.Push(new Node<int>(6));
        //var text = string.Join("", myStack.Select(n => n.Value));
        //Console.WriteLine(text);
        //return;
        //////////////////////////
        //var watch = new Stopwatch();
        //var order1 = new NewOrder(1, DateTime.Now);

        var mySortedNums = new int[] {2,4,6,8,13,14,15,16,17,18,19,20,21,22};
        var mySortedNums2 = new int[] {11,12,13,14};

        var manyNums = Enumerable.Range(1, 10000)
            .ToList();

        // manyNums.Sort();

        // var manyNumsAsArr = manyNums.ToArray();

        // Console.WriteLine($"index: {Array.IndexOf(manyNumsAsArr, 9990)}");

        // watch.Start();
        // Console.WriteLine($"{NormalSearch(manyNumsAsArr, 9990)}");
        // watch.Stop();
        // Console.WriteLine($"{watch.Elapsed}");
        // watch.Start();
        // Console.WriteLine($"{BinarySearch(manyNumsAsArr, 9990)}");
        // Console.WriteLine($"{watch.Elapsed}");

        // Func<int[], int, int> MySearchDelegate = NormalSearch;
        // MySearchDelegate += BinarySearch;

        // Console.WriteLine("---------------");

        // Func<int> MyFuncsDelegate = Returning2;
        // MyFuncsDelegate += Returning1;

        // Console.WriteLine($"MyFuncsDelegate: {MyFuncsDelegate()}"); // returns the value of the last func

        // var a = new {a = "aaaaaaa", b = "bbbbbbb"};

        // Console.WriteLine(ReturningAnyType(() => a));
        // Console.WriteLine(ReturningAnyType(() => 1));

        Console.WriteLine("---------------");

        var bst = new BinarySearchTree();

        var arr = new int[] { 10, 25, 15, 8, 9, 6, 18, 11 };
        //var arr = new int[] { 1, 4, 3, 8, 9, 6, 2, 7 };

        foreach (var item in arr)
        {
            bst.AddValue(item);
        }

        //Console.WriteLine("---------------");
        //Console.WriteLine($"BFS: {BreadthFirstSearch(bst.Root)}");

        //var arrFromBFS = BreadthFirstSearch(bst.Root);

        //foreach (var arrs in arrFromBFS)
        //{
        //    Console.WriteLine($"{string.Join(", ", arrs)}");
        //}

        //Console.WriteLine("---------------");
        //Console.WriteLine($"DFS: {DepthFirstSearch(bst.Root)}");

        Console.WriteLine("---------------");
        Console.WriteLine($"DepthFirstSearch_LeetCode129: {DepthFirstSearch_LeetCode129(bst.Root)}");
        Console.WriteLine($"DFSDifferent: {DFSDifferent(bst.Root)}");

        //Console.WriteLine("DFS2: ");
        //DepthFirstSearch_LeetCode129(bst.Root, new List<int>());


        //foreach (var arrs in arrFromDFS)
        //{
        //    Console.WriteLine($"{string.Join(", ", arrs)}");
        //}
    }
}