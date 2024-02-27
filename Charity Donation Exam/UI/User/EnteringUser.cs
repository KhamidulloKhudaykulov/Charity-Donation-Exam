using Charity_Donation_Exam.Extensions;
using Charity_Donation_Exam.Models.User;
using Charity_Donation_Exam.Services;
using Charity_Donation_Exam.UI.Admin.DonationType;
using Spectre.Console;

namespace Charity_Donation_Exam.UI.User;

public class EnteringUser
{
    private UserService UserService;
    private UserMainUI MainUI;
    private DonationTypesUI DonationTypesUI;
    private DonationTypeService DonationTypeService;
    private DonateUI DonateUI;
    private UserViewModel UserModel;
    public EnteringUser(UserService UserService, 
        DonationTypesUI donationTypesUI,
        DonationTypeService donationTypeService,
        DonationService donationService)
    {
        this.DonateUI = new DonateUI(donationTypeService, donationService, UserModel);
        this.DonationTypesUI = donationTypesUI;
        this.UserService = UserService;
        this.MainUI = new UserMainUI(donationTypeService, DonateUI);
    }
    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            AnsiConsole.Clear();
            var sign = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Sign In / Sign Up[/]")
                    .PageSize(10)
                    .AddChoices(new[]
                    {
                        "Sign In", "Sign Up", "Go back",
                    }));
            switch (sign)
            {
                case "Sign In":
                    var signInLogin = AnsiConsole.Ask<string>("[bold green]Enter email:[/]");
                    var signInPassword = AnsiConsole.Ask<string>("[bold green]Enter password:[/]");
                    try
                    {
                        UserService.SignInUser(signInLogin, signInPassword);
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                "Go back",
                                }));
                        this.UserModel = UserService.GetByLogin(signInLogin);
                        MainUI.Display();
                        break;
                    }
                    catch(Exception ex)
                    {
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title($"{ex.Message}")
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                "Go back",
                                }));
                        break;
                    }

                case "Sign Up":
                    var fname = AnsiConsole.Ask<string>("[bold green]First Name:[/]");
                    var lname = AnsiConsole.Ask<string>("[bold green]Last Name:[/]");
                    var login = AnsiConsole.Ask<string>("[bold green]Login:[/]");
                    var password = AnsiConsole.Ask<string>("[bold green]Password:[/]");
                    var phone = AnsiConsole.Ask<string>("[bold green]Phone Number:[/]");
                    UserViewModel userViewModel = new UserViewModel();
                    userViewModel.FirstName = fname;
                    userViewModel.LastName = lname;
                    userViewModel.Email = login;
                    userViewModel.Password = password;
                    userViewModel.Phone = phone;
                    try
                    {
                        UserService.SignUpUser(userViewModel);
                        this.UserModel = UserService.GetByLogin(login);
                    }
                    catch
                    {
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("[green]This user is always exists[/]")
                                .PageSize(10)
                                .AddChoices(new[]
                                {
                                "Go back",
                                }));

                        break;
                    }

                    return;

                case "Go back":
                    return;
            }
        }
    }
}
