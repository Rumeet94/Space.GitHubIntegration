using System;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate {
	[Serializable]
	public class Recipient : BaseMessageTemplateItem {
		[JsonProperty("channel")]
		public Channel Channel { get; set; }

		[JsonProperty("codeReview")]
		public string CodeReview { get; set; }

		[JsonProperty("issue")]
		public string Issue { get; set; }

		[JsonProperty("member")]
		public string Member { get; set; }
	}
}
