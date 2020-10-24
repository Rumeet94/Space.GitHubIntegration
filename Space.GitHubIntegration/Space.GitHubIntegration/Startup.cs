using System;
using System.Net.Http.Headers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Space.GitHubIntegration.Builders.Space.Message;
using Space.GitHubIntegration.Builders.Space.Message.Template;
using Space.GitHubIntegration.Builders.Space.Url;
using Space.GitHubIntegration.Servicies.GitHub;
using Space.GitHubIntegration.Servicies.Space;

namespace Space.GitHubIntegration {
	public class Startup {
		private const string _token = "eyJhbGciOiJSUzUxMiJ9.eyJzdWIiOiI0STloR0szT3RldEoiLCJhdWQiOiJjaXJjbGV0LXdlYi11aSIsIm9yZ0RvbWFpbiI6IndvcmtsZSIsIm5hbWUiOiJlZ29yYnVub3YiLCJpc3MiOiJodHRwczpcL1wvamV0YnJhaW5zLnNwYWNlIiwicGVybV90b2tlbiI6IjFQMmVZWTBBZFFkciIsInByaW5jaXBhbF90eXBlIjoiVVNFUiIsImlhdCI6MTYwMzMxMzUyMn0.bO5scwGdw8aL3eWyrXj5mV8-5UiQQZkpfsDlzS36_UTJYk1JfFH31JTmDCZiGgZ_pyQ2J6zFiOyUXDXoXBNysP-pK91tA4EP7WWiaCI_CywiNyDbXTXUC7cvMSTELo1cM-cmyxJQk5ZiO7Xba4JZ0-Lu-sQRxgwZM7RQZh2Tzew";

		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services) {
			services.AddControllers();

			services.AddSingleton(typeof(ISpaceService), typeof(SpaceService));
			services.AddSingleton(typeof(IGitHubService), typeof(GitHubService));

			services.AddSingleton(typeof(ISpaceUrlBuilder), typeof(SpaceUrlBuilder));
			services.AddSingleton(typeof(ISpaceMessageBuilder), typeof(SpaceMessageBuilder));
			services.AddSingleton(typeof(ISpaceMessageTemplateBuilder), typeof(SpaceMessageTemplateBuilder));

			services.AddHttpClient("spaceHttpClient", c => {
				c.BaseAddress = new Uri("https://workle.jetbrains.space/");
				c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});
		}
	}
}
