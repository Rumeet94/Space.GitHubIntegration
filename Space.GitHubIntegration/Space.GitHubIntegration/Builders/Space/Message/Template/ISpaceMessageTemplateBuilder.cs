using Space.GitHubIntegration.Projections;

namespace Space.GitHubIntegration.Builders.Space.Message.Template {
	public interface ISpaceMessageTemplateBuilder {
		SpaceMessageTemplate BuildCommitMessageTemplate(string filePath);
	}
}
