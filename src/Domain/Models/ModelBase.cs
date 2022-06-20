namespace Domain.Models;

/// <summary>
/// base model for database models
/// </summary>
public class ModelBase : ModelBaseNoId
{
    /// <summary>
    /// entity id
    /// </summary>
    public long Id { get; set; }

}

/// <summary>
/// Datamodel for result of list include items and total count
/// </summary>
/// <typeparam name="TModelBase"></typeparam>
public class PaginatedResult<TModelBase>
    where TModelBase : class
{
    /// <summary>
    /// List of items which match by query 
    /// </summary>
    public List<TModelBase> Items { get; set; }

    /// <summary>
    /// Total count of objects which match by query
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Check item 
    /// </summary>
    /// <returns>true if items has at least one item</returns>
    public bool HasAnyItems()
    {
        if (Items == null || Items.Count == 0)
            return false;

        return true;
    }
}

/// <summary>
/// use this base model for models that have custom primary key
/// </summary>
public class ModelBaseNoId
{
    /// <summary>
    /// consider when database record created (computed column)
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// consider when database record modified
    /// </summary>
    public DateTime? ModifiedAt { get; set; }
}