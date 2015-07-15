using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DependencyUpdater
{
	public class VersionAwareStringComparer : IComparer<string>
	{
		public int Compare(string x, string y)
		{
			//Determine the version string format. It might be w.x.y.z, x.y.z, or y.z
			Version xVers = GetVersionPart(x);
			Version yVers = GetVersionPart(y);
			if (xVers == null && yVers == null)
			{
				//Compare normally--no version found
				return string.Compare(x, y);
			}
			else if (xVers == null)
			{
				return -1; /*This case shouldnt happen because of the regex selector for the folder name in the config*/
			}
			else if (yVers == null)
			{
				return 1; /*This case shouldnt happen because of the regex selector for the folder name in the config*/
			}
			else
			{ /*Neither null*/
				return xVers.CompareTo(yVers);
			}
		}

		public Version GetVersionPart(string text)
		{
			//Get the version for the x parameter
			Regex r4 = new Regex(@"(?<version>[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+)");
			Regex r3 = new Regex(@"(?<version>[0-9]+\.[0-9]+\.[0-9]+)");
			Regex r2 = new Regex(@"(?<version>[0-9]+\.[0-9]+)");

			Match textMatch = r4.Match(text);
			if (textMatch.Groups.Count == 2 && textMatch.Groups["version"].Success)
			{
				return new Version(textMatch.Groups["version"].Value);
			}

			textMatch = r3.Match(text);
			if (textMatch.Groups.Count == 2 && textMatch.Groups["version"].Success)
			{
				return new Version(textMatch.Groups["version"].Value);
			}

			textMatch = r2.Match(text);
			if (textMatch.Groups.Count == 2 && textMatch.Groups["version"].Success)
			{
				return new Version(textMatch.Groups["version"].Value);
			}
			else
			{
				return null;
			}
		}
	}
}
