using SQLite;

namespace CrudDemo.Shared
{
    public class SqliteConnectionFactory
    {
        public ISQLiteAsyncConnection CreateConnection()
        {
            return new SQLiteAsyncConnection(
                Path.Combine(FileSystem.AppDataDirectory, "backlog-demo.db3"),
                SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache);
        }
    }
}
