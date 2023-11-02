
using Microsoft.VisualBasic;

namespace EfuApp.Plugins.Sqlite;

public class Constants
{
     public const string DatabaseFileName = "EfuAppSQLiteDb.db3";
     public static string DatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFileName);

     public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // The file is encrypted and inaccessible while the device is locked.
            SQLite.SQLiteOpenFlags.ProtectionComplete |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
}
