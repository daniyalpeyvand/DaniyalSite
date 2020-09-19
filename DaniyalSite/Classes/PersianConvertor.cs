using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace DaniyalSite
{
	public static class PersianConvertor
	{
		public static string ToShamsi(this DateTime value)
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			return persianCalendar.GetYear(value) + "/" + persianCalendar.GetMonth(value).ToString("00") + "/" +
				persianCalendar.GetDayOfMonth(value).ToString("00");
		}
	}
}