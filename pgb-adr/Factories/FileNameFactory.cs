using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgb_adr.Factories
{
	public class FileNameFactory
	{
		public static string Make(AdrOptions options)
		{
			var numberFormat = "D" + options.NumberOfZeros.ToString();
			var formattedTitle = options.Title.Replace(" ", "-");
			var formattedNumber = options.Number.ToString(numberFormat);

			return formattedNumber + "-" + formattedTitle + ".md";
		}
	}
}
