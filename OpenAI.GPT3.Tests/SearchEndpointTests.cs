using NUnit.Framework;
using OpenAI.GPT3;
using System;
using System.IO;
using System.Linq;

namespace OpenAI.GPT3Tests
{
	public class SearchEndpointTests
	{
		[SetUp]
		public void Setup()
		{
			APIAuthentication.Default = new APIAuthentication(Environment.GetEnvironmentVariable("TEST_OPENAI_SECRET_KEY"));
		}

		[Test]
		public void TestBasicSearch()
		{
			var api = new Api(engine: Engine.Curie);

			Assert.IsNotNull(api.Search);

			var result = api.Search.GetBestMatchAsync("Washington DC", "Canada", "China", "USA", "Spain").Result;
			Assert.IsNotNull(result);
			Assert.AreEqual("USA", result);
		}

		// TODO: More tests needed but this covers basic functionality at least

	}
}