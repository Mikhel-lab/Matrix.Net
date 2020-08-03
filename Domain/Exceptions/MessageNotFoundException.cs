using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NJsonSchema.Converters;

namespace Matrix.Net.Domain.Exceptions
{
	[JsonConverter(typeof(JsonExceptionConverter))]
	public class MessageNotFoundException : Exception
	{
		[JsonProperty("messageNumber")]
		public int MessageNumber { get; set; }

		public MessageNotFoundException(int number) : base("The message could not be found.")
		{
		}
	}
}
