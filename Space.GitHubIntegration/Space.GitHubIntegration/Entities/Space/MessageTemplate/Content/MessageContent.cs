using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class MessageContent : BaseMessageTemplateItem {
		[JsonProperty("style")]
		public string Style { get; set; }

		[JsonProperty("sections")]
		public Section[] Sections { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("messageData")]
		public string MessageData { get; set; }
	}

}
