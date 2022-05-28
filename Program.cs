class Program
{

    static void Main(string[] args)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            Company company1 = new Company { Name = "Google" };
            Company company2 = new Company { Name = "Microsoft" };
            User user1 = new User { Name = "Tom", CompanyName = company1.Name };
            User user2 = new User { Name = "Bob", CompanyName = "Microsoft" };
            User user3 = new User { Name = "Sam", CompanyName = company2.Name };
            db.Companies.AddRange(company1, company2); // добавление компаний
            db.Users.AddRange(user1, user2, user3); // добавление пользователей
            db.SaveChanges();
            foreach (var user in db.Users.ToList())
            {
                Console.WriteLine($"{user.Name} работает в {user.Company?.Name}");
            }
        }

    }
}
