using RandomTree;

public class Program
{
    public static void Main(string[] args)
    {        
        var random = new Random();
        int count = 5;
        var treeItems = new TreeItem[count];

        for(int i = 0; i < count; i++)
        {
            var id = i+1;
            var name = "node-" + id;
            var parentId = random.Next(0, id);

            treeItems[i] = new TreeItem(id, name, parentId);
        }

        PrintTreeItems(treeItems);
        var root = GenerateTree(treeItems);
        DepthFirstTraversal(root);
    }

    /// <summary>
    /// Generates tree data structure using array of tree items and root of tree node.
    /// Returns the root of the tree.
    /// </summary>
    public static TreeNode GenerateTree(TreeItem[] treeItems)
    {
        // setting the root node with id zero by default.
        var root = new TreeNode(0, "root");
        // using dictionary help us to boost performance.
        var treeNodes = new Dictionary<int, TreeNode> {
            { root.Id, root }
        };

        foreach (var item in treeItems)
        {
            var test = new TreeNode(item.Id, item.Name);
            treeNodes.Add(item.Id, test);

            if (treeNodes.TryGetValue(item.ParentId, out var tree))
            {
                // if dictionary has node with item's parent id, add item to it as a child.
                tree.Children.Add(test);
            }
        }

        return root;
    }

    /// <summary>
    /// Traversing and printing out node info
    /// using Depth First algorithm.
    /// </summary>
    public static void DepthFirstTraversal(TreeNode root)
    {
        var stackOfNodes = new Stack<TreeNode>();
        stackOfNodes.Push(root);

        while(stackOfNodes.Count > 0)
        {
            TreeNode node = stackOfNodes.Pop();
            Console.WriteLine($"Id={node.Id},  Name={node.Name}");
            if (node.Children.Count > 0)
            {                
                foreach(var childNode in  node.Children)
                {
                    stackOfNodes.Push(childNode);
                }
            }
        }
    }

    /// <summary>
    /// Traversing and printing out node info
    /// using Breadth First algorithm (level-order traversal).
    /// </summary>
    public static void BreadthFirstTraversal(TreeNode root)
    {
        var queOfNodes = new Queue<TreeNode>();
        queOfNodes.Enqueue(root);
        while(queOfNodes.Count > 0)
        {
            var node = queOfNodes.Dequeue();
            Console.WriteLine($"Id={node.Id},  Name={node.Name}");
            foreach (var childNode in node.Children)
            {
                queOfNodes.Enqueue(childNode);
            }
        }
    }

    /// <summary>
    /// Prints out all generated tree items in console.
    /// </summary>
    private static void PrintTreeItems(TreeItem[] treeItems)
    {

        foreach (var item in treeItems)
        {
            Console.WriteLine($"Id:{item.Id}     Name:{item.Name}     ParentId:{item.ParentId}");
        }
    }
}