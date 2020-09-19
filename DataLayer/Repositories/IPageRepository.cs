using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public interface IPageRepository : IDisposable
	{
		IEnumerable<Page> GetAllPages();
		Page GetPageById(int PageId);
		bool InsertPage(Page Page);
		bool UpdatePage(Page Page);
		bool DeletePage(Page Page);
		bool DeletePage(int PageId);
		void Save();

		IEnumerable<Page> TopNews(int Take = 4);
		IEnumerable<Page> Slider();
		IEnumerable<Page> LastNews(int take = 5);
		IEnumerable<Page> ShowPageByGroupId(int groupId);
		IEnumerable<Page> ShowNews(int pageId);
		IEnumerable<Page> SearchPage(string Parameter);
	}
}

