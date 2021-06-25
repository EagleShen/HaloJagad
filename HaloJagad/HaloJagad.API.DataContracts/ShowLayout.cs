using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DeltaGrid.Showroom
{
	public class ShowCell
	{
		[JsonProperty("columnSpan")]
		public int? ColumnSpan { get; set; }
		[JsonProperty("urls")]
		public List<string> Urls { get; set; } = new List<string>();
		[JsonProperty("seconds")]
		public int? Seconds { get; set; }

	}
	public class ShowRow
	{
		[JsonProperty("cells")]
		public List<ShowCell> Cells { get; set; } = new List<ShowCell>();

	}
	public class ShowLayout
	{
		[JsonProperty("rows")]
		public List<ShowRow> Rows { get; set; } = new List<ShowRow>();

	}

	public class ShowRequest
	{
		[JsonProperty("layout")]
		public ShowLayout Layout{get;set;}
	}
}
