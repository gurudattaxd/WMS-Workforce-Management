using System.ComponentModel.DataAnnotations;

namespace WMS.Domain.Entities
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string? ClientAddress { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public string? ClientLocation { get; set; }
        public bool Status { get; set; } = true;
    }
}