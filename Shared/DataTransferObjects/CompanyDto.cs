using System.Runtime.Serialization;

[DataContract]
public class CompanyDto
{
    [DataMember]
    public Guid Id { get; set; }

    [DataMember]
    public string? Name { get; set; }

    [DataMember]
    public string? FullAddress { get; set; }
}
