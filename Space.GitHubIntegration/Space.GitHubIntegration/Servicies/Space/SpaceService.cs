using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Space.GitHubIntegration.Entities.GitHub;
using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.Space {
	public class SpaceService : ISpaceService {
		private const string _token = "eyJhbGciOiJSUzUxMiJ9.eyJzdWIiOiI0STloR0szT3RldEoiLCJhdWQiOiJjaXJjbGV0LXdlYi11aSIsIm9yZ0RvbWFpbiI6IndvcmtsZSIsIm5hbWUiOiJlZ29yYnVub3YiLCJpc3MiOiJodHRwczpcL1wvamV0YnJhaW5zLnNwYWNlIiwicGVybV90b2tlbiI6IjFQMmVZWTBBZFFkciIsInByaW5jaXBhbF90eXBlIjoiVVNFUiIsImlhdCI6MTYwMzMxMzUyMn0.bO5scwGdw8aL3eWyrXj5mV8-5UiQQZkpfsDlzS36_UTJYk1JfFH31JTmDCZiGgZ_pyQ2J6zFiOyUXDXoXBNysP-pK91tA4EP7WWiaCI_CywiNyDbXTXUC7cvMSTELo1cM-cmyxJQk5ZiO7Xba4JZ0-Lu-sQRxgwZM7RQZh2Tzew";
		private const string _url = "https://workle.jetbrains.space/api/http/chats/channels/{0}/messages";

		public async Task PushGitHubNotification(GitHubCommit commit) {
			using (var client = new HttpClient()) {
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

				var messageText = GetMessageText(commit);
				var text = JsonConvert.SerializeObject(new Dictionary<string, string> { {"text", messageText} });

				var content = new StringContent(text, Encoding.UTF8, "application/json");
				var url = string.Format(_url, "4O8cet2xZjCb");

				await client.PostAsync(url, content);
			}
		}

		private string GetMessageText(GitHubCommit commit) {
			var isSomeCommit = commit.Commits.Count > 1;
			var commitAlias = isSomeCommit
				? "commits"
				: "commit";
			
			var outerCommitsText = isSomeCommit
				? GetSomeCommits(commit.Commits)
				: GetSingleCommits(commit.Commits);

			return $"**{commit.Pusher.Name}**\r\n" +
				$"**{commit.Commits.Count} {commitAlias}** pushed to " +
				$"[{commit.Repository.FullName}]({commit.Repository.HtmlUrl})\r\n" +
				outerCommitsText;
		}

		private string GetSingleCommits(List<CommitInfo> commits) {
			var commit = commits.FirstOrDefault();

			if (commit == null) {
				return null;
			}

			return $"[{commit.Message}]({commit.Url})";
		}

		private string GetSomeCommits(List<CommitInfo> commits) {
			var builder = new StringBuilder("commits:\r\n");

			commits.ForEach(c => builder.AppendLine($"**{c.Author.Name}** - [{c.Message}]({c.Url})\r\n"));

			return builder.ToString();
		}
	}
}
