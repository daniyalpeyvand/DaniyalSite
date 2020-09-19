using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public class PageCommentRepository : IPageCommentRepository
	{
		private DataBaseContext dataBaseContext;
		public PageCommentRepository(DataBaseContext Context)
		{
			dataBaseContext = Context;
		}

		public bool AddComment(PageComment comment)
		{
			try
			{
				dataBaseContext.pageComments.Add(comment);
				dataBaseContext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public IEnumerable<PageComment> GetCommentByNewsID(int pageId)
		{
			return dataBaseContext.pageComments.Where(p => p.PageID == pageId);
		}
	}
}
