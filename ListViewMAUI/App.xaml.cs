namespace ListViewMAUI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
    }

    static SQLiteDatabase database;

    // Create the database connection as a singleton.
    public static SQLiteDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new SQLiteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SQLLiteSample.db"));
            }
            return database;
        }
    }
}
