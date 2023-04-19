using OpenAq.Test.Integrations.Services.OpenAq.Models.Base;
using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

[DataContract]
internal class Country : OpenAqModelBase
{
	[DataMember]
	public string Code { get; set; }
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public int Locations { get; set; }
	[DataMember]
	public int Cities { get; set; }
	[DataMember]
	public DateTime FirstUpdated { get; set; }
	[DataMember]
	public DateTime LastUpdated { get; set; }
	[DataMember]
	public string[] Parameters { get; set; }
}
