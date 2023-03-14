namespace TesteEF.Models.Departments
{
    public class Departments
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Departments(int id,string name )
        {
            Name = name;
            Id = id;
        }
    }
}
