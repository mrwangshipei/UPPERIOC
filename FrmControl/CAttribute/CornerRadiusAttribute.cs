[AttributeUsage(AttributeTargets.Property)]
public class CornerRadiusAttribute : Attribute
{
    public string Note { get; }

    public CornerRadiusAttribute(string note)
    {
        Note = note;
    }
}
