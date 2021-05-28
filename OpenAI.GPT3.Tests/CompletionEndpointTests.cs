using NUnit.Framework;
using OpenAI.GPT3;
using OpenAI.GPT3.GPT3.Completions;
using System;
using System.IO;
using System.Linq;

namespace OpenAI.GPT3Tests
{
	public class CompletionEndpointTests
	{
		[SetUp]
		public void Setup()
		{
			OpenAI.GPT3.APIAuthentication.Default = new OpenAI.GPT3.APIAuthentication(Environment.GetEnvironmentVariable("TEST_OPENAI_SECRET_KEY"));
		}

		[Test]
		public void GetBasicCompletion()
		{
			var api = new Api(engine: Engine.Davinci);

			Assert.IsNotNull(api.Completions);
			
			var results = api.Completions.CreateCompletionsAsync(new CompletionRequest("One Two Three Four Five Six Seven Eight Nine One Two Three Four Five Six Seven Eight", temperature: 0.1, max_tokens: 5), 5).Result;
			Assert.IsNotNull(results);
			Assert.NotNull(results.Completions);
			Assert.NotZero(results.Completions.Count);
			Assert.That(results.Completions.Any(c => c.Text.Trim().ToLower().StartsWith("nine")));
		}

		// TODO: More tests needed but this covers basic functionality at least
	}
}