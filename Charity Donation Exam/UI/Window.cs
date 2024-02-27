using Charity_Donation_Exam.Services;
using Charity_Donation_Exam.UI.Admin;
using Charity_Donation_Exam.UI.Admin.DonationType;
using Charity_Donation_Exam.UI.User;
using Spectre.Console;

namespace Charity_Donation_Exam.UI;

public class Window
{
    private UserService userService;
    private DonationTypeService donationTypeService;

    private EnteringAdmin EnteringAdmin;
    private EnteringUser EnteringUser;
    private DonationTypesUI DonationTypesUI;

    private DonationTypesUI donationTypesUI;
    private DonationService donationService;

    public Window()
    {
        this.userService = new UserService();
        this.donationTypeService = new DonationTypeService();
        this.donationService = new DonationService();

        this.DonationTypesUI = new DonationTypesUI(donationTypeService);
        this.EnteringAdmin = new EnteringAdmin(userService, DonationTypesUI);
        EnteringUser = new EnteringUser(userService, donationTypesUI, donationTypeService, donationService);
    }
    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            AnsiConsole.Clear();
            var Choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Yurak Amri Platform[/]")
                    .PageSize(5)
                    .AddChoices(new[]
                    {
                        "About Us", "Sign In / Sing Up", "For Administrators", "Exit",
                    }));
            switch (Choice)
            {
                case "About Us":
                    AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("[green]A world renovned charity platform. Uzbek sila![/]")
                            .PageSize(5)
                            .AddChoices(new[]
                            {
                                "Ok",
                            }));
                            break;
                case "Sign In / Sing Up":
                    EnteringUser.Display();
                    break;
                case "For Administrators":
                    EnteringAdmin.Display();
                    break;
                case "Exit":
                    return;
            }
        }

    }
}
