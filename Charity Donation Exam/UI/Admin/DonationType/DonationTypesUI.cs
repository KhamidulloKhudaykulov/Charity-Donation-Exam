using Charity_Donation_Exam.Models.DonationType;
using Charity_Donation_Exam.Services;
using Spectre.Console;

namespace Charity_Donation_Exam.UI.Admin.DonationType;

public class DonationTypesUI
{
    private DonationTypeService DonationTypeService;
    public DonationTypesUI(DonationTypeService donationTypeService)
    {
        this.DonationTypeService = donationTypeService;
    }
    public void Display()
    {
        bool loop = true;
        while (loop)
        {
            AnsiConsole.Clear();
            var sign = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Donation Types Menu[/]")
                    .PageSize(10)
                    .AddChoices(new[]
                    {
                        "Get All Donation Types",
                        "Create a type of Donation",
                        "Update a type of Donation",
                        "Delete a type of Donation",
                        "Go back"
                    }));
            switch (sign)
            {
                case "Get All Donation Types":
                    ListOfDonationTypes();
                    AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                    "Ok",
                                }));
                    break;

                case "Create a type of Donation":
                    var name = AnsiConsole.Ask<string>("Enter Donation name: ");
                    var desc = AnsiConsole.Ask<string>("Enter Description: ");
                    var card = AnsiConsole.Ask<string>("Enter Card number: ");

                    DonationTypeCreateModel donationType = new DonationTypeCreateModel();
                    donationType.Name = name;
                    donationType.Description = desc;
                    donationType.CardNumber = card;

                    try
                    {
                        DonationTypeService.Create(donationType);
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("[green]The new type is successfully created[/]")
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
                    break;
                case "Update a type of Donation":
                    var updateId = AnsiConsole.Ask<long>("Enter ID: ");
                    try
                    {
                        DonationTypeService.GetById(updateId);
                        var updateName = AnsiConsole.Ask<string>("Enter Donation new name: ");
                        var updateDesc = AnsiConsole.Ask<string>("Enter new Description: ");
                        var updateCard = AnsiConsole.Ask<string>("Enter new Card number: ");

                        DonationTypeUpdateModel donationTypeUpdateModel = new DonationTypeUpdateModel();
                        donationTypeUpdateModel.Name = updateName;
                        donationTypeUpdateModel.Description = updateDesc;
                        donationTypeUpdateModel.CardNumber = updateCard;
                        DonationTypeService.Update(updateId, donationTypeUpdateModel);
                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title($"[green]{ex.Message}[/]")
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                    "Ok",
                                }));
                    }
                    break;
                case "Delete a type of Donation":
                    var deleteId = AnsiConsole.Ask<long>("Enter ID: ");
                    try
                    {
                        DonationTypeService.Delete(deleteId);
                    }
                    catch (Exception ex)
                    {
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title($"[green]{ex.Message}[/]")
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                    "Ok",
                                }));
                    }

                    break;
                case "Go back":
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
        foreach (var donation in DonationTypeService.GetAll())
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
