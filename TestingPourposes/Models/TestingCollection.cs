namespace TestingPourposes.Models
{
    public class TestingCollection
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public TestingCollection(int age, string name) 
        {
            Age = age;
            Name = name;
        }
    }
}
