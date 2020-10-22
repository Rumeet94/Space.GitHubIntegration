using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.GitHub {
	[Serializable]
	public class CommitInfo {
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("author")]
		public CommitAuthor Author { get; set; }
	}
}
