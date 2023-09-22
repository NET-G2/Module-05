namespace Lesson07
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public int CompanyId { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Age: {Age}, Phone: {PhoneNumber}";
        }

        public static List<Person> GeneratePersons(int amount)
        {
            List<Person> persons = new List<Person>();
            for (int i = 1; i <= amount; i++)
            {
                Person person = new Person();
                person.Id = i;
                person.Name = "Person " + i;
                person.Age = new Random().Next(10, 25);
                person.PhoneNumber = "555-555-5555";
                person.CompanyId = i % 5 + 1;
                persons.Add(person);
            }

            return persons;
        }
    }
}