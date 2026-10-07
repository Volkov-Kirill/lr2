using System.Text.Json.Serialization;
namespace funny.Models
{//использовать патерн builder
    public class UserDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("newId")]
        public string NewId { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("middleName")]
        public string MiddleName { get; set; }

        [JsonPropertyName("roles")]
        public List<string> Roles { get; set; } = new();

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("certificateFrom")]
        public DateTime CertificateFrom { get; set; }

        [JsonPropertyName("certificateTo")]
        public DateTime CertificateTo { get; set; }

        [JsonPropertyName("archive")]
        public bool Archive { get; set; }

        [JsonPropertyName("fromAD")]
        public bool FromAD { get; set; }

        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }

        [JsonPropertyName("departmentId")]
        public string DepartmentId { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("organization")]
        public string Organization { get; set; }

        [JsonPropertyName("ownRequests")]
        public bool OwnRequests { get; set; }

        [JsonPropertyName("notifications")]
        public int Notifications { get; set; }

        [JsonPropertyName("createdDatetime")]
        public DateTime CreatedDatetime { get; set; }

        [JsonPropertyName("lastUpdateDatetime")]
        public DateTime LastUpdateDatetime { get; set; }

        [JsonPropertyName("lastPasswordChangeDatetime")]
        public DateTime LastPasswordChangeDatetime { get; set; }

        [JsonPropertyName("lastLoginDatetime")]
        public DateTime LastLoginDatetime { get; set; }
    }
}
