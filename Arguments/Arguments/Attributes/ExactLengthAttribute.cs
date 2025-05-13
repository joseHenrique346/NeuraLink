namespace Arguments.Arguments.Attributes;

public class ExactLengthAttribute : Attribute
{
    public int Length { get; }

    public ExactLengthAttribute(int length)
    {
        Length = length;
    }
}