using NUnit.Framework;
using System;
using System.IO;
using OpenAI.GPT3;

namespace OpenAI.GPT3.Tests
{
	public class AuthTests
	{
		[SetUp]
		public void Setup()
		{
			File.WriteAllText(".openai", "OPENAI_KEY=pk-test12");
			Environment.SetEnvironmentVariable("OPENAI_KEY", "pk-test-env");
			//Environment.SetEnvironmentVariable("OPENAI_SECRET_KEY", "sk-test-env");
		}

		[Test]
		public void GetAuthFromEnv()
		{
			var auth = APIAuthentication.LoadFromEnv();
			Assert.IsNotNull(auth);
			Assert.IsNotNull(auth.ApiKey);
			Assert.IsNotEmpty(auth.ApiKey);
			Assert.AreEqual("pk-test-env", auth.ApiKey);
		}

		[Test]
		public void GetAuthFromFile()
		{
			var auth = APIAuthentication.LoadFromPath();
			Assert.IsNotNull(auth);
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-test12", auth.ApiKey);
		}


		[Test]
		public void GetAuthFromNonExistantFile()
		{
			var auth = APIAuthentication.LoadFromPath(filename: "bad.config");
			Assert.IsNull(auth);
		}


		[Test]
		public void GetDefault()
		{
			var auth = APIAuthentication.Default;
			var envAuth = OpenAI.GPT3.APIAuthentication.LoadFromEnv();
			Assert.IsNotNull(auth);
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual(envAuth.ApiKey, auth.ApiKey);
		}



		[Test]
		public void testHelper()
		{
			APIAuthentication defaultAuth = OpenAI.GPT3.APIAuthentication.Default;
			APIAuthentication manualAuth = new OpenAI.GPT3.APIAuthentication("pk-testAA");
			Api api = new Api();
			APIAuthentication shouldBeDefaultAuth = api.Auth;
			Assert.IsNotNull(shouldBeDefaultAuth);
			Assert.IsNotNull(shouldBeDefaultAuth.ApiKey);
			Assert.AreEqual(defaultAuth.ApiKey, shouldBeDefaultAuth.ApiKey);

			APIAuthentication.Default = new OpenAI.GPT3.APIAuthentication("pk-testAA");
			api = new Api();
			OpenAI.GPT3.APIAuthentication shouldBeManualAuth = api.Auth;
			Assert.IsNotNull(shouldBeManualAuth);
			Assert.IsNotNull(shouldBeManualAuth.ApiKey);
			Assert.AreEqual(manualAuth.ApiKey, shouldBeManualAuth.ApiKey);
		}

		[Test]
		public void GetKey()
		{
			var auth = new OpenAI.GPT3.APIAuthentication("pk-testAA");
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-testAA", auth.ApiKey);
		}

		[Test]
		public void ParseKey()
		{
			var auth = new OpenAI.GPT3.APIAuthentication("pk-testAA");
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-testAA", auth.ApiKey);
			auth = "pk-testCC";
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("pk-testCC", auth.ApiKey);

			auth = new OpenAI.GPT3.APIAuthentication("sk-testBB");
			Assert.IsNotNull(auth.ApiKey);
			Assert.AreEqual("sk-testBB", auth.ApiKey);
		}

	}
}