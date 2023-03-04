namespace OptionTool.Domain
{
    /// <summary> Used for normalizing object model and is basis for some generic methods in repository. </summary>
    public class BaseEntity
    {
        /// <summary> Standard Primary Key field. </summary>
        public int Id { get; set; }
    }
}