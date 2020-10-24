using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.Primitives;

using Newtonsoft.Json;

using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.GitHub {
	public class GitHubService : IGitHubService {
		private const string _sha1Prefix = "sha1=";
		private const string _secretKey = "mytestissigood";

		public async Task<GitHubCommit> GetCommit(Stream stream, StringValues eventName, StringValues signature) {
			using (var reader = new StreamReader(stream)) {
				var responce = await reader.ReadToEndAsync();
				
				if (IsGithubPushAllowed(responce, eventName, signature)) {
					var commit = JsonConvert.DeserializeObject<GitHubCommit>(responce);
					
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

			//if (signatureWithPrefix.StartsWith(_sha1Prefix, StringComparison.OrdinalIgnoreCase)) {
		
			//var signature = signatureWithPrefix.Substring(_sha1Prefix.Length);
			//var secret = Encoding.ASCII.GetBytes(_secretKey);
			//var payloadBytes = Encoding.ASCII.GetBytes(payload);

			//	using (var hmSha1 = new HMACSHA1(secret)) {
			//		var hash = hmSha1.ComputeHash(payloadBytes);
			//		var hashString = ToHexString(hash);

			//		if (hashString.Equals(signature)) {
			//			return true;
			//		}
			//	}
			//}

			return true;
		}

		private string ToHexString(byte[] bytes) {
			var builder = new StringBuilder(bytes.Length * 2);

			foreach (byte b in bytes)
			{
				builder.AppendFormat("{0:x2}", b);
			}

			return builder.ToString();
		}
	}
}
