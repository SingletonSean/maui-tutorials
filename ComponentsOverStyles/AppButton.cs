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
                propertyChanged: OnVariantPropertyChanged);
        public VariantType Variant
        {
            get => (VariantType)GetValue(VariantProperty);
            set => SetValue(VariantProperty, value);
        }

        public static readonly BindablePropertyKey VariantBackgroundColorProperty =
            BindableProperty.CreateReadOnly(nameof(VariantBackgroundColor), typeof(Color), typeof(AppButton), null);
        public Color VariantBackgroundColor
        {
            get => (Color)GetValue(VariantBackgroundColorProperty.BindableProperty);
            private set => SetValue(VariantBackgroundColorProperty, value);
        }

        public static readonly BindablePropertyKey VariantForegroundColorProperty =
            BindableProperty.CreateReadOnly(nameof(VariantForegroundColor), typeof(Color), typeof(AppButton), null);
        public Color VariantForegroundColor
        {
            get => (Color)GetValue(VariantForegroundColorProperty.BindableProperty);
            private set => SetValue(VariantForegroundColorProperty, value);
        }

        public static readonly BindableProperty OutlineProperty =
            BindableProperty.Create(nameof(Outline), typeof(bool), typeof(AppButton), false);
        public bool Outline
        {
            get => (bool)GetValue(OutlineProperty);
            set => SetValue(OutlineProperty, value);
        }

        public AppButton()
        {
            UpdateVariantColors();
        }

        private static void OnVariantPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is AppButton button)
            {
                button.UpdateVariantColors();
            }
        }

        private void UpdateVariantColors()
        {
            switch (Variant)
            {
                case VariantType.Primary:
                    VariantBackgroundColor = Color.FromArgb("#475BA1");
                    VariantForegroundColor = Color.FromArgb("#ffffff");
                    break;
                case VariantType.Secondary:
                    VariantBackgroundColor = Color.FromArgb("#FFD97A");
                    VariantForegroundColor = Color.FromArgb("#000000");
                    break;
                default:
                    break;
            }
        }
    }
}
