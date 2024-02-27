namespace Charity_Donation_Exam.Models.Donation;

public class DonationViewModel
{
    public long Id { get; set; }
    public DonationType.DonationType DonationType { get; set; }
    public User.UserModel User { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Amount { get; set; }
}
