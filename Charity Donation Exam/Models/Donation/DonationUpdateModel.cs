namespace Charity_Donation_Exam.Models.Donation;

public class DonationUpdateModel
{
    public DonationType.DonationType DonationType { get; set; }
    public User.UserModel User { get; set; }
    public DateTime UpdatedAt { get; set; }
}