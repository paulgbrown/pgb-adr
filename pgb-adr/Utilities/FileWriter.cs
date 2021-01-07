using pgb_adr.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgb_adr.Utilities
{
	public class FileWriter
	{
		public static void Write(AdrOptions options)
		{
			var fileName = FileNameFactory.Make(options);
			var fullPath = (options.DocumentationFolder.EndsWith("\\") ?
				options.DocumentationFolder : options.DocumentationFolder + "\\")
				+ fileName;

			var template = TemplateFactory.Make(options);

			if (!Directory.Exists(options.DocumentationFolder))
			{ Directory.CreateDirectory(options.DocumentationFolder); }

			File.WriteAllText(fullPath, template);
		}
	}
}
