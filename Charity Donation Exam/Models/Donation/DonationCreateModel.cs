namespace Charity_Donation_Exam.Models.Donation;

public class DonationCreateModel
{
    public DonationType.DonationType DonationType { get; set; }
    public User.UserModel User { get; set; }
    public decimal Amount { get; set; }
}