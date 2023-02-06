namespace RandomTree;

public class TreeItem
{
    public TreeItem(int id, string name, int parentId)
    {
        Id = id;
        Name = name;
        ParentId = parentId;
    }

    /// Gets and sets id of a tree item.
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Gets and sets name of a tree item.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets and sets parent id of a tree item.
    /// </summary>
    public int ParentId { get; }
}
