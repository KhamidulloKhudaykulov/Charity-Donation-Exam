using Charity_Donation_Exam.Models.Commons;
using System.Text.Json.Serialization;

namespace Charity_Donation_Exam.Models.DonationType;

public class DonationType : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public long TotalAmount { get; set; }
}
