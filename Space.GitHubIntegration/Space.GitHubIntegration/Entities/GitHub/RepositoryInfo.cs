using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.GitHub {
	[Serializable]
	public class RepositoryInfo {
		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("full_name")]
		public string FullName { get; set; }

		[JsonProperty("html_url")]
		public string HtmlUrl { get; set; }
	}
}
