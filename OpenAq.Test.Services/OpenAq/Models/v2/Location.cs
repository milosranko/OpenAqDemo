using OpenAq.Test.Integrations.Services.OpenAq.Models.Base;
using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

[DataContract]
internal class Location : OpenAqModelBase
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public string City { get; set; }
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public string Country { get; set; }
	[DataMember]
	public LocationParameters[] Parameters { get; set; }
	[DataMember]
	public int Measurements { get; set; }
	[DataMember]
	public DateTime LastUpdated { get; set; }
	[DataMember]
	public DateTime FirstUpdated { get; set; }
}
