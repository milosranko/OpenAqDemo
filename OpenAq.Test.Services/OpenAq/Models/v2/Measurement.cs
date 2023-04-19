using OpenAq.Test.Integrations.Services.OpenAq.Models.Base;
using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

[DataContract]
internal class Measurement : OpenAqModelBase
{
	[DataMember]
	public int LocationId { get; set; }
	[DataMember]
	public string Location { get; set; }
	[DataMember]
	public string Parameter { get; set; }
	[DataMember]
	public decimal Value { get; set; }
	[DataMember]
	public MeasurementDate Date { get; set; }
	[DataMember]
	public string Unit { get; set; }
	[DataMember]
	public string Country { get; set; }
	[DataMember]
	public string City { get; set; }
}
