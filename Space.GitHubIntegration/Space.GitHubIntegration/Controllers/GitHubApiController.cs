using System;
using System.IO;

using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

using Newtonsoft.Json;

using Space.GitHubIntegration.Projections;
using Space.GitHubIntegration.Servicies.Space;

namespace Space.GitHubIntegration.Controllers {
	[ApiController]
	[Route("github")]
	public class GitHubApiController : ControllerBase {
		private const string _sha1Prefix = "sha1=";
		private const string _secretKey = "mytestissigood";

		[HttpPost]
		public async Task<IActionResult> Post() {
			Request.Headers.TryGetValue("X-GitHub-Event", out StringValues eventName);
			Request.Headers.TryGetValue("X-Hub-Signature", out StringValues signature);
			Request.Headers.TryGetValue("X-GitHub-Delivery", out StringValues delivery);
			
			using (var reader = new StreamReader(Request.Body))
			{
				var responce = await reader.ReadToEndAsync();
				var commit = JsonConvert.DeserializeObject<GitHubCommit>(responce);
				
				if (IsGithubPushAllowed(responce, eventName, signature))
				{
					var service = new SpaceService();

					await service.PushGitHubNotification(commit);

					return Ok();
				}
			}
			return new OkObjectResult("hi");
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


		public static string ToHexString(byte[] bytes) {
			var builder = new StringBuilder(bytes.Length * 2);

			foreach (byte b in bytes)
			{
				builder.AppendFormat("{0:x2}", b);
			}

			return builder.ToString();
		}
	}
}
