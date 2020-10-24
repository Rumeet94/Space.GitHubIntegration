using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class MessageIcon {
		[JsonProperty("icon")]
		public string Icon { get; set; }
	}
}
