using ReactiveUI;
using DatabaseUpdater.Database.Helpers;

namespace DatabaseUpdater.Client.Windows;

public partial class MainViewModel : ReactiveObject
{
    private string _Host = "localhost";
    private string _Port = "5454";
    private string _Database = "DatabaseUpdater";
    private string _UserName = "postgres";
    private string _Password = "1";

    private bool _IsConfirmed = true;

    public string Host { get => _Host; set => this.RaiseAndSetIfChanged(ref _Host, value); }
    public string Port { get => _Port; set => this.RaiseAndSetIfChanged(ref _Port, value); }
    public string Database { get => _Database; set => this.RaiseAndSetIfChanged(ref _Database, value); }
    public string UserName { get => _UserName; set => this.RaiseAndSetIfChanged(ref _UserName, value); }
    public string Password { get => _Password; set => this.RaiseAndSetIfChanged(ref _Password, value); }

    public List<string> Migrations { get; set; }
    public string SelectedMigration { get; set; }

    public bool IsConfirmed { get => _IsConfirmed; set => this.RaiseAndSetIfChanged(ref _IsConfirmed, value); }

    public MainViewModel()
    {
        Migrations = DatabaseHelper.GetLocalMigrations().ToList();
        SelectedMigration = Migrations?.LastOrDefault();
        СonfigureСommands();
    }
}