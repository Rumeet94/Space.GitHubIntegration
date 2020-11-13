using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.GitHub {
	public class GitHubService : IGitHubService {
		private const string _branchHeadPath = "refs/heads/";

		public async Task<GitHubCommit> GetCommit(Stream stream, string eventName, string signature) {
			using (var reader = new StreamReader(stream)) {
				var responce = await reader.ReadToEndAsync();
				
				if (IsGithubPushAllowed(responce, eventName, signature)) {
					var commit = GetCommit(responce);
						
					return commit;
				}
			}

			return null;
		}

		private bool IsGithubPushAllowed(string payload, string eventName, string signatureWithPrefix) {
			if (string.IsNullOrWhiteSpace(payload)) {
				throw new ArgumentNullException(nameof(payload));
			}

			if (string.IsNullOrWhiteSpace(eventName)) {
				throw new ArgumentNullException(nameof(eventName));
			}

			if (string.IsNullOrWhiteSpace(signatureWithPrefix)) {
				throw new ArgumentNullException(nameof(signatureWithPrefix));
			}

			return true;
		}

		private GitHubCommit GetCommit(string reference) {
			var json = reference.Replace(_branchHeadPath, "");

			return JsonConvert.DeserializeObject<GitHubCommit>(json);
		}
	}
}
