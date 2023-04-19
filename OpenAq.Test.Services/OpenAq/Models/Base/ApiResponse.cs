using System.Runtime.Serialization;

namespace OpenAq.Test.Integrations.Services.OpenAq.Models.Base;

[DataContract]
internal class ApiResponse<T> where T : OpenAqModelBase
{
	[DataMember]
	public Meta Meta { get; set; }

	[DataMember]
	public T[] Results { get; set; }
}
