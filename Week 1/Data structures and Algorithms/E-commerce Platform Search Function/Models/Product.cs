namespace E_commerce_Platform_Search_Function.Models
{
    public class Product
    {
        public int Id { get; }
        public string Name { get; }
        public string Category { get; }

        public Product(int id, string name, string category)
        {
            Id = id;
            Name = name;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Id,-4} | {Name,-20} | {Category}";
        }
    }
}
