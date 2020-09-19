using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
	public class Admin_Login
	{
		[Key]
		public int AdminId { get; set; }

		[Display(Name = "نام کاربری")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(30)]
		public string UserName { get; set; }

		[MaxLength (150)]
		[Display(Name = "ایمیل")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		public string Email { get; set; }

		[Display(Name = "رمزعبور")]
		[Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
		[MaxLength(30)]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "مرا به خاطر بسپار")]
		public bool RememberMe { get; set; }
	}
}
