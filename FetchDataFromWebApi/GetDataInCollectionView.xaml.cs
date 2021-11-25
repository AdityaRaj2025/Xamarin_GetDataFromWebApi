using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FetchDataFromWebApi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GetDataInCollectionView : ContentPage
    {
        public GetDataInCollectionView()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
        public void onfocus(object obj, EventArgs e)
        {
            var myframe = obj as Frame;
            myframe.BackgroundColor = Color.Red;
        }
    }
}