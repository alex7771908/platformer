using System;
using System.Diagnostics;//for stopwatch
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace runner_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //fields
        // collision
        Rect playerHitBox;
        Rect groundHitBox;
        Rect obstacleHitBox;

        bool jumping;
        int force = 200;
        int speed = 50;
        int score = 0;

        Random random = new Random();

        bool gameover = false;

        //graphics
        double numImage = 1;

        ImageBrush playerBrush = new ImageBrush();
        ImageBrush bgBrush = new ImageBrush();
        ImageBrush obstacleBrush = new ImageBrush();

        //rendering
        TimeSpan prevTime;
        Stopwatch stopwatch = Stopwatch.StartNew();

        public MainWindow()
        {
            InitializeComponent();

            Init();

            CompositionTarget.Rendering += CompositionTarget_Rendering;

            prevTime = stopwatch.Elapsed;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopwatch.Elapsed;
            double delta = (currentTime - prevTime).TotalSeconds;
            prevTime = currentTime;

            Update(delta);
        }

        public void Update(double delta)
        {
            // gravity
            Canvas.SetTop(player, Canvas.GetTop(player) + force * delta);

            //move bg
            Canvas.SetLeft(bg_1, Canvas.GetLeft(bg_1) - speed * delta);
            Canvas.SetLeft(bg_2, Canvas.GetLeft(bg_2) - speed * delta);

            playerHitBox = new Rect(Canvas.GetLeft(player), Canvas.GetTop(player),
                player.Width, player.Height);

            groundHitBox = new Rect(Canvas.GetLeft(ground), Canvas.GetTop(ground),
                ground.Width, ground.Height);

            if (playerHitBox.IntersectsWith(groundHitBox))
            {
                numImage += 0.1;
                force = 0;
   
                if (numImage > 8)
                    {
                        numImage = 1;
                    }
                RunAnim(numImage);
 
                
            }
        }

        public void Init()
        {
            bgBrush.ImageSource = new BitmapImage(
                new Uri("pack://application:,,,/images/background.gif"));

            bg_1.Fill = bgBrush;
            bg_2.Fill = bgBrush;

            RunAnim(1);
        }

        public void StartGame()
        {
            
        }

        public void RunAnim(double index)
        {
            playerBrush.ImageSource = new BitmapImage(
                new Uri($"pack://application:,,,/images/run_0{(int)index}.gif"));

            player.Fill = playerBrush;
        }

        private void MapCanvas_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MapCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Space)
            {
                Canvas.SetTop(player, Canvas.GetTop(player) - player.Height);
            }
        }
    }
}
