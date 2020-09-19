using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DataLayer
{
	public class Page
	{
		[Key]
		public int PageID { get; set; }

		[Display(Name = "گروه صفحه")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public int GroupID { get; set; }

		[Display(Name = "عنوان")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(250)]
		public string Title { get; set; }

		[Display(Name = "متن")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[DataType(DataType.MultilineText)]
		[AllowHtml]
		public string Text { get; set; }

		[Display(Name = "توضیح مختصر")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(350)]
		[DataType(DataType.MultilineText)]
		public string ShortDescription { get; set; }

		[Display(Name = "بازدید")]
		public int Visit { get; set; }

		[Display(Name = "عکس")]
		public string ImageName { get; set; }

		[Display(Name = "اسلایدر")]
		public bool ShowSlider { get; set; }

		[Display(Name = "تاریخ ایجاد")]
		[DisplayFormat(DataFormatString = "{0: yyyy/MM/dd - HH:mm}")]
		public DateTime CreateDate { get; set; }
		[Display(Name = "کلمات کلیدی")]
		public string Tags { get; set; }

		public virtual PageGroup pageGroup { get; set; }

		public virtual List<PageComment> PageComments { get; set; }
		public Page()
		{

		}

	}
}
