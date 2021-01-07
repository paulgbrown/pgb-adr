using pgb_adr;
using pgb_adr.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Factories
{
	public class FileNameFactoryShould
	{
		[Fact]
		public void CreateAFormattedFile()
		{
			var expected = "0003-Use-architectural-decision-records.md";
			var options = new AdrOptions()
			{
				NumberOfZeros = 4,
				Number = 3,
				Title = "Use architectural decision records"
			};

			string actual = FileNameFactory.Make(options);

			Assert.Equal(expected, actual);
		}
	}
}
