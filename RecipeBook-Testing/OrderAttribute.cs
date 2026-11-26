namespace RecipeBook_Testing
{
    public class OrderAttribute : Attribute
    {
        public int Value { get; }
        public OrderAttribute(int value)
        {
            value = Value;
        }
    }
}
