namespace WebApi_PracServer.models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public Person (int id, string name, string email, int age)
        {
            Id = id;
            this.Name = name;
            this.Email = email;
            this.Age = age;
        }
    }
}
