using SQLite;

namespace CrudDemo.Shared
{
    public class SqliteConnectionFactory
    {
        public ISQLiteAsyncConnection Create()
        {
            return new SQLiteAsyncConnection(
                Path.Combine(FileSystem.Current.AppDataDirectory, "crud-demo.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        }
    }
}
