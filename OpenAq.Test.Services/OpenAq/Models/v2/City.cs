using OpenAq.Test.Integrations.Services.OpenAq.Models.Base;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

[DataContract]
internal class City : OpenAqModelBase
{
	[JsonPropertyName("city")]
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public string Country { get; set; }
	[DataMember]
	public int Locations { get; set; }
	[DataMember]
	public DateTime FirstUpdated { get; set; }
	[DataMember]
	public DateTime LastUpdated { get; set; }
	[DataMember]
	public string[] Parameters { get; set; }
}
