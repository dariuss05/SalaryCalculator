using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SalaryCalculator
{
    public class DatabaseConfig : DbContext
    {
        public DatabaseConfig() : base("MySqlConnection") { }

        public DbSet<Angajat> angajati { get; set; }
        public DbSet<Taxa> taxe { get; set; }
    }
}