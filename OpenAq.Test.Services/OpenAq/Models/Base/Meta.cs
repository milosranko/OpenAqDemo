using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.Base;

[DataContract]
internal class Meta
{
	[DataMember]
	public string Name { get; set; }
	[DataMember]
	public string License { get; set; }
	[DataMember]
	public string Website { get; set; }
	[DataMember]
	public int Page { get; set; }
	[DataMember]
	public int Limit { get; set; }
	[DataMember]
	public int Found { get; set; }
}