using Charity_Donation_Exam.Models.Commons;
using System.Text.Json.Serialization;

namespace Charity_Donation_Exam.Models.User;

public class UserModel : Auditable
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("phone")]
    public string Phone { get; set; }
}