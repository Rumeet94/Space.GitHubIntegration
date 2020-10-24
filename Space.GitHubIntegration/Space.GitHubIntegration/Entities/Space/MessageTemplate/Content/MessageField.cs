using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class MessageField : BaseMessageTemplateItem {
		[JsonProperty("first")]
		public string First { get; set; }

		[JsonProperty("second")]
		public string Second { get; set; }
	}
}
