using Charity_Donation_Exam.Models.Donation;

namespace Charity_Donation_Exam.Interfaces;

public interface IDonation
{
    DonationViewModel Create(DonationCreateModel donation);
    DonationViewModel Update(long Id, DonationUpdateModel donation);
    bool Delete(long Id);
    DonationViewModel GetById(long Id);
    IEnumerable<Donation> GetAll();
}
