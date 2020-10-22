using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.GitHub {
	[Serializable]
	public class CommitAuthor {
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("email")]
		public string Email { get; set; }
	}
}
