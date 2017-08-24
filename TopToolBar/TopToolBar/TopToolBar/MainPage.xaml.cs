using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TopToolBar
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
            List<Item> items = new List<Item>();

            Item item= new Item()
            {
                Text = "孙悟空",
                Detail = "俺老孙也如此可爱",
                ImgUrl = "https://ss1.bdstatic.com/70cFvXSh_Q1YnxGkpoWK1HF6hhy/it/u=447557224,3797474535&fm=26&gp=0.jpg"
            };

            for (int i = 0; i < 15; i++)
            {
                items.Add(item);
            }

            listView.ItemsSource = items;
            TopBarTitle.Text = "首页";
           
          
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Item item = listView.SelectedItem as Item;
            DetailPage detailPage = new DetailPage();
            detailPage.BindingContext = item;
            
            Navigation.PushModalAsync(detailPage);
        }
    }
}
