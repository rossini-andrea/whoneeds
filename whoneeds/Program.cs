using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace whoneeds
{
	class Program
	{
		static int Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.Error.WriteLine("whoneeds: no pattern specified");
				return -1;
			}

			var pattern = new Regex(args[0],
				RegexOptions.Compiled |
				RegexOptions.IgnoreCase | 
				RegexOptions.CultureInvariant);

			foreach (var f in Directory.EnumerateFiles(".")
				.Where(x => x.EndsWith(".dll") || x.EndsWith(".exe"))
				.Select(x => Path.GetFullPath(x)))
			{
				Assembly ass;

				try
				{
					ass = Assembly.LoadFile(f);
				}
				catch (BadImageFormatException)
				{
					continue;
				}

				foreach (var d in ass.GetReferencedAssemblies()
					.Where(x => pattern.IsMatch(x.Name)))
				{
					Console.WriteLine("{0} => {1}", ass.GetName().Name, d.FullName);
				}
			}

			return 0;
		}
	}
}
