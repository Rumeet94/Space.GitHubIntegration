using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.GitHub;

namespace Space.GitHubIntegration.Projections {
	[Serializable]
	public class GitHubCommit {
		[JsonProperty("repository")]
		public RepositoryInfo Repository { get; set; }

		[JsonProperty("pusher")]
		public PusherInfo Pusher { get; set; }

		[JsonProperty("commits")]
		public List<CommitInfo> Commits { get; set; }
	}
}
