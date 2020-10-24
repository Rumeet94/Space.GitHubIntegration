using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Attachment {
	[Serializable]
	public class Profile {
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("arenaId")]
		public string ArenaId { get; set; }
	}
}
