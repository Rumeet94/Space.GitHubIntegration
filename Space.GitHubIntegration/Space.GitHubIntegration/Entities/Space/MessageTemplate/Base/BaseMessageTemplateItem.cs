using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Base {
	[Serializable]
	public abstract class BaseMessageTemplateItem {
		[JsonProperty("className")]
		public string Alias { get; set; }
	}
}
