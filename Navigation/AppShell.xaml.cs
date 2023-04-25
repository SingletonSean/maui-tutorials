using Microsoft.Extensions.DependencyInjection;
using Navigation.Pages.Profile;

namespace Navigation
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("profile/address", new AddressRouteFactory());
        }

        private class AddressRouteFactory : RouteFactory
        {
            public override Element GetOrCreate()
            {
                AddressView view = new AddressView();

                view.Title = "Address";

                return view;
            }

            public override Element GetOrCreate(IServiceProvider services)
            {
                AddressView view = services.GetRequiredService<AddressView>();

                view.Title = "Address";

                return view;
            }
        }
    }
}