public interface IBook
{
    string Name();
}

public class Book : IBook
{
    public string Name()
    {
        return "hello Christopher";
    }
}
