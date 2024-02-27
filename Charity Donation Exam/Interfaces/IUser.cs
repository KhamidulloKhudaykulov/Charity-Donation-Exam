using Charity_Donation_Exam.Models.User;

namespace Charity_Donation_Exam.Interfaces;

public interface IUser
{
    UserViewModel Create(UserCreateModel user);
    UserViewModel Update(long Id, UserUpdateModel user);
    bool Delete(long Id);
    UserViewModel GetById(long Id);
    List<UserViewModel> GetAll();
    void SignUpUser(UserViewModel user);
    bool SignInUser(string login, string password);
}
