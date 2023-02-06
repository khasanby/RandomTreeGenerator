namespace RandomTree;

public class TreeNode
{
    public TreeNode(int id, string name)
    {
        Id = id;
        Name = name;
        Children = new List<TreeNode>();
    }

    /// Gets and sets id of a tree node.
    /// </summary>
    public int Id { get; }
    
    /// <summary>
    /// Gets and sets name of a tree node.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets and sets child nodes of a tree node.
    /// </summary>
    public List<TreeNode> Children { get; set; }
}
