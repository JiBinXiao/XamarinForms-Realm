using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TopToolBar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private BeanRealmService beanRealmService = null;
        public  static  int i = 1;
        public DetailPage()
        {

            beanRealmService = new BeanRealmService();
            //设置导航栏标题
            InitializeComponent();
            //设置回退按钮事件
            var tapGestureRecognizer = new TapGestureRecognizer() { NumberOfTapsRequired = 1 };
            tapGestureRecognizer.Tapped += (s, e) => {
                //  handle the tap
                Navigation.PopModalAsync();
            };
            TopBarBack.GestureRecognizers.Add(tapGestureRecognizer);

           
        }

      

        private void AddButton_Clicked(object sender, EventArgs e)
        {

          
            Bean bean = new Bean();
            bean.Id = DetailPage.i++;
            bean.Name = "Rex";
            bean.Age = 10;
            bean.Counter = 1;
            beanRealmService.AddBean(bean);

            showData.Text = "添加成功";
        }

        private void ShowButton_Clicked(object sender, EventArgs e)
        {

            showData.Text = "";
            //查询所有bean对象
            var oldDogs = beanRealmService.FindAll();
            if (oldDogs != null)
            {
                foreach (Bean bean in oldDogs)
                {

                    showData.Text += "id:" + bean.Id + " name:" + bean.Name + "  age: " + bean.Age + " count:" + bean.Counter+"\n";
                }

            }

        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            showData.Text = "";
            if (beanRealmService.DeleteOneById(1))
                showData.Text = "删除成功";
            else
                showData.Text = "删除失败";
        }

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            showData.Text = "";

            Bean bean = new Bean()
            {
                Id = 1,
                Name="NewBean",
                Age=20,
                Counter=20
            };

            if (beanRealmService.UpdateBean(bean))
                showData.Text = "更新成功";
            else
                showData.Text = "更新失败";

        }

        private void ShowOneButton_Clicked(object sender, EventArgs e)
        {
            showData.Text = "";
            //取出id号为 1 的bean
            var bean = beanRealmService.FindOneById(1);
            if (bean == null)
            {
                showData.Text = "查询失败，无id为1的对象";
            } else
            {
                showData.Text = "id:" + bean.Id + " name:" + bean.Name + "  age: " + bean.Age + " count:" + bean.Counter;
            }
         
          
        }

        private void AddOneButton_Clicked(object sender, EventArgs e)
        {
            showData.Text = "";
            if (beanRealmService.ComputeCount(1, 2))
                showData.Text = "成功";
            else
                showData.Text = "失败";
        }
    }
}
