using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class Accessory : BaseMessageTemplateItem {
		[JsonProperty("src")]
		public string Src { get; set; }

		[JsonProperty("icon")]
		public MessageIcon Icon { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("style")]
		public string Style { get; set; }
	}
}
