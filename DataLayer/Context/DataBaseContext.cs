using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
	public class DataBaseContext : DbContext
	{
		public DbSet<Page> pages { get; set; }
		public DbSet<PageGroup> pageGroups { get; set; }
		public DbSet<PageComment> pageComments { get; set; }
		public DbSet<Admin_Login> admin_Logins { get; set; }
	}
}
