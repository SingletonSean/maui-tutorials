
namespace AccordionComponent
{
    public class AccordionBase : TemplatedView
    {
        private Button? _trigger;
        private VisualElement? _content;


        public static readonly BindableProperty IsExpandedProperty =
            BindableProperty.Create(nameof(IsExpanded), typeof(bool), typeof(AccordionBase), false, 
                propertyChanged: OnIsExpandedChanged);

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        private static void OnIsExpandedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is AccordionBase accordionBase)
            {
                accordionBase.SyncIsExpanded();
            }
        }

        protected override void OnApplyTemplate()
        {
            _trigger = GetTemplateChild("Trigger") as Button;
            _content = GetTemplateChild("Content") as VisualElement;

            if (_trigger != null)
            {
                _trigger.Clicked += HandleTriggerClicked;
            }

            SyncIsExpanded();
            
            base.OnApplyTemplate();
        }

        private void HandleTriggerClicked(object? sender, EventArgs e)
        {
            IsExpanded = !IsExpanded;
        }

        private void SyncIsExpanded()
        {
            if (_content == null)
            {
                return;
            }

            _content.IsVisible = IsExpanded;
        }
    }
}
