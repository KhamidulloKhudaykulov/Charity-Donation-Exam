using Charity_Donation_Exam.Models.DonationType;

namespace Charity_Donation_Exam.Interfaces;

public interface IDonationType
{
    DonationTypeViewModel Create(DonationTypeCreateModel donation);
    DonationTypeViewModel Update(long Id, DonationTypeUpdateModel donation);
    bool Delete(long Id);
    DonationTypeViewModel GetById(long Id);
    IEnumerable<DonationType> GetAll();
}