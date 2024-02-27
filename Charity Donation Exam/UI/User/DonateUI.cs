using Charity_Donation_Exam.Extensions;
using Charity_Donation_Exam.Models.Donation;
using Charity_Donation_Exam.Models.User;
using Charity_Donation_Exam.Services;
using Charity_Donation_Exam.UI.Admin.DonationType;
using Spectre.Console;

namespace Charity_Donation_Exam.UI.User;

public class DonateUI
{
    private DonationTypeService DonationTypeService;
    private DonationService DonationService;
    private UserModel UserModel;
    public DonateUI(DonationTypeService donationTypeService,
        DonationService donationService,
        UserViewModel user)
    {
        this.DonationTypeService = donationTypeService;
        this.DonationService = new DonationService();

        if(user != null)
        {
            this.UserModel = user.ToMap();
        }
    }

    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            AnsiConsole.Clear();
            AnsiConsole.WriteLine();
            var choice = AnsiConsole.Ask<long>("[bold green]Enter type of Donation to Donate:[/]");
            try
            {
                var donate = DonationTypeService.GetById(choice);
                var donation = new DonationCreateModel();
                donation.DonationType = donate.ToMap();
                donation.User = this.UserModel;
                long amount = AnsiConsole.Ask<long>("Enter amount: ");
                while(amount <= 0)
                    amount = AnsiConsole.Ask<long>("Enter correctly sum: ");

                DonationTypeService.AddTotal(choice, amount);
                DonationService.Create(donation);
                AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold green]You are Donated successfully[/]")
                        .PageSize(3)
                        .AddChoices(new[]
                        {
                                    "Ok",
                        }));
            }
            catch (Exception ex)
            {
                AnsiConsole.Markup($"[bold red]{ex.Message}[/]");
                AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(3)
                        .AddChoices(new[]
                        {
                                    "Ok",
                        }));
            }
            return;
        }
    }
}
