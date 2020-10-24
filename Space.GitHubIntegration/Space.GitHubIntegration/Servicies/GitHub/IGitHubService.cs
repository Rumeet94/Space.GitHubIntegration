using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Primitives;

using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.GitHub {
	public interface IGitHubService {
		 Task<GitHubCommit> GetCommit(Stream stream, StringValues eventName, StringValues signature);
	}
}
