using pgb_adr;
using pgb_adr.Utilities;
using System;
using System.IO;
using Xunit;

namespace UnitTests.Factories
{
	public class FileWriterShould
	{
		[Fact]
		public void WriteToASubFolder()
		{
			var testFileName = ".\\docs\\adr\\0004-Use-architectural-decision-records.md";

			if (File.Exists(testFileName))
			{
				File.Delete(testFileName);
			}

			var options = new AdrOptions()
			{
				DocumentationFolder = ".\\docs\\adr",
				Title = "Use architectural decision records",
				Number = 3,
				NumberOfZeros = 4
			};

			FileWriter.Write(options);

			Assert.True(File.Exists(testFileName));
		}
	}
}
