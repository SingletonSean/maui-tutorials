namespace ComponentsOverStyles
{
    public enum VariantType
    {
        Primary,
        Secondary,
    }
    public class AppButton : Button
    {
        public static readonly BindableProperty VariantProperty =
            BindableProperty.Create(nameof(Variant), typeof(VariantType), typeof(AppButton), null, 
                propertyChanged: OnStylePropertyChanged);
        public VariantType Variant
        {
            get => (VariantType)GetValue(VariantProperty);
            set => SetValue(VariantProperty, value);
        }

        public static readonly BindableProperty OutlineProperty =
            BindableProperty.Create(nameof(Outline), typeof(bool), typeof(AppButton), false,
                propertyChanged: OnStylePropertyChanged);
        public bool Outline
        {
            get => (bool)GetValue(OutlineProperty);
            set => SetValue(OutlineProperty, value);
        }

        public AppButton()
        {
            UpdateStyle();
        }

        private static void OnStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is AppButton button)
            {
                button.UpdateStyle();
            }
        }

        private void UpdateStyle()
        {
            VariantColor? variantColor = GetVariantColor();

            if (Outline)
            {
                BackgroundColor = Color.FromArgb("#ffffff");
                TextColor = Color.FromArgb("#000000");
                BorderWidth = 1;
                BorderColor = variantColor?.Background;
            }
            else
            {
                BackgroundColor = variantColor?.Background;
                TextColor = variantColor?.Foreground;
                BorderWidth = 0;
                BorderColor = null;
            }
        }

        private VariantColor? GetVariantColor()
        {
            switch (Variant)
            {
                case VariantType.Primary:
                    return new VariantColor(Color.FromArgb("#475BA1"), Color.FromArgb("#ffffff"));
                case VariantType.Secondary:
                    return new VariantColor(Color.FromArgb("#FFD97A"), Color.FromArgb("#000000"));
                default:
                    return null;
            }
        }

        private record VariantColor(Color Background, Color Foreground);
    }
}
