using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;
using pgb_adr.Factories;
using pgb_adr;

namespace UnitTests.Factories
{
	public class TemplateFactoryShould
	{
		public readonly ITestOutputHelper _output;

		public TemplateFactoryShould(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void CreateAnAdrTemplate()
		{
			var options = new AdrOptions()
			{
				Number = 1,
				Title = "Use Architectural Decision Records"
			};

			var actual = TemplateFactory.Make(options);

			_output.WriteLine(actual);
		}
	}
}
