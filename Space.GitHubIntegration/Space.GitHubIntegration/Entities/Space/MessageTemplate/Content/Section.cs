using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class Section : BaseMessageTemplateItem {
		[JsonProperty("header")]
		public string Header { get; set; }

		[JsonProperty("elements")]
		public SectionElement[] Elements { get; set; }

		[JsonProperty("footer")]
		public string Footer { get; set; }
	}
}
