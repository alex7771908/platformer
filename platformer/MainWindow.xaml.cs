using System;
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
using System.Threading;

using System.Diagnostics; // Debug Console
using System.Windows.Threading; // For TImer

namespace platformer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //fields
        private bool bLeft;
        private bool bRight;
        private int speed = 2;
        public int money = 0;
        private int drop = 2;

        public MainWindow()
        {
            InitializeComponent();
            lbl_portal.Visibility = Visibility.Hidden;
            CompositionTarget.Rendering += CompositionTarget_Rendering;

        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            double y = Canvas.GetTop(player);
            Canvas.SetTop(player, y + drop);

            Rect playerCollision = new Rect(Canvas.GetLeft(player), y, player.Width, player.Height);

            //Shape rectangleForRemove = null;

            var rectangle = MyCanvas.Children.OfType<Shape>();

            foreach (var shape in MyCanvas.Children.OfType<Shape>())
            {
                if (shape.Tag != null)
                {

                    //drop = 0
                    Rect rectCollision = new Rect(Canvas.GetLeft(shape), Canvas.GetTop(shape), shape.Width, shape.Height);

                    if (shape.Tag.ToString() == "platform")
                    {
                        if (playerCollision.IntersectsWith(rectCollision))
                        {
                            drop = 0;

                            Canvas.SetTop(player, Canvas.GetTop(shape) - player.Height);
                        }
                        else
                        {
                            drop = 2;
                        }
                    }

                    if (shape.Tag.ToString() == "coin")
                    {
                        if (playerCollision.IntersectsWith(rectCollision))
                        {
                            if (shape.Visibility == Visibility.Visible)
                            {
                                //rect.Fill = Brushes.Red;
                                shape.Visibility = Visibility.Hidden;

                                //rectangleForRemove = shape;
                                money++;
                                Debug.WriteLine("Coin++");
                            }
                        }
                        

                    }
                    if (shape.Tag.ToString() == "portal")
                    {
                        if (playerCollision.IntersectsWith(rectCollision))
                        {
                            if (CheckCoins())
                            {
                                //rect.Fill = Brushes.Red+;
                                //rect.Visibility = Visibility.Hidden;
                                foreach (var coins in MyCanvas.Children.OfType<Shape>())
                                {
                                    coins.Visibility = Visibility.Visible;
                                }
                                Canvas.SetTop(player, 10);
                                Canvas.SetLeft(player, 120);
                                
                            }
                            else
                            {
                                lbl_portal.Visibility = Visibility.Visible;
                                Thread.Sleep(1000);
                                lbl_portal.Visibility = Visibility.Hidden;
                            }
                            
                     
                        }
                    }

                }


            }
            //удаление
            /*if (rectangleForRemove != null)
            {
                MyCanvas.Children.Remove(rectangleForRemove);
            }*/

            if (bLeft)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) - speed);
            }
            if (bRight)
            {
                Canvas.SetLeft(player, Canvas.GetLeft(player) + speed);
            }
        }

        private bool CheckCoins()
        {
            foreach (var coins in MyCanvas.Children.OfType<Shape>())
            {
                if(coins.Tag != null)
                {
                    if (coins.Tag.ToString() == "coin")
                    {
                        if (coins.Visibility == Visibility.Visible)
                        {
                            return false;
                        }
                    }
                }
                
                
            }
            return true;
        }
        private void Canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left || e.Key == Key.A)
            {
                bLeft = true;
            }else if(e.Key == Key.Right || e.Key == Key.D)
            {
                bRight = true;
            }

            //Debug.WriteLine($"bleft: {bLeft} bright: {bRight}");
        }

        private void Canvas_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.A || e.Key == Key.Left)
            {
                bLeft = false;
            }else if( e.Key == Key.Right || e.Key == Key.D)
            {
                bRight = false;
            }
            //Debug.WriteLine($"bleft: {bLeft} bright: {bRight}");
        }
    }
        
}
