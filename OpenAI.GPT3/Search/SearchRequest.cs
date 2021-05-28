using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenAI.GPT3
{
	public class SearchRequest
	{

		[JsonPropertyName("documents")]
		public List<string> Documents { get; set; }

		[JsonPropertyName("query")]
		public string Query { get; set; }

		public SearchRequest(string query = null, params string[] documents)
		{
			Query = query;
			Documents = documents?.ToList() ?? new List<string>();
		}

		public SearchRequest(IEnumerable<string> documents)
		{
			Documents = documents.ToList();
		}
	}
}
