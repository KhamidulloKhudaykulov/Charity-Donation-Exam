using Charity_Donation_Exam.Data;
using Charity_Donation_Exam.Extensions;
using Charity_Donation_Exam.Interfaces;
using Charity_Donation_Exam.Models.DonationType;
using Newtonsoft.Json;

namespace Charity_Donation_Exam.Services;

public class DonationTypeService : IDonationType
{
    private List<DonationType> donations;
    public DonationTypeService()
    {
        donations = new List<DonationType>();
        try
        {
            var read = File.ReadAllText(Constants.DONATION_TYPE_PATH);
            donations = JsonConvert.DeserializeObject<List<DonationType>>(read);
        }
        catch
        {
            var donation = JsonConvert.DeserializeObject<DonationType>(Constants.DONATION_TYPE_PATH);
            if (donation is not null)
                donations.Add(donation);
            else
            {
                donations = new List<DonationType>();
            }
        }
    }
    public DonationTypeViewModel Create(DonationTypeCreateModel donation)
    {
        if (donations is null)
            donations = new List<DonationType>();

        var existDonation = donations.FirstOrDefault(d => d.Name == donation.Name);
        if (existDonation is not null)
            throw new Exception($"The Type with this name is already existed: Name = {donation.Name}");

        var addDonation = donation.ToMap();
        addDonation.Id = donations.Count;
        donations.Add(addDonation);
        var json = JsonConvert.SerializeObject(donations, Formatting.Indented);
        File.WriteAllText(Constants.DONATION_TYPE_PATH, json);
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

    public IEnumerable<DonationType> GetAll()
    {
        var content = File.ReadAllText(Constants.DONATION_TYPE_PATH);

        if (content.Length == 0)
            return Enumerable.Empty<DonationType>();

        var dons = JsonConvert.DeserializeObject<IEnumerable<DonationType>>(content);
        return dons;
    }

    public DonationTypeViewModel GetById(long Id)
    {
        var content = File.ReadAllText(Constants.DONATION_TYPE_PATH);

        if (GetAll().ToList().Count == 0)
            throw new Exception("There are not any Donation Types");

        var json = JsonConvert.DeserializeObject<List<DonationType>>(content);
        var existDonation = json.FirstOrDefault(d => d.Id == Id);
        if (existDonation is null)
            throw new Exception("This Type of Donation is not Found!");

        return existDonation.ToMap();
    }

    public DonationTypeViewModel Update(long Id, DonationTypeUpdateModel donation)
    {

        if (GetAll().ToList().Count == 0)
            throw new Exception("There are not any Donation Types");

        var existDonation = donations.FirstOrDefault(d => d.Id == Id);
        if (existDonation is null)
            throw new Exception("This Type of Donation is not Found!");

        existDonation.Name = donation.Name;
        existDonation.Description = donation.Description;
        existDonation.CardNumber = donation.CardNumber;
        existDonation.UpdatedAt = DateTime.UtcNow;
        var json = JsonConvert.SerializeObject(donations, Formatting.Indented);
        File.WriteAllText(Constants.DONATION_TYPE_PATH, json);
        return existDonation.ToMap();
    }

    public void AddTotal(long Id, long Amount)
    {
        if (GetAll().ToList().Count == 0)
            throw new Exception("There are not any Donation Types");

        var existDonation = donations.FirstOrDefault(d => d.Id == Id);
        if (existDonation is null)
            throw new Exception("This Type of Donation is not Found!");

        existDonation.TotalAmount += Amount;
        var json = JsonConvert.SerializeObject(donations, Formatting.Indented);
        File.WriteAllText(Constants.DONATION_TYPE_PATH, json);
    }
}
