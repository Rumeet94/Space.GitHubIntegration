using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.Space.MessageTemplate.Base;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Attachment {
	[Serializable]
	public class MessageAttachment : BaseMessageTemplateItem {
		[JsonProperty("deletedIdentity")]
		public string DeletedIdentity { get; set; }

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonProperty("sizeBytes")]
		public long? SizeBytes { get; set; }

		[JsonProperty("filename")]
		public string Filename { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("width")]
		public int? Width { get; set; }

		[JsonProperty("height")]
		public int? Height { get; set; }

		[JsonProperty("previewBytes")]
		public string PreviewBytes { get; set; }

		[JsonProperty("variants")]
		public IEnumerable<Variant> Variants { get; set; }

		[JsonProperty("profile")]
		public Profile Profile { get; set; }

		[JsonProperty("unfurl")]
		public Unfurl Unfurl { get; set; }
	}
}
