using Charity_Donation_Exam.Extensions;
using Charity_Donation_Exam.Services;
using Spectre.Console;

namespace Charity_Donation_Exam.UI.Admin.UserCategory;

public class UserCategoryUI
{
    private UserService UserService;
    public UserCategoryUI(UserService userService)
    {
        this.UserService = userService;
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
                        "Get Users",
                        "Delete User",
                        "Go back"
                    }));
            switch (sign)
            {
                case "Get Users":
                    ListOfUsers();
                    AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                    "Ok",
                                }));
                    break;
                case "Delete User":
                    var deleteId = AnsiConsole.Ask<long>("Enter User ID: ");
                    try
                    {
                        UserService.Delete(deleteId);
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title($"[bold red]You are deleted this User[/]")
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                    "Ok",
                                }));
                    }
                    catch(Exception ex)
                    {
                        AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title($"[bold red]{ex.Message}[/]")
                                .PageSize(3)
                                .AddChoices(new[]
                                {
                                    "Ok",
                                }));
                    }
                    break;
                default:
                    return;
            }
        }
    }

    public void ListOfUsers()
    {
        Table table = new Table();
        table.AddColumn("[bold green]Id[/]");
        table.AddColumn("[bold green]First Name[/]");
        table.AddColumn("[bold green]Last Name[/]");
        table.AddColumn("[bold green]Email[/]");
        table.AddColumn("[bold green]Password[/]");
        table.AddColumn("[bold green]Phone number[/]");
        table.AddColumn("[bold red]Is Deleted[/]");
        foreach (var user in UserService.GetAll())
        {
            table.AddRow($"{user.Id}",
                $"{user.FirstName}",
                $"{user.LastName}",
                $"{user.Email}",
                $"{user.Password}",
                $"{user.Phone}",
                $"{user.ToMap().IsDeleted}");
        }
        AnsiConsole.Write(table);
    }
}
