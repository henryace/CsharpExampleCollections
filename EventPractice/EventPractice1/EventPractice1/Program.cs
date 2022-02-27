// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MySubscriber subscriber = new MySubscriber(); // <1>
subscriber.SetText(); // <3>



public delegate void TextChangedEventHandler(string oldValue, string newValue);
public class MyPublisher
{
    private string _text;

    public TextChangedEventHandler TextChanged;

    public string Text
    {
        get { return _text; }
        set { 
            if(_text != value)
            {
                string old = _text;
                _text = value;
                TextChanged(old, _text);
            }
        }
    }
}

public class MySubscriber
{
    MyPublisher publisher;

    public MySubscriber()
    {
        this.publisher = new MyPublisher();
        publisher.TextChanged = new TextChangedEventHandler(TextChangedHandler);
    }

    public void TextChangedHandler(string oldValue, string newValue)
    {
        Console.WriteLine("Text 屬性已經變成：{0}", newValue);
    }

    public void SetText()
    {
        publisher.Text = "Hello, event!";
    }
}