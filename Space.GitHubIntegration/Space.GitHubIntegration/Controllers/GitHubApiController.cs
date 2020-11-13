using System.Diagnostics.Contracts;
using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

using Space.GitHubIntegration.Projections;
using Space.GitHubIntegration.Servicies.GitHub;
using Space.GitHubIntegration.Servicies.Space;

namespace Space.GitHubIntegration.Controllers {
	[ApiController]
	[Route("github")]
	public class GitHubApiController : ControllerBase {
		private readonly ISpaceService _spaceService;
		private readonly IGitHubService _gitHubService;

		public GitHubApiController(ISpaceService spaceService, IGitHubService gitHubService) {
			Contract.Requires(spaceService != null);
			Contract.Requires(gitHubService != null);

			_spaceService = spaceService;
			_gitHubService = gitHubService;
		}

		[HttpGet]
		public IActionResult Get() =>
			Ok("Ready for work");

		[HttpPost()]
		public async Task<IActionResult> Post() {
			Request.Headers.TryGetValue("X-GitHub-Event", out StringValues eventName);
			Request.Headers.TryGetValue("X-Hub-Signature", out StringValues signature);
			Request.Headers.TryGetValue("X-GitHub-Delivery", out StringValues delivery);
			
			try {
				var commit = await _gitHubService.GetCommit(Request.Body, eventName, signature);
				var result = await PushToSpace(commit);

				return new OkObjectResult(result);
			}
			catch {
				return new BadRequestResult();
			}
		}

		private async Task<HttpStatusCode> PushToSpace(GitHubCommit commit) {
			if (commit == null) {
				return HttpStatusCode.InternalServerError;
			}

			return await _spaceService.PushGitHubNotification(commit);
		}
	}
}
