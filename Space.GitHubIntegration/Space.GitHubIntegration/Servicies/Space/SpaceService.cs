using System.Diagnostics.Contracts;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Space.GitHubIntegration.Builders.Space.Message;
using Space.GitHubIntegration.Builders.Space.Url;
using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.Space {
	public class SpaceService : ISpaceService {
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ISpaceUrlBuilder _urlBuilder;
		private readonly ISpaceMessageBuilder _messageBuilder;

		public SpaceService(IHttpClientFactory httpClientFactory, ISpaceUrlBuilder urlBuilder, ISpaceMessageBuilder messageBuilder) {
			Contract.Requires(httpClientFactory != null);
			Contract.Requires(urlBuilder != null);
			Contract.Requires(messageBuilder != null);

			_httpClientFactory = httpClientFactory;
			_urlBuilder = urlBuilder;
			_messageBuilder = messageBuilder;
		}

		public async Task<HttpStatusCode> PushGitHubNotification(GitHubCommit commit) {
			var url = _urlBuilder.BuildChannelTextMessageUrl("2PTicn3FhRAU");
			var content = GetContent(commit);

			using (var client = _httpClientFactory.CreateClient("spaceHttpClient")) {
				var result = await client.PostAsync(url, content);

				return result.StatusCode;
			}
		}

		private StringContent GetContent(GitHubCommit commit) {
			var message = _messageBuilder.BuildChannelCommitMessage(commit, "2PTicn3FhRAU");

			return new StringContent(message, Encoding.UTF8, "application/json");
		}
	}
}
