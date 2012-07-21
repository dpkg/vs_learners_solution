using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventsDelegates
{
    class BallEventArgs : EventArgs
    {
        public int Trajectory { get; private set; }
        public int Distance { get; private set; }
        public BallEventArgs(int trajectory, int distance)
        {
            this.Trajectory = trajectory;
            this.Distance = distance;
        }
    }

    class Ball
    {
        public event EventHandler BallInPlay;
        public void OnBallInPlay(BallEventArgs e)
        {
            EventHandler ballInPlay = BallInPlay;
            if (ballInPlay != null)
            {
                ballInPlay(this, e);
            }
        }
    }

    class Pitcher
    {
        void ball_BallInPlay(object sender, EventArgs e)
        {
            //Console.WriteLine("The ball is hit with an angle of {0}, and I'm surely going to catch it.", ((BallEventArgs)e).Angle);
            if (e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;
                Console.WriteLine("Distance : " + ballEventArgs.Distance + " and Trajectory : " + ballEventArgs.Trajectory);
            }
        }

        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new EventHandler(ball_BallInPlay);
        }
    }

    class Program
    {
        static void Main1(string[] args)
        {
            Ball ball = new Ball();
            Pitcher pitcher = new Pitcher(ball);

            BallEventArgs ballEventArgs = new BallEventArgs(45, 100);
            ball.OnBallInPlay(ballEventArgs);
        }

        public static string HiThere(int i)
        {
            return "Hi there! #" + (i * 100);
        }

        public static void Main(string[] args)
        {
            ConvertIntToString c = HiThere;

            Console.WriteLine(c(50));
        }

        
    }
}
