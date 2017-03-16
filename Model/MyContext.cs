using Model.WCF;
using System.Data.Entity;


namespace Model
{
   public class MyContext : DbContext
    {
        //INDEX
        public  DbSet<CONFIG_TYPE> CONFIG_TYPE { get; set; }

        //WCF
        public DbSet<Employee> Employees { get; set; }

        //AngularJS
    }
}
