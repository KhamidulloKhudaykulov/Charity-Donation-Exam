using Charity_Donation_Exam.Models.Donation;
using Charity_Donation_Exam.Models.DonationType;
using Charity_Donation_Exam.Models.User;

namespace Charity_Donation_Exam.Extensions;

public static class MapperExtension
{
    public static UserModel ToMap(this UserCreateModel user)
    {
        return new UserModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            Phone = user.Phone,
        };
    }

    public static DonationType ToMap(this DonationTypeCreateModel donation)
    {
        return new DonationType
        {
            Name = donation.Name,
            Description = donation.Description,
            CardNumber = donation.CardNumber,
            TotalAmount = donation.TotalAmount,
        };
    }

    public static Donation ToMap(this DonationCreateModel donation)
    {
        return new Donation
        {
            DonationType = donation.DonationType,
            User = donation.User,
        };
    }

    public static UserModel ToMap(this UserUpdateModel user)
    {
        return new UserModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            Phone = user.Phone,
        };
    }

    public static DonationType ToMap(this DonationTypeUpdateModel donation)
    {
        return new DonationType
        {
            Name = donation.Name,
            Description = donation.Description,
            CardNumber = donation.CardNumber,
            TotalAmount = donation.TotalAmount,
        };
    }

    public static Donation ToMap(this DonationUpdateModel donation)
    {
        return new Donation
        {
            User = donation.User,
            DonationType = donation.DonationType
        };
    }

    public static UserModel ToMap(this UserViewModel user)
    {
        return new UserModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            Password = user.Password,
        };
    }

    public static DonationType ToMap(this DonationTypeViewModel donation)
    {
        return new DonationType
        {
            Name = donation.Name,
            Description = donation.Description,
            CardNumber = donation.CardNumber,
            Id = donation.Id,
            TotalAmount = donation.TotalAmount,
        };
    }

    public static Donation ToMap(this DonationViewModel donation)
    {
        return new Donation
        {
            User = donation.User,
            DonationType = donation.DonationType,
            Id = donation.Id,
        };
    }

    public static UserViewModel ToMap(this UserModel user)
    {
        return new UserViewModel
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            Password = user.Password,
        };
    }

    public static DonationTypeViewModel ToMap(this DonationType donation)
    {
        return new DonationTypeViewModel
        {
            Name = donation.Name,
            Description = donation.Description,
            CardNumber = donation.CardNumber,
            Id = donation.Id,
            TotalAmount = donation.TotalAmount,
        };
    }

    public static DonationViewModel ToMap(this Donation donation)
    {
        return new DonationViewModel
        {
            User = donation.User,
            DonationType = donation.DonationType,
            Id = donation.Id,
        };
    }
}