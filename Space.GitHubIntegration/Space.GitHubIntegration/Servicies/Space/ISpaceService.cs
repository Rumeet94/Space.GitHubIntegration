using System.Net;
using System.Threading.Tasks;

using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.Space {
	public interface ISpaceService {
		Task<HttpStatusCode> PushGitHubNotification(GitHubCommit commit);
	}
}
