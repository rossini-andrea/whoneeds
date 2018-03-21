/*
    Mandelbrot.exe - A Mandelbrot Set generator.
    Copyright (C) 2017 Andrea Rossini
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

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
