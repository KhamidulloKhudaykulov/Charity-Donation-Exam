namespace Charity_Donation_Exam.Models.DonationType;

public class DonationTypeCreateModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public long TotalAmount { get; set; } = 0;
}