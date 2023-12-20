using System;
using System.Xml.Linq;

namespace Algoritmos;

public class BinarySearchTree
{
    public Node<int> Root { get; set; }

    public BinarySearchTree(int value = int.MinValue)
    {
        if (value != int.MinValue)
        {
            Root = new Node<int>(value);
        }
    }

    public void AddValue(int value)
    {
        if (Root == null)
            Root = new Node<int>(value);
        else if (value < Root.Value)
            Root.LeftNode = AddValueInNode(Root.LeftNode, value);
        else
            Root.RightNode = AddValueInNode(Root.RightNode, value);
    }

    private Node<int> AddValueInNode(Node<int> node, int value)
    {
        if (node == null)
            return new Node<int>(value);
        else if (value < node.Value)
            node.LeftNode = AddValueInNode(node.LeftNode, value);
        else
            node.RightNode = AddValueInNode(node.RightNode, value);

        return node;
    }
}

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> LeftNode { get; set; }
    public Node<T> RightNode { get; set; }

    public Node(T value)
    {
        Value = value;
    }
}
