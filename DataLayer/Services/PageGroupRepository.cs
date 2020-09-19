using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class PageGroupRepository : IPageGroupRepository
	{
		private DataBaseContext dataBaseContext;
		public PageGroupRepository(DataBaseContext Context)
		{
			this.dataBaseContext = Context;
		}

		public bool DeleteGroup(PageGroup pageGroup)
		{
			try
			{
				dataBaseContext.Entry(pageGroup).State = System.Data.Entity.EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeleteGroup(int groupId)
		{
			try
			{
				var Group = GetGroupById(groupId);
				DeleteGroup(Group);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public void Dispose()
		{
			dataBaseContext.Dispose();
		}

		public IEnumerable<PageGroup> GetAllGroups()
		{
			return dataBaseContext.pageGroups;
		}

		public PageGroup GetGroupById(int groupId)
		{
			return dataBaseContext.pageGroups.Find(groupId);
		}

		public IEnumerable<ShowGroupViewModel> GetGroupsForView()
		{
			return dataBaseContext.pageGroups.Select(g => new ShowGroupViewModel()
			{
				GroupID = g.GroupID,
				GroupTitle=g.GroupTitle,
				PageCount=g.pages.Count
			});
		}

		public bool InsertGroup(PageGroup pageGroup)
		{
			try
			{
				dataBaseContext.pageGroups.Add(pageGroup);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public void Save()
		{
			dataBaseContext.SaveChanges();
		}

		public bool UpdateGroup(PageGroup pageGroup)
		{
			try
			{
				dataBaseContext.Entry(pageGroup).State = System.Data.Entity.EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
