using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CichyStrzalko.DAOSQL.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;

    public class DataContextFactory
        : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Catalog");

            Directory.CreateDirectory(appDataPath);

            string dbPath = Path.Combine(appDataPath, "catalog.db");

            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new DataContext(optionsBuilder.Options);
        }
    }

}
