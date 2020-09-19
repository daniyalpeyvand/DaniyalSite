using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DataLayer
{

	public class PageGroup
	{
		[Key]
		public int GroupID { get; set; }

		[Display(Name = "عنوان گروه")]
		[MaxLength(100)]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string GroupTitle { get; set; }


		//Navigation Property
		public virtual List<Page> pages { get; set; }
		public PageGroup()
		{

		}
	}
}
