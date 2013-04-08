using System.Collections.Generic;

namespace Blog.Models
{
	public class SetThemeViewModel
	{
		public string SelectedTheme { get; set; }
		public IEnumerable<string> Themes { get; set; }
	}
}