
namespace Airport.BLL.DTO
{
    using System.Runtime.Serialization;

    [DataContract]
    public class AirlineDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

    }
}
