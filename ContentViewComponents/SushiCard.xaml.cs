using System.Windows.Input;

namespace ContentViewComponents;

public partial class SushiCard : ContentView
{
    public static readonly BindableProperty TitleProperty =
		BindableProperty.Create(nameof(Title), typeof(string), typeof(SushiCard), string.Empty);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(nameof(Description), typeof(string), typeof(SushiCard), string.Empty);

    public string Description
    {
        get => (string)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly BindableProperty AddToCartCommandProperty =
        BindableProperty.Create(nameof(AddToCartCommand), typeof(ICommand), typeof(SushiCard), null);

    public ICommand AddToCartCommand
    {
        get => (ICommand)GetValue(AddToCartCommandProperty);
        set => SetValue(AddToCartCommandProperty, value);
    }

    public SushiCard()
	{
		InitializeComponent();
	}
}