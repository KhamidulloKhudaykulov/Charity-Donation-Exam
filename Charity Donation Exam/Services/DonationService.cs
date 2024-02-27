using Charity_Donation_Exam.Data;
using Charity_Donation_Exam.Extensions;
using Charity_Donation_Exam.Interfaces;
using Charity_Donation_Exam.Models.Donation;
using Newtonsoft.Json;

namespace Charity_Donation_Exam.Services;

public class DonationService : IDonation
{
    private List<Donation> donations;
    public DonationService()
    {
        donations = new List<Donation>();
        try
        {
            var read = File.ReadAllText(Constants.DONATION_PATH);
            donations = JsonConvert.DeserializeObject<List<Donation>>(read);
        }
        catch
        {
            var donation = JsonConvert.DeserializeObject<Donation>(Constants.DONATION_PATH);
            if (donation is not null)
                donations.Add(donation);
        }
    }
    public DonationViewModel Create(DonationCreateModel donation)
    {
        if (donations is null)
            donations = new List<Donation>();

        var addDonation = donation.ToMap();
        addDonation.Id = donations.Count;
        donations.Add(addDonation);
        var json = JsonConvert.SerializeObject(donations, Formatting.Indented);
        File.WriteAllText(Constants.DONATION_PATH, json);
        return donation.ToMap().ToMap();
    }

    public bool Delete(long Id)
    {
        var existDonation = donations.FirstOrDefault(d => d.Id == Id);
        if (existDonation is null)
            throw new Exception("This Type Of Donation Is Not Found!");

        existDonation.IsDeleted = true;
        var json = JsonConvert.SerializeObject(donations, Formatting.Indented);
        File.WriteAllText(json, Constants.USER_PATH);

        return true;
    }

    public IEnumerable<Donation> GetAll()
    {
        return donations;
    }

    public DonationViewModel GetById(long Id)
    {
        var res = donations.FirstOrDefault(donation => donation.Id == Id);
        if (res is null)
            throw new Exception("This donation is not found");

        return res.ToMap();
    }

    public DonationViewModel Update(long Id, DonationUpdateModel donation)
    {
        if (GetAll().ToList().Count == 0)
            throw new Exception("There are not any Donation Types");

        var existDonation = donations.FirstOrDefault(d => d.Id == Id);
        if (existDonation is null)
            throw new Exception("This Type of Donation is not Found!");

        existDonation.DonationType = donation.DonationType;
        existDonation.User = donation.User;
        existDonation.UpdatedAt = DateTime.UtcNow;
        var json = JsonConvert.SerializeObject(donations, Formatting.Indented);
        File.WriteAllText(Constants.DONATION_TYPE_PATH, json);
        return existDonation.ToMap();
    }
}
