using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;

namespace Khai_Khai_New
{
    public partial class Topic : PhoneApplicationPage
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        int number = 0;
        Random rand = new Random();

        string[] topics = { "Who is the funniest?", "Who is the most girlish?", "Who is the most trustworthy?", "Who is the coolest?", "Who is the most foodie? "};
        
        public Topic()
        {
            InitializeComponent();

            displayTopic();

            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        private void displayTopic()
        {
            int index = rand.Next(0, 5);
            TopicBox.Text = topics[index];
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {                        
            number = number + 1;
            if (number == 2)
            {
                dispatcherTimer.Stop();
                string winUrl = string.Format("/PlayNow.xaml");
                NavigationService.Navigate(new Uri(winUrl, UriKind.Relative));
            }
        }
    }
}