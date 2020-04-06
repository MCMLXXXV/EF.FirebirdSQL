using System.Data.Entity.Infrastructure;

namespace App.Database
{
    public class MyContextFactory : IDbContextFactory<Context>
    {
        public Context Create()
        {
            return new Context(Context.ConnectionString);
        }
    }
}
