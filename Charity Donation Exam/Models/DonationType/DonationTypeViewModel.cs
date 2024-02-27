using System.Text.Json.Serialization;

namespace Charity_Donation_Exam.Models.DonationType;

public class DonationTypeViewModel
{

    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("desc")]
    public string Description { get; set; }
    [JsonPropertyName("card")]
    public string CardNumber { get; set; }
    [JsonPropertyName("amount")]
    public long TotalAmount { get; set; }
}
