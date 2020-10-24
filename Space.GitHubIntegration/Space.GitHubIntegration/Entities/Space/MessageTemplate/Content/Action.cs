using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class Action : BaseMessageTemplateItem {
		[JsonProperty("actionId")]
		public string ActionId { get; set; }

		[JsonProperty("payload")]
		public string Payload { get; set; }
	}
}
