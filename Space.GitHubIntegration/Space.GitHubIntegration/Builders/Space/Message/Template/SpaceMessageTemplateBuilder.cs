using System;
using System.IO;

using Newtonsoft.Json;

using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Builders.Space.Message.Template {
	public class SpaceMessageTemplateBuilder : ISpaceMessageTemplateBuilder {
		public SpaceMessageTemplate BuildCommitMessageTemplate(string filePath) {
			var templateFilePath = AppDomain.CurrentDomain.BaseDirectory + filePath;

			using (var file = File.OpenText(templateFilePath)) {
				var serializer = new JsonSerializer();

				return (SpaceMessageTemplate)serializer.Deserialize(file, typeof(SpaceMessageTemplate));
			}
		}
	}
}
