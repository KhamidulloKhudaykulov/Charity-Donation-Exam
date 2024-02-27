using Charity_Donation_Exam.Services;
using Charity_Donation_Exam.UI.Admin.DonationType;
using Charity_Donation_Exam.UI.Admin.UserCategory;
using Spectre.Console;

namespace Charity_Donation_Exam.UI.Admin;

public class EnteringAdmin
{
    private UserService UserService;
    private DonationTypesUI DonationTypesUI;
    private UserCategoryUI UserCategoryUI;
    public EnteringAdmin(UserService userService, DonationTypesUI donationTypesUI)
    {
        this.UserService = userService;
        this.DonationTypesUI = donationTypesUI;
        this.UserCategoryUI = new UserCategoryUI(userService);
    }
    public void Display()
    {
        var sign = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Admin Window[/]")
                    .PageSize(3)
                    .AddChoices(new[]
                    {
                        "Users Category", "Donation Types", "Go back",
                    }));
        switch (sign)
        {
            case "Users Category":
                UserCategoryUI.Display();
                break;
            case "Donation Types":
                DonationTypesUI.Display();
                break;
            case "Go back":
                break;
        }
    }
}
