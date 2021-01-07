using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pgb_adr.Factories
{
	public static class TemplateFactory
	{
		public static string Make(AdrOptions options)
		{
			var today = DateTime.Now.ToString("yyyy-MM-dd");
			var adr = new StringBuilder("# " + options.Number.ToString() + ". " + options.Title);
			adr.AppendLine("");
			adr.AppendLine("");
			adr.AppendLine(today);
			adr.AppendLine("");
			adr.AppendLine("## Status");
			adr.AppendLine("");
			adr.AppendLine("Proposed");
			adr.AppendLine("");
			adr.AppendLine("## Context");
			adr.AppendLine("");
			adr.AppendLine("What is the issue that we're seeing that is motivating this decision or change?");
			adr.AppendLine("");
			adr.AppendLine("## Decision");
			adr.AppendLine("");
			adr.AppendLine("What is the change that we're proposing and/or doing?");
			adr.AppendLine("");
			adr.AppendLine("## Consequences");
			adr.AppendLine("");
			adr.AppendLine("What becomes easier or more difficult to do because of this change?");
			adr.AppendLine("");

			return adr.ToString();
		}
	}
}
