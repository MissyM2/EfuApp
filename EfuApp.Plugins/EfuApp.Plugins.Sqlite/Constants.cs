
using Microsoft.VisualBasic;

namespace EfuApp.Plugins.Sqlite;

public class Constants
{
     public const string DatabaseFileName = "EfuAppSQLiteDb.db3";
     public static string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFileName);

}
