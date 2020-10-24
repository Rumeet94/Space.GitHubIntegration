using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

using Newtonsoft.Json;

using Space.GitHubIntegration.Builders.Space.Message.Template;
using Space.GitHubIntegration.Entities.GitHub;
using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Builders.Space.Message {
	public class SpaceMessageBuilder : ISpaceMessageBuilder {
		private readonly ISpaceMessageTemplateBuilder _messageTemplateBuilder;

		public SpaceMessageBuilder(ISpaceMessageTemplateBuilder messageTemplateBuilder) {
			Contract.Requires(messageTemplateBuilder != null);

			_messageTemplateBuilder = messageTemplateBuilder;
		}

		public string BuildChannelCommitMessage(GitHubCommit commit, string channelId) {
			var template = _messageTemplateBuilder.BuildCommitMessageTemplate(@"JsonTemplates\spaceMessage.json");
			
			template.Recipient.Channel.Id = channelId;

			template.Content.Sections[0].Elements[0].Content = commit.Pusher.Name;
			template.Content.Sections[0].Elements[1].Content = GetCommitInfo(commit);
			template.Content.Sections[0].Elements[2].Content = GetCommits(commit.Commits);

			return JsonConvert.SerializeObject(
				template,
				Formatting.Indented,
				new JsonSerializerSettings {
					NullValueHandling = NullValueHandling.Ignore
				}
			);
		}

		private string GetCommitInfo(GitHubCommit commit) {
			var commitAlias = commit.Commits.Count > 1
				? "commits"
				: "commit";

			return $"**{commit.Commits.Count} new {commitAlias}** pushed to " +
				$"[{commit.Repository.FullName}]({commit.Repository.HtmlUrl})";
		}

		private string GetCommits(List<CommitInfo> commits) {
			var builder = new StringBuilder();

			commits.ForEach(c => builder.AppendLine($"[{c.Message}]({c.Url})\r\n"));

			return builder.ToString();
		}

		

		
	}
}
