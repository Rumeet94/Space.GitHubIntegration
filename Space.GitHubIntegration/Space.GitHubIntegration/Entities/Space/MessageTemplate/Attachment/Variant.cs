using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Attachment {
	[Serializable]
	public class Variant {
		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("width")]
		public int? Width { get; set; }

		[JsonProperty("height")]
		public int? Height { get; set; }
	}
}
