using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class PageRepository : IPageRepository
	{
		private DataBaseContext dataBaseContext;
		public PageRepository(DataBaseContext Context)
		{
			this.dataBaseContext = Context;
		}

		public bool DeletePage(Page Page)
		{
			try
			{
				dataBaseContext.Entry(Page).State = System.Data.Entity.EntityState.Deleted;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public bool DeletePage(int PageId)
		{
			try
			{
				var page = GetPageById(PageId);
				DeletePage(page);
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

		public IEnumerable<Page> GetAllPages()
		{
			return dataBaseContext.pages;
		}

		public Page GetPageById(int PageId)
		{
			return dataBaseContext.pages.Find(PageId);
		}

		public bool InsertPage(Page Page)
		{
			try
			{
				dataBaseContext.pages.Add(Page);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		public IEnumerable<Page> LastNews(int Take = 5)
		{
			return dataBaseContext.pages.OrderByDescending(p => p.CreateDate).Take(Take);
		}

		public void Save()
		{
			dataBaseContext.SaveChanges();
		}

		public IEnumerable<Page> SearchPage(string Parameter)
		{
			return dataBaseContext.pages.Where(p => p.Title.Contains(Parameter) ||
			p.ShortDescription.Contains(Parameter) || p.Text.Contains(Parameter) || p.Tags.Contains(Parameter)).Distinct();
		}

		public IEnumerable<Page> ShowNews(int pageId)
		{
			return dataBaseContext.pages.Where(p => p.PageID == pageId);
		}

		public IEnumerable<Page> ShowPageByGroupId(int groupId)
		{
			return dataBaseContext.pages.Where(p => p.GroupID == groupId);
		}

		public IEnumerable<Page> Slider()
		{
			return dataBaseContext.pages.Where(p => p.ShowSlider == true);
		}

		public IEnumerable<Page> TopNews(int Take = 4)
		{
			return dataBaseContext.pages.OrderByDescending(p => p.Visit).Take(Take);
		}

		public bool UpdatePage(Page Page)
		{
			try
			{
				dataBaseContext.Entry(Page).State = System.Data.Entity.EntityState.Modified;
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
