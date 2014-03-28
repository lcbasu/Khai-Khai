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



        static int N=20; //playing set of pics
        static int X=100; //total number of pics
        static int R=12; //number of rounds
        static int K = 12; //rate change constant

        int winner=-1;
        int[] cont=new int[N];
        int[,] game = new int[R, 2];
        double[] expectar = new double[N];
        double[] ratear = new double[N];

        int[,] randArr = new int[R,2];

        Random rnd = new Random();


        public void contestant()
        {
            int i = 1;
            cont[0] = rnd.Next(1, X+1);
            while (i < N)
            {


                int v = rnd.Next(1, X+1);
                int j;
                for (j = 0; j < i; j++)
                {
                    if (v == cont[j]) break;
                }
                if (i == j)
                {
                    cont[i] = v;
                    i++;
                }
            }
        }


        //rounds

        public void round()
        {
        int f=0;
        int[,] plays = new int[N, N];

        for(int i=0; i<N; i++)
            for(int j=0; j<N; j++) 
                plays[i,j]=0;

        for(int i=0; i<R; i++)
        {

	        int a = rnd.Next(0, N);
	        int b = rnd.Next(0, N);
	        if(a==b){i--; continue;}
	        if(plays[a,b]==1 || plays[b,a]==1) {i--; continue;}
	        plays[a,b]=plays[b,a]=1;
	        
            game[f,0]=cont[a];	
	        game[f,1]=cont[b];

            randArr[f, 0] = a;
            randArr[f, 1] = b;
	        
            f++;
        }
        }


        //winner

        public void win()
        {
            double max = 0;
            int i;
            for (i = 0; i < N; i++)
            {

                if (max < ratear[i])
                { 
                    max = ratear[i]; 
                    winner = i; 
                }
            }
        }




        int number = 0;
        int globalIndex = 0;
        int totalPlayTime = 0;
        public int FileCounter = 1;
        public string fileName;


        int[] playerScore = new int[X+1];
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

            contestant();
            round();


            changeDisplay();
            dispatcherTimer.Interval = new TimeSpan(0,0,0,1,0);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        private void initializeArray()
        {
            int i;
            for (i = 0; i < N; i++)
                ratear[i] = 2100;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            TimerBlock.Text = timerPattern[2-number];
            number = number + 1;

            if(totalPlayTime >= R)
            {
                win();

                int winnerIndex = cont[winner];

                string winnerName = photoName[winnerIndex];

                TimerBlock.Text = "Winner is " + winnerName;

                dispatcherTimer.Stop();

                string winUrl = string.Format("/Winner.xaml?name={0}&photoID={1}", winnerName, winnerIndex);

                NavigationService.Navigate(new Uri(winUrl, UriKind.Relative));
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

            globalIndex = 1 + totalPlayTime % R;
            int u = (game[globalIndex-1,0] % 100);
            int v = (game[globalIndex - 1,1] % 100);

            string index1 = u.ToString();
            string index2 = v.ToString();

            NameButton1.Content = photoName[u];
            NameButton1.BorderThickness = new Thickness(0.0);
            NameButton2.Content = photoName[v];
            NameButton2.BorderThickness = new Thickness(0.0);

            var firstFileName = string.Format(fname, index1);
            var secondFileName = string.Format(fname, index2);

            Uri uri1 = new Uri(firstFileName, UriKind.Relative);
            Uri uri2 = new Uri(secondFileName, UriKind.Relative);
            StreamResourceInfo resourceInfo1 = Application.GetResourceStream(uri1);
            StreamResourceInfo resourceInfo2 = Application.GetResourceStream(uri2);
            BitmapImage bmp1 = new BitmapImage();
            bmp1.SetSource(resourceInfo1.Stream);

            BitmapImage bmp2 = new BitmapImage();
            bmp2.SetSource(resourceInfo2.Stream);
            //ImgBox1.Source = bmp;
            //ImgBox2.Source = bmp;


            var brush1 = new ImageBrush();
            brush1.ImageSource = bmp1;
            ImageButton1.Background = brush1;
            ImageButton1.BorderThickness = new Thickness(0.0);

            var brush2 = new ImageBrush();
            brush2.ImageSource = bmp2;
            ImageButton2.Background = brush2;
            ImageButton2.BorderThickness = new Thickness(0.0);


            UserTurn.Text = players[totalPlayTime%4];

            number = 0;


            int a = (randArr[globalIndex-1,0] % 100);
            int b = (randArr[globalIndex - 1,1] % 100);


            expectar[a] = (1*1.0)/(1+Math.Pow(10,(ratear[a]-ratear[b])/400));
            expectar[b] = (1*1.0)/(1+Math.Pow(10,(ratear[b]-ratear[a])/400));

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
            int W=1, WNOT=0;
            WNOT = 1 - W;
            int a = (randArr[globalIndex - 1, 0] % 100);
            int b = (randArr[globalIndex - 1, 1] % 100);
            ratear[a] = ratear[a] + K * (W - expectar[a]);
            ratear[b] = ratear[b] + K * (WNOT - expectar[b]);
            totalPlayTime++;
            changeDisplay();
        }

        private void ImageButton2_Click(object sender, RoutedEventArgs e)
        {
            int W = 0, WNOT = 1;
            WNOT = 1 - W;
            int a = (randArr[globalIndex - 1, 0] % 100);
            int b = (randArr[globalIndex - 1, 1] % 100);
            ratear[a] = ratear[a] + K * (W - expectar[a]);
            ratear[b] = ratear[b] + K * (WNOT - expectar[b]);            
            totalPlayTime++;
            changeDisplay();
        }
    }
}