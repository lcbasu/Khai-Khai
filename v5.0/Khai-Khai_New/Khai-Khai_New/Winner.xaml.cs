using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Khai_Khai_New
{
    public partial class Winner : PhoneApplicationPage
    {
        public Winner()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Let base handle
            base.OnNavigatedTo(e);
            // Get the ProductId
            string winName = NavigationContext.QueryString["name"];
            WinnerName.Text = winName;

            string winId = NavigationContext.QueryString["photoID"];


            string fname = "Images/{0}.JPG";

            string index1 = winId;

            var firstFileName = string.Format(fname, index1);           

            Uri uriR = new Uri(firstFileName, UriKind.Relative);
            BitmapImage imgSourceR = new BitmapImage(uriR);
            this.WinnerImage.Source = imgSourceR;



            //// Get the Rating
            //string winnerPhotoId = string.Format("/Images/2.JPG", NavigationContext.QueryString["photoID"]);


            //Uri uri = new Uri("/Images/2.JPG", UriKind.Relative);

            //StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
            //BitmapImage bmp = new BitmapImage();
            //bmp.SetSource(resourceInfo.Stream);

            //WinnerImage.Source = bmp;

        }
    }
}