using Charity_Donation_Exam.Models.Commons;

namespace Charity_Donation_Exam.Models.Donation;

public class Donation : Auditable
{
    public DonationType.DonationType DonationType { get; set; }
    public User.UserModel User { get; set; }
}
