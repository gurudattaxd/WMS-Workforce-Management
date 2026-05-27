using System.ComponentModel.DataAnnotations;

namespace WMS.Application.DTOs
{
    public class ClientDto
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string? ClientAddress { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public string? ClientLocation { get; set; }
        public bool Status { get; set; }
    }

    public class CreateClientDto
    {
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; } = string.Empty;
        public string? ClientAddress { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public string? ClientLocation { get; set; }
    }

    public class UpdateClientDto
    {
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; } = string.Empty;
        public string? ClientAddress { get; set; }
        public string? ClientPhoneNumber { get; set; }
        public string? ClientLocation { get; set; }
        public bool Status { get; set; }
    }
}