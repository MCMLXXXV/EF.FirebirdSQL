using App.Database;
using System;
using System.Linq;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Context db = new Context(Context.ConnectionString))
            {
                var query = from staff in db.Staffs
                            orderby staff.Manager.StaffId
                            select staff;

                foreach (Staff staff in query)
                {
                    Console.WriteLine($"{staff.FullName,-30} {staff.Manager?.FullName,-30}");
                }

                Console.ReadKey();
            }
        }
    }
}
