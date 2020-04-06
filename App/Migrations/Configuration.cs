namespace App.Database.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<App.Database.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(App.Database.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            Staff s01 = new Staff() { FirstName = "Fabiola", LastName = "Jackson" };
            Staff s02 = new Staff() { FirstName = "Mireya", LastName = "Copeland", Manager = s01 };
            Staff s03 = new Staff() { FirstName = "Genna", LastName = "Serrano", Manager = s02 };
            Staff s04 = new Staff() { FirstName = "Virgie", LastName = "Wiggins", Manager = s02 };
            Staff s05 = new Staff() { FirstName = "Janette", LastName = "David", Manager = s01 };
            Staff s06 = new Staff() { FirstName = "Marcelene", LastName = "Boyer", Manager = s05 };
            Staff s07 = new Staff() { FirstName = "Venita", LastName = "Daniel", Manager = s05 };
            Staff s08 = new Staff() { FirstName = "Kali", LastName = "Vargas", Manager = s01 };
            Staff s09 = new Staff() { FirstName = "Layla", LastName = "Terrell", Manager = s07 };
            Staff s10 = new Staff() { FirstName = "Bernadine", LastName = "Houston", Manager = s07 };

            context.Staffs.AddRange(new[] { s01, s02, s03, s04, s05, s06, s07, s08, s09, s10 });
            context.SaveChanges();
        }
    }
}
