using Charity_Donation_Exam.Services;
using Charity_Donation_Exam.UI.Admin.DonationType;
using Spectre.Console;

namespace Charity_Donation_Exam.UI.User;

public class UserMainUI
{
    private DonationTypeService donationTypeService;
    private DonateUI DonateUI;

    public UserMainUI(DonationTypeService donationTypeService, DonateUI donateUI)
    {
        this.donationTypeService = donationTypeService;
        this.DonateUI = donateUI;
    }
    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            AnsiConsole.Clear();

            var sign = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Donation System[/]")
                    .PageSize(3)
                    .AddChoices(new[]
                    {
                        "Donate", "Donation Types", "Go back",
                    }));
            switch (sign)
            {
                case "Donate":
                    DonateUI.Display();
                    break;
                case "Donation Types":
                    ListOfDonationTypes();
                    AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(3)
                        .AddChoices(new[]
                        {
                                    "Ok",
                        }));
                    break;
                default:
                    return;
            }
        }
    }

    public void ListOfDonationTypes()
    {
        Table table = new Table();
        table.AddColumn("[bold green]Id[/]");
        table.AddColumn("[bold green]Name[/]");
        table.AddColumn("[bold green]Description[/]");
        table.AddColumn("[bold green]Card Number[/]");
        table.AddColumn("[bold green]Total Amount[/]");
        table.AddColumn("[bold green]Created At[/]");
        foreach (var donation in donationTypeService.GetAll())
        {
            table.AddRow($"{donation.Id}",
                $"{donation.Name}",
                $"{donation.Description}",
                $"{donation.CardNumber}",
                $"{donation.TotalAmount}",
                $"{donation.CreatedAt}");
        }
        AnsiConsole.Write(table);
    }
}
