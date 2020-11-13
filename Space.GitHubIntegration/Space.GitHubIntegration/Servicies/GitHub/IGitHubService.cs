using System.IO;
using System.Threading.Tasks;

using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Servicies.GitHub {
	public interface IGitHubService {
		 Task<GitHubCommit> GetCommit(Stream stream, string eventName, string signature);
	}
}
