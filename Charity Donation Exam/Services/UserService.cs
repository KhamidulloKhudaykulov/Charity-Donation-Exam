using Charity_Donation_Exam.Data;
using Charity_Donation_Exam.Extensions;
using Charity_Donation_Exam.Interfaces;
using Charity_Donation_Exam.Models.User;
using Newtonsoft.Json;

namespace Charity_Donation_Exam.Services;

public class UserService : IUser
{
    private List<UserModel> users;
    public UserService()
    {
        users = new List<UserModel>();
        try
        {
            var read = File.ReadAllText(Constants.USER_PATH);
            users = JsonConvert.DeserializeObject<List<UserModel>>(read);
        }
        catch
        {
            var user = JsonConvert.DeserializeObject<UserModel>(Constants.USER_PATH);
            if (user is not null)
                users.Add(user);
        }
    }
    public UserViewModel Create(UserCreateModel user)
    {
        if (users is null)
            users = new List<UserModel>();
        var addUser = user.ToMap();
        addUser.Id = users.Count;
        users.Add(addUser);

        var json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(Constants.USER_PATH, json);
        return addUser.ToMap();
    }

    public bool Delete(long Id)
    {
        var existUser = users.FirstOrDefault(u => u.Id == Id);
        if (existUser is not null)
        {
            users.Remove(existUser);
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(Constants.USER_PATH, json);
            return true;
        }
        
        return false;
    }

    public List<UserViewModel> GetAll()
    {
        var content = File.ReadAllText(Constants.USER_PATH);
        if (content.Length == 0)
            return new List<UserViewModel>();
        try
        {
            var json = JsonConvert.DeserializeObject<List<UserViewModel>>(content);
            return json;
        }
        catch
        {
            var json = JsonConvert.DeserializeObject<UserViewModel>(content);
            users.Add(json.ToMap());
            var returnList = new List<UserViewModel>();
            returnList.Add(json);
            return returnList;
        }
    }

    public UserViewModel GetById(long Id)
    {
        var content = File.ReadAllText(Constants.USER_PATH);
        try
        {
            var existUser = users.FirstOrDefault(u => u.Id == Id);
            if (existUser.IsDeleted == true || existUser is null)
                throw new Exception("This user is not Found");
            return existUser.ToMap();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public UserViewModel GetByLogin(string login)
    {
        var content = File.ReadAllText(Constants.USER_PATH);
        try
        {
            var existUser = users.FirstOrDefault(u => u.Email == login);
            if (existUser.IsDeleted == true || existUser is null)
                throw new Exception("This user is not Found");
            return existUser.ToMap();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public bool SignInUser(string login, string password)
    {
        var allUsers = GetAll();
        if (allUsers.Count != 0)
        {
            var checkLogin = allUsers.FirstOrDefault(u => u.Email == login);
            if (checkLogin is null)
                throw new Exception("Incorrect login or password");

            if (checkLogin.Password != password)
                throw new Exception("Incorrect login or password");

            return true;
        }
        return false;
    }

    public void SignUpUser(UserViewModel user)
    {
        var allUsers = GetAll();
        if (allUsers.Count != 0)
        {
            var checkLogin = allUsers.FirstOrDefault(u => u.Email == user.Email);
            var checkPassword = allUsers.FirstOrDefault(p => p.Password == user.Password);

        }

        var singUpUser = new UserCreateModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            Phone = user.Phone,
        };

        Create(singUpUser);
    }

    public UserViewModel Update(long Id, UserUpdateModel user)
    {
        return null;
    }
}
