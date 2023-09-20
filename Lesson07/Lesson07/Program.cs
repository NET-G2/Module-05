namespace Lesson07
{
    internal class Program
    {
        // Linq with lambda
        static void Main(string[] args)
        {
            List<Person> people = Person.GeneratePersons(100);
            List<Company> companies = Company.GenerateCompanies(5);

            #region Select

            //var ids = people.Select(p => p.Id).ToList();
            //var names = people.Select(p => p.Name).ToList();

            //ids.ForEach(id => Console.Write(id + " "));
            //Console.WriteLine();
            //names.ForEach(name => Console.WriteLine(name));
            //names.ForEach(Console.WriteLine);

            #endregion

            #region Where

            //var evenIds = people.Where(p => p.Id % 2 == 0)
            //    .Select(p => p.Id)
            //    .ToList();

            //evenIds.ForEach(Console.Write);
            //Console.WriteLine();

            // People with name length > 5 and
            // id is even and
            // age > 5
            //var people1 = people.Where(p => p.Name.Length > 5
            //                        && p.Id % 2 == 0 && p.Age > 5);
            //foreach (Person p in people1)
            //{
            //    Console.WriteLine(p);
            //}

            //Console.WriteLine();

            //var people2 = people.Where(p => p.Name.Length > 5)
            //    .Where(p => p.Id % 2 == 0)
            //    .Where(p => p.Age > 5)
            //    .Select(p => p.Name)
            //    .ToList();

            //people2.ForEach(Console.WriteLine);

            #endregion

            #region Order by

            //var orderedPeople = people.OrderBy(p => p.Name).ToList();
            //var orderedDescendingPeople = people.OrderByDescending(x => x.Id).ToList();

            //orderedPeople.ForEach(Console.WriteLine);
            //Console.WriteLine();
            //orderedDescendingPeople.ForEach(Console.WriteLine);

            //var orderedByAge = people.Where(x => x.Age > 8)
            //    .Select(x => x.Age)
            //    .OrderByDescending(x => x)
            //    .ToList();

            //orderedByAge.ForEach(Console.WriteLine);

            #endregion

            #region Then by

            //var orderedPeople2 = people.OrderBy(p => p.Age)
            //    .ThenBy(p => p.Id)
            //    .ToList();

            //orderedPeople2.ForEach(Console.WriteLine);


            #endregion

            #region Join

            //var joinedPeople = people.Join(companies,
            //    p => p.CompanyId,
            //    c => c.Id,
            //    (p, c) => new
            //    {
            //        PersonName = p.Name,
            //        PersonAge = p.Age,
            //        Company = c.Name
            //    })
            //    .Where(x => x.PersonAge > 15)
            //    .OrderByDescending(x => x.PersonAge)
            //    .ToArray();

            //var myType = new
            //{
            //    Id = 2,
            //    Niem = "John"
            //};

            //foreach (var res in joinedPeople)
            //{
            //    Console.WriteLine($"{res.PersonName}, {res.PersonAge}, {res.Company}");
            //}

            #endregion

            #region Group By

            //var groupedPeople = people.GroupBy(p => p.CompanyId);

            //groupedPeople.ToList().ForEach(group =>
            //{
            //    Console.WriteLine($"Company: {group.Key}");
            //    group.ToList().ForEach(Console.WriteLine);
            //    Console.WriteLine();
            //});

            //var groupedByAge = people
            //    .Where(x => x.Age > 18)
            //    .OrderByDescending(x => x.Age)
            //    .Select(x => new { x.Name, x.Age })
            //    .GroupBy(p => p.Age)
            //    .OrderByDescending(x => x.ToList().Count);

            //groupedByAge.ToList().ForEach(group =>
            //{
            //    Console.WriteLine($"Age: {group.Key}");
            //    var count = group.Count();
            //    group.ToList().ForEach(x => Console.Write(x.Name + " "));
            //    Console.Write($"({count})");
            //    Console.WriteLine();
            //});

            #endregion

        }
    }
}