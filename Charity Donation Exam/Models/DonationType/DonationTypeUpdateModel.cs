namespace Charity_Donation_Exam.Models.DonationType;

public class DonationTypeUpdateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public long TotalAmount { get; set; }
    public DateTime UpdatedAt { get; set; }
}