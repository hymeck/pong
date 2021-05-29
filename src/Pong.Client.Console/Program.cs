using System.Threading;
using Pong.Engine;

namespace Pong.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            // System.Console.CursorVisible = false;
            var ball = new Ball();
            var presenter = new BallPresenter(ball);
            presenter.Print();
            Thread.Sleep(1000);
            ball.MutateX(1);
            presenter.Print();
            Thread.Sleep(1000);
            ball.MutateX(1);
            presenter.Print();
            Thread.Sleep(1000);
            
        }
    }
}
