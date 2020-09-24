using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace NovacleanX.Views
{
    public partial class SimpleModalPage : PopupPage
    {
        public SimpleModalPage()
        {
            InitializeComponent();
        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}
