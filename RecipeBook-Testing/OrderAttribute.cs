namespace RecipeBook_Testing
{
    //Järjesti klass, mis omab omadusi, mille järgi teste järjestada saab
    public class OrderAttribute : Attribute
    {
        public int Value { get; } //Väärtus, set puudub, et testimise ajal väärtust muuta ei saaks.
        public OrderAttribute(int value) //Konstruktor kus omistatakse väärtus
        {
            value = Value;
        }
    }
}
