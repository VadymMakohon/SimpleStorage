namespace SimpleStorage
{
    public class Product
    {
        public int ID { get; private set; }
        public string Name { get; private set; }

        public Product(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}