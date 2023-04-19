using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

[DataContract]
internal class LocationParameters
{
	[DataMember]
	public int Id { get; set; }
	[DataMember]
	public string Unit { get; set; }
	[DataMember]
	public decimal LastValue { get; set; }
	[DataMember]
	public string Parameter { get; set; }
	[DataMember]
	public int ParameterID { get; set; }
	[DataMember]
	public string DisplayName { get; set; }
	[DataMember]
	public DateTime LastUpdated { get; set; }
	[DataMember]
	public DateTime FirstUpdated { get; set; }
}