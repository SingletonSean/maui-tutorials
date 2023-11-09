namespace ReactiveCodeBehind;

public class Counter : ContentView
{
	private record CounterState(int Count, int MaxCount);

    private CounterState _state;
    private CounterState State 
    {
        get => _state;
        set
        {
            _state = value;
            Render();
        }
    }

    public Counter()
    {
        State = new CounterState(0, 5);

        Render();
    }

    private void HandleIncrementClicked(object sender, EventArgs e)
    {
        if (State.Count == State.MaxCount)
        {
            return;
        }

        State = State with
        {
            Count = State.Count + 1
        };
    }

    private void Render()
    {
        Content = new VerticalStackLayout 
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            Children =
            {
                new Label 
                { 
                    Text = State.Count.ToString(), 
                    FontSize = 48, 
                    HorizontalTextAlignment = TextAlignment.Center 
                },
                new ReactiveButton 
                { 
                    Text = "Increment", 
                    Margin = new Thickness(0, 20, 0, 0), 
                    FontAttributes = FontAttributes.Bold,
                    OnClick = HandleIncrementClicked 
                },
                State.Count == State.MaxCount ? 
                    new Label 
                    { 
                        Text = "You have reached the maximum count!",
                        Margin = new Thickness(0, 5, 0, 0) 
                    } : 
                    null
            }
        };
    }

    private class ReactiveButton : Button
    {
        public EventHandler OnClick
        {
            init
            {
                Clicked += value;
            }
        }
    }
}