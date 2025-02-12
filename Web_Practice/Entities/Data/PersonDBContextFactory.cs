using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Data
{
	public class PersonDBContextFactory : IDesignTimeDbContextFactory<PersonDBContext>
	{
		public PersonDBContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<PersonDBContext>();
			optionsBuilder.UseSqlServer(@"Server=.;Database=PersonDb;User Id=sa;Password=ducnhu1234;Encrypt=True;TrustServerCertificate=True;");

			return new PersonDBContext(optionsBuilder.Options);
		}
	}
}