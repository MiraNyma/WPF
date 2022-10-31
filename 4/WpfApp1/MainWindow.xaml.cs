﻿using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;



namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // This list describes the Bonus Red pieces of Food on the Canvas
        private List<Point> bonusPoints = new List<Point>();

        // This list describes the body of the snake on the Canvas
        private List<Point> snakePoints = new List<Point>();
        private Brush snakeColor = Brushes.Green;
        private enum SIZE
        {
            THIN = 4,
            NORMAL = 6,
            THICK = 8
        };
        private enum MOVINGDIRECTION
        {
            UPWARDS = 8,
            DOWNWARDS = 2,
            TOLEFT = 4,
            TORIGHT = 6
        };

        private TimeSpan FAST = new TimeSpan(1);
        private TimeSpan MODERATE = new TimeSpan(10000);
        private TimeSpan SLOW = new TimeSpan(50000);
        private TimeSpan DAMNSLOW = new TimeSpan(500000);



        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();

        // Movement direction initialisation
        private int direction = 0;

        /* Placeholder for the previous movement direction
         * The snake needs this to avoid its own body.  */
        private int previousDirection = 0;

        /* Here user can change the size of the snake. 
         * Possible sizes are THIN, NORMAL and THICK */
        private int headSize = (int)SIZE.THICK;


        public  DispatcherTimer timer = new DispatcherTimer();

        public int length = 100;
        public int score = 0;
        private Random rnd = new Random();
        public MainWindow()
        {
           
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);

            /* Here user can change the speed of the snake.
             * Possible speeds are FAST, MODERATE, SLOW and DAMNSLOW */
            timer.Interval = MODERATE;
            timer.Start();

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
            paintSnake(startingPoint);
            currentPosition = startingPoint;

            // Instantiate Food Objects
            for (int n = 0; n < 10; n++)
            {
                paintBonus(n);
            }
        }

        private void paintBonus(int index)
        {
            Point bonusPoint = new Point(rnd.Next(5, 620), rnd.Next(5, 380));

            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Red;
            newEllipse.Width = headSize;
            newEllipse.Height = headSize;

            Canvas.SetTop(newEllipse, bonusPoint.Y);
            Canvas.SetLeft(newEllipse, bonusPoint.X);
            paintCanvas.Children.Insert(index, newEllipse);
            bonusPoints.Insert(index, bonusPoint);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Expand the body of the snake to the direction of movement
            //--------------------------------
            switch (direction)
            {
                case (int)MOVINGDIRECTION.DOWNWARDS:
                    currentPosition.Y += 1;
                    paintSnake(currentPosition);
                    break;
                case (int)MOVINGDIRECTION.UPWARDS:
                    currentPosition.Y -= 1;
                    paintSnake(currentPosition);
                    break;
                case (int)MOVINGDIRECTION.TOLEFT:
                    currentPosition.X -= 1;
                    paintSnake(currentPosition);
                    break;
                case (int)MOVINGDIRECTION.TORIGHT:
                    currentPosition.X += 1;
                    paintSnake(currentPosition);
                    break;
            }
            //-------------------------------------------
            // Restrict to boundaries of the Canvas
            if ((currentPosition.X < 5) || (currentPosition.X > 620) ||
       (currentPosition.Y < 5) || (currentPosition.Y > 380))
                GameOver();
            
            
            // Hitting a bonus Point causes the lengthen-Snake Effect
            int n = 0;
            foreach (Point point in bonusPoints)
            {

                if ((Math.Abs(point.X - currentPosition.X) < headSize) &&
                    (Math.Abs(point.Y - currentPosition.Y) < headSize))
                {
                    length += 10;
                    score += 10;
                    
                   
                    // In the case of food consumption, erase the food object
                    // from the list of bonuses as well as from the canvas
                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);
                    paintBonus(n);
                    break;
                }
                n++;
            }

            // Restrict hits to body of Snake

            for (int q = 0; q < (snakePoints.Count - headSize * 2); q++)
            {
                Point point = new Point(snakePoints[q].X, snakePoints[q].Y);
                if ((Math.Abs(point.X - currentPosition.X) < (headSize)) &&
                     (Math.Abs(point.Y - currentPosition.Y) < (headSize)))
                {
                    GameOver();
                    break;
                }
            }
        }
        //-------------------------------------------------------
        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    if (previousDirection != (int)MOVINGDIRECTION.DOWNWARDS)
                        direction = (int)MOVINGDIRECTION.DOWNWARDS;
                    break;
                case Key.Up:
                    if (previousDirection != (int)MOVINGDIRECTION.UPWARDS)
                        direction = (int)MOVINGDIRECTION.UPWARDS;
                    break;
                case Key.Left:
                    if (previousDirection != (int)MOVINGDIRECTION.TOLEFT)
                        direction = (int)MOVINGDIRECTION.TOLEFT;
                    break;
                case Key.Right:
                    if (previousDirection != (int)MOVINGDIRECTION.TORIGHT)
                        direction = (int)MOVINGDIRECTION.TORIGHT;
                    break;
            }
            previousDirection = direction;

        }
        public int count;
        //
        private void paintSnake(Point currentposition)
        {

            /* This method is used to paint a frame of the snake´s body
             * each time it is called. */

          Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = snakeColor;
            newEllipse.Width = headSize;
            newEllipse.Height = headSize;

            Canvas.SetTop(newEllipse, currentposition.Y);
            Canvas.SetLeft(newEllipse, currentposition.X);

            count = paintCanvas.Children.Count;
            paintCanvas.Children.Add(newEllipse);
            snakePoints.Add(currentposition);

            // Restrict the tail of the snake
            if (count > length)
            {
                paintCanvas.Children.RemoveAt(count - length + 9);
                snakePoints.RemoveAt(count - length);
            }
        }
        public class pisteet
        {
       
            public int pisteesi { get; set; }

        }
        //
        private void GameOver()
        {
            
            timer.Stop();
            MessageBox.Show($"Kuolit pisteillä {score.ToString()}");
            paintCanvas.Children.Clear();
            snakePoints.Clear();
            snakePoints.Add(startingPoint);
            paintSnake(startingPoint);
            currentPosition = startingPoint;
            

            var pisteemme = new pisteet
            {
                pisteesi = score

            };
            
            string json = JsonConvert.SerializeObject(pisteemme);
            listBox.Items.Add(json.ToString());
            


            /*Console.WriteLine(File.ReadAllText(fileName));
             * GFG gg = new GFG();
            scores.Add(score);
            scores.Sort();
            scores.Reverse();
            foreach (int g in scores)
            {

                listBox.Items.Add(g);
            }
             * list1.Sort(gg);

            foreach (int g in list1)
            {

                // Display sorted list
                Console.WriteLine(g);

            }
            listBox.Items.Add(scores.ToString());
            */


            bonusPoints.Clear();
            length = 100;
            score = 0;
            for (int n = 0; n < 10; n++)
            {
                paintBonus(n);
            }
            timer.Start();
            
            //listBox.Items.SortDescriptions.Add(
        //new SortDescription("Content", ListSortDirection.Descending));
            
        }
           
        }

    }

