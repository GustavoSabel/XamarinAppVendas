
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVendas.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabelEmptyView : ContentView
    {
        public static readonly BindableProperty TextoProperty = BindableProperty.Create(nameof(Texto), typeof(string), typeof(LabelEmptyView), string.Empty);
        public string Texto
        {
            get => (string)GetValue(TextoProperty);
            set => SetValue(TextoProperty, value);
        }

        public LabelEmptyView()
        {
            InitializeComponent();
        }
    }
}