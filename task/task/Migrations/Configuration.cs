namespace task.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<task.UserDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(task.UserDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (!context.People.Any())
            {
                context.People.AddOrUpdate(new Person
                {
                    Name = "Eli",
                    Surname = "Eliyev"
                },
                new Person
                {
                    Name = "Tofiq",
                    Surname = "Behramov"
                },
                 new Person
                 {
                     Name = "Hafiz",
                     Surname = "Behramov"
                 }
                );
                
            }
        }
    }
}
