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
using Windows.UI.Input;
using System.Windows.Resources;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Khai_Khai_New
{
    public partial class PlayNow : PhoneApplicationPage
    {

        // declaring public variables.

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        int number = 0;
        int globalIndex = 0;
        int totalPlayTime = 0;
        public int FileCounter = 1;
        public string fileName;


        int[] playerScore = new int[101];
        int maxIndex = 0;


        string[] timerPattern = { "00:00", "00:01", "00:02" };

        string[] players = { "Player : A", "Player : B", "Player : C", "Player : D" };

        string[] photoName = {"","Vikram Rathore",
				"Pratik Toshniwal",
				"Kapil Agarwal",
				"Samyak Datta",
				"Lokesh Basu",
				"Nitin Varshney",
				"Sumit Badwal",
				"Abhishek Nayak",
				"Jitesh Khandelwal",
				"Amit Patra",
				"Harsh Jhamtani",
				"Sarvesh Ranjan",
				"Maitresh Agarwal",
				"Raghav Bansal",
				"Vishal Chand",
				"Rohit Sarin",
				"Vikas Agarwal",
				"Nishit Mishra",
				"Archit Agrawal",
				"Ashish Agrawal",
				"Shagun Sodhani",
				"Parag Nandi",
				"Archit Singhal",
				"Garvit Choudhary",
				"Tushar Mehndiratta",
				"Amith Lakkakula",
				"Kanik Gupta",
				"Peeyush Jain",
				"Amish Bedi",
				"Abhay Prakash",
				"Vishal Singh",
				"Sukun Tarachandani",
				"Rohan Kimothi",
				"Ishendra Kashyap",
				"Nimit Jain",
				"Pawan Seerwani (D)",
				"Prakhar Gupta",
				"Madhav Pathak",
				"Kritgya Bawal",
				"Rohit Lodha",
				"Sandeep Sandha",
				"Siddharth Maheshwari",
				"Digant Ray",
				"Abhishek Tayal",
				"Rishabh Sharma",
				"Tarun Valecha",
				"Aniket Roy",
				"Karan Khosla",
				"Vikalp Gupta",
				"Akshay Agarwal",
				"Sunit Singh",
				"Shantanu Agarwal",
				"Vaibhav Kaushal",
				"Chandranshu Garg",
				"Rahul Modi",
				"Abhinav Jain",
				"Shadab Naseem",
				"Lakhvinder Gaba",
				"Aditya Gupta",
				"Vishal Mittal",
				"Ajinkya Mujumdar",
				"Tanuj Agrawal",
				"Deepak Kushwah",
				"Aditya Gokhale",
				"Sumit Kumar",
				"Pravesh Jain",
				"Manish Jangid",
				"Vinayak Shekhar",
				"Kushal Saharan",
				"Giridaran Manivannan",
				"Mit Kotecha",
				"'Rohit Jangid'",
				"Sonesh Jain",
				"Mrigaunk Pillai",
				"Shagun Akarsh",
				"Shivam Gupta",
				"Nitish Sharma",
				"Abhinav Singh",
				"Vipul Chaturvedi",
				"Apurv Srivastava",
				"Siddharth Jain",
				"Mayank Agarwal",
				"Deepankar Dangwal",
				"Sachin Gupta",
				"Subham Singh",
				"Suleep Kumar",
				"Bhisham Pratap",
				"Nitesh Kumar",
				"Mohit Bakshi",
				"Sanket Mehta",
				"Puneet Sharma",
				"Nikhil Goel",
				"Shivam Mangla",
				"Sushobhan Sen",
				"Gaurav Singh",
				"Mayank Garg",
				"Soumitr Pandey",
				"Sushant Ojal",
				"Tupkar Sagar",
				"Ashutosh Singh"};

        public PlayNow()
        {
            InitializeComponent();

            initializeArray();

            changeDisplay();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,1,0);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        private void initializeArray()
        {
            int i;
            for (i = 0; i < 100; i++)
            {
                playerScore[i] = 0;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimerBlock.Text = timerPattern[2-number];
            number = number + 1;

            if(totalPlayTime == 12)
            {

                int i;
                int max = playerScore[0];
                
                for (i = 0; i <= 100; i++)
                {
                    if (playerScore[i] > max)
                    {
                        max = playerScore[i];
                        maxIndex = i;
                    }
                }


                string winner = photoName[maxIndex];

                TimerBlock.Text = "Winner is " + winner;
                dispatcherTimer.Stop();
            }
            if (number == 3)
            {
                totalPlayTime++;
                changeDisplay();
            }
        }

        private void changeDisplay()
        {
            displayNameBox();
            string fname = "Images/{0}.JPG";

            globalIndex = 1 + totalPlayTime % 12;

            string index = globalIndex.ToString();

            var newFileName = string.Format(fname, index);

            Uri uri = new Uri(newFileName, UriKind.Relative);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(resourceInfo.Stream);
            //ImgBox1.Source = bmp;
            //ImgBox2.Source = bmp;


            var brush = new ImageBrush();
            brush.ImageSource = bmp;

            ImageButton1.Background = brush;
            ImageButton1.BorderThickness = new Thickness(0.0);
            ImageButton2.Background = brush;
            ImageButton2.BorderThickness = new Thickness(0.0);

            NameButton1.Content = photoName[globalIndex];
            NameButton1.BorderThickness = new Thickness(0.0);
            NameButton2.Content = photoName[globalIndex];
            NameButton2.BorderThickness = new Thickness(0.0);



            UserTurn.Text = players[totalPlayTime%4];

            number = 0;
        }

        private void displayNameBox()
        {
            string fname = "NameBoxImages/{0}.png";

            int i = 1 + totalPlayTime % 6;

            string index = i.ToString();

            var newFileName = string.Format(fname, index);

            Uri uri = new Uri(newFileName, UriKind.Relative);
            StreamResourceInfo resourceInfo = Application.GetResourceStream(uri);
            BitmapImage bmp = new BitmapImage();
            bmp.SetSource(resourceInfo.Stream);
            //ImgBox1.Source = bmp;
            //ImgBox2.Source = bmp;


            var brush = new ImageBrush();
            brush.ImageSource = bmp;

            NameButton1.Background = brush;
            NameButton2.Background = brush;

        }

        private void ImageButton1_Click(object sender, RoutedEventArgs e)
        {
            playerScore[globalIndex] = playerScore[globalIndex] + 1;
        }

        private void ImageButton2_Click(object sender, RoutedEventArgs e)
        {
            playerScore[globalIndex] = playerScore[globalIndex] + 1;
        }

        private void getWinner()
        {
            int i;
            int max = playerScore[0];
            int maxIndex = 0;
            for (i = 0; i <= 100; i++)
            {
                if (playerScore[i] > max)
                {
                    max = playerScore[i];
                    maxIndex = i;
                }
            }
        }
    }
}