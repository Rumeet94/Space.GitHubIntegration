using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Content {
	[Serializable]
	public class SectionElement : BaseMessageTemplateItem {
		[JsonProperty("elements")]
		public IEnumerable<ControlGroupElement> Elements { get; set; }

		[JsonProperty("fields")]
		public IEnumerable<MessageField> Fields { get; set; }

		[JsonProperty("accessory")]
		public Accessory Accessory { get; set; }

		[JsonProperty("content")]
		public string Content { get; set; }
	}
}
