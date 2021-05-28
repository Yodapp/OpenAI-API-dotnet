using OpenAI.GPT3.Blueprint;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenAI.GPT3.Classifications
{
    /// <summary>
    /// Implementation of a request to an Open AI GPT3 Classification API request, https://beta.openai.com/docs/api-reference/classifications/
    /// </summary>
    public class ClassificationRequest : OpenAIRequestBase
    {
        /*
         * 
         * [
      ["A happy moment", "Positive"],
      ["I am sad.", "Negative"],
      ["I am feeling awesome", "Positive"]],
    "query": "It is a raining day :(",
    "search_model": "ada",
    "model": "curie",
    "labels":["Positive", "Negative", "Neutral"]
        */
    }
}
