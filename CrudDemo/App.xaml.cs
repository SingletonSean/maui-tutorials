using CrudDemo.Entities;
using CrudDemo.Shared;
using SQLite;

namespace CrudDemo
{
    public partial class App : Application
    {
        private readonly SqliteConnectionFactory _connectionFactory;

        public App(SqliteConnectionFactory connectionFactory)
        {
            InitializeComponent();

            MainPage = new AppShell();

            _connectionFactory = connectionFactory;
        }

        protected override async void OnStart()
        {
            ISQLiteAsyncConnection database = _connectionFactory.CreateConnection();

            await database.CreateTableAsync<TicketDto>();

            base.OnStart();
        }
    }
}
