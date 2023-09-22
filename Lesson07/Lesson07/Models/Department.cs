namespace Lesson07
{
    internal class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Company> GenerateCompanies(int amount)
        {
            List<Company> companies = new List<Company>();
            for (int i = 1; i <= amount; i++)
            {
                Company company = new Company();
                company.Id = i;
                company.Name = "Company " + i;
                companies.Add(company);
            }

            return companies;
        }
    }
}