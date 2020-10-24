using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate;
using Space.GitHubIntegration.Entities.Space.MessageTemplate.Attachment;
using Space.GitHubIntegration.Entities.Space.MessageTemplate.Content;

namespace Space.GitHubIntegration.Projections {
	[Serializable]
	public class SpaceMessageTemplate {
		[JsonProperty("recipient")]
		public Recipient Recipient { get; set; }

		[JsonProperty("content")]
		public MessageContent Content { get; set; }

		[JsonProperty("unfurlLinks")]
		public bool? UnfurlLinks { get; set; }

		[JsonProperty("externalId")]
		public string ExternalId { get; set; }

		[JsonProperty("attachments")]
		public IEnumerable<MessageAttachment> Attachments { get; set; }
	}
}
