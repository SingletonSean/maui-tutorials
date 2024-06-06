using CrudDemo.Entities;
using CrudDemo.Shared;
using SQLite;

namespace CrudDemo
{
    public partial class App : Application
    {
        private readonly SqliteConnectionFactory _dbConnectionFactory;

        public App(SqliteConnectionFactory dbConnectionFactory)
        {
            InitializeComponent();

            MainPage = new AppShell();

            _dbConnectionFactory = dbConnectionFactory;
        }

        protected override async void OnStart()
        {
            ISQLiteAsyncConnection database = _dbConnectionFactory.Create();

            await database.CreateTableAsync<TicketDto>();

            base.OnStart();
        }
    }
}
