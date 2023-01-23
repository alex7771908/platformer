using System;
using System.Collections.Generic;
using System.Diagnostics;//debug and stopwatch
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

namespace Scroller
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double x = 0;
        public double y = 0;
        public double speedX = 200; // how far object will travel in one sec.
        public double speedY = 100; 

        private TimeSpan prevTime;
        private Stopwatch stopwatch = Stopwatch.StartNew();

        public MainWindow()
        {
            InitializeComponent();

            prevTime = stopwatch.Elapsed;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            TimeSpan currentTime = stopwatch.Elapsed;
            double delta = (currentTime - prevTime).TotalSeconds;
            prevTime = currentTime;

            lbl_info.Content = delta;

            //action - every render frame

            Figure figure1 = new Figure(0, 0, 200, 100, ball);
            BallMovement(delta, figure1);
        }

        public void BallMovement(double delta, Figure character)
        {
            if (character.x < 0 || character.x > screen.ActualWidth - character.shape.Width)
            {
                character.speedX = -character.speedX;
            }
            if (character.y < 0 || character.y > screen.ActualHeight - character.shape.Height)
            {
                character.speedY = -character.speedY;
            }
            character.x += character.speedX * delta;
            character.y += character.speedY * delta;

            Canvas.SetLeft(ball, x);
            Canvas.SetTop(ball, y);
        }

        public class Figure
        {
            //fields
            public double x = 0;
            public double y = 0;
            public double speedX = 200; // how far object will travel in one sec.
            public double speedY = 100;
            public Shape shape;

            public Figure(double x, double y, double speedX, double speedY, Shape shape)
            {
                this.x = x;
                this.y = y;
                this.speedX = speedX;
                this.speedY = speedY;
                this.shape = shape;
            }
        }
    }
}
