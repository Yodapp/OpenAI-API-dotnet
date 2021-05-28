using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace OpenAI.GPT3.Blueprint
{
    public abstract class OpenAIRequestBase
    {
        /// <summary>
        /// How many tokens to complete to. Can return fewer if a stop sequence is hit.
        /// </summary>
        [JsonPropertyName("max_tokens")]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer. It is generally recommend to use this or <see cref="TopP"/> but not both.
        /// </summary>
        [JsonPropertyName("temperature")]
        public double? Temperature { get; set; }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered. It is generally recommend to use this or <see cref="Temperature"/> but not both.
        /// </summary>
        [JsonPropertyName("top_p")]
        public double? TopP { get; set; }

        /// <summary>
        /// The scale of the penalty applied if a token is already present at all.  Should generally be between 0 and 1, although negative numbers are allowed to encourage token reuse.
        /// </summary>
        [JsonPropertyName("presence_penalty")]
        public double? PresencePenalty { get; set; }
    }
}
