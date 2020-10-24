using System;

using Newtonsoft.Json;

namespace Space.GitHubIntegration.Entities.Space.MessageTemplate.Attachment {
	[Serializable]
	public class Unfurl {
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("link")]
		public string Link { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("sitename")]
		public string SiteName { get; set; }

		[JsonProperty("image")]
		public string Image { get; set; }

		[JsonProperty("imageMime")]
		public string ImageMime { get; set; }

		[JsonProperty("imageWidth")]
		public int? ImageWidth { get; set; }

		[JsonProperty("imageHeight")]
		public int? ImageHeight { get; set; }

		[JsonProperty("video")]
		public string Video { get; set; }

		[JsonProperty("videoIFrame")]
		public string VideoIFrame { get; set; }

		[JsonProperty("videoMime")]
		public string videoMime { get; set; }

		[JsonProperty("videoHeight")]
		public int? VideoHeight { get; set; }

		[JsonProperty("videoWidth")]
		public int? VideoWidth { get; set; }

		[JsonProperty("favicon")]
		public string Favicon { get; set; }
	}
}
