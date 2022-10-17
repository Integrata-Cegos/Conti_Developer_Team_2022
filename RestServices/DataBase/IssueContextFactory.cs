using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase;
internal class IssueContextFactory : IDesignTimeDbContextFactory<IssueContext>
{
    public IssueContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<IssueContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseSqlServer("data source = qrbg.conti.de; initial catalog = training; persist security info=True; Integrated Security = SSPI; Database=c1tt");
        return new IssueContext(dbContextOptionsBuilder.Options);
    }
}
