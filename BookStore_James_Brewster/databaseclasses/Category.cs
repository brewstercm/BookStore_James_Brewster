namespace BlazorBookStore1
{
    public class Category
    {
        public int catID { get; set; }
        public string name { get; set; }

        public Category(int catID, string name)
        {
            this.catID = catID;
            this.name = name;
        }
    }
}