using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.Shared
{
    public class Link : Button
    {
        public static readonly BindableProperty RouteProperty =
            BindableProperty.Create(nameof(Route), typeof(string), typeof(Link), "");

        public string Route
        {
            get => (string)GetValue(RouteProperty);
            set => SetValue(RouteProperty, value);
        }

        public Link()
        {
            Clicked += Link_Clicked;
        }

        private async void Link_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(Route);
        }
    }
}
