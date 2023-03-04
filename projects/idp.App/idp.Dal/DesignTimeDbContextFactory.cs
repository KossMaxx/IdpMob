using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;

namespace idp.Dal
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            Debug.WriteLine(Directory.GetCurrentDirectory() + @"\Config.db");

            return new ApplicationContext(Directory.GetCurrentDirectory() + @"\Config.db");
        }
    }
}
