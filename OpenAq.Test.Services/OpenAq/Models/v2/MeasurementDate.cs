using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.v2;

[DataContract]
internal class MeasurementDate
{
	[DataMember]
	public DateTime Utc { get; set; }
	[DataMember]
	public DateTime Local { get; set; }
}