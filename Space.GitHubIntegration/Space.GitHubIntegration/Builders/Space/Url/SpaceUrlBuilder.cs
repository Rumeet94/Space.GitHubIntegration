namespace Space.GitHubIntegration.Builders.Space.Url {
	public class SpaceUrlBuilder : ISpaceUrlBuilder {
		public string BuildChannelTextMessageUrl(string channelId) =>
			string.Format("api/http/chats/messages/send-message", channelId);
	}
}
