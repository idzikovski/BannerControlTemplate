using System.ComponentModel;
using Xamarin.Forms;
using BannerTestApp.ViewModels;

namespace BannerTestApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
