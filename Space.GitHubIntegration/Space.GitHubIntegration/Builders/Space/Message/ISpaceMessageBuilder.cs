using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Builders.Space.Message {
	public interface ISpaceMessageBuilder {
		string BuildChannelCommitMessage(GitHubCommit commit, string channelId);
	}
}
