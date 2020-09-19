using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class AdminLoginRepository : IAdminLoginRepository
	{
		private DataBaseContext dataBaseContext;

		public AdminLoginRepository(DataBaseContext Context)
		{
			dataBaseContext = Context;
		}
		public bool IsEsixtUser(string username, string password)
		{
			
			try
			{
				dataBaseContext.admin_Logins.Where(p => p.UserName == username && p.Password == password);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
