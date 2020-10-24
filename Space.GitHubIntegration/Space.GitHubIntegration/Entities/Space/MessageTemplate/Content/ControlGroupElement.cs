using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class ControlGroupElement : BaseMessageTemplateItem {
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("style")]
		public string Style { get; set; }

		[JsonProperty("action")]
		public Action Action { get; set; }

		[JsonProperty("disabled")]
		public bool? Disabled { get; set; }
	}
}
