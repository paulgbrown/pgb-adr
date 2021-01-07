using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgb_adr
{
	public class AdrService
	{
		private IConfiguration _config;

		public AdrService(IConfiguration config)
		{
			_config = config;
		}

		public void Run(string[] commandLineArgs)
		{
			var numZeros = _config.GetValue<int>(AppSettingsConstants.NumberOfZeros);
			Console.WriteLine($"The number of leading zeros is: {numZeros}");
		}
	}
}