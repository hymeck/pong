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
            // var ball = new Ball();
            // var presenter = new BallPresenter(ball);
            // presenter.Print();
            // Thread.Sleep(1000);
            // ball.MutateX(1);
            // presenter.Print();
            // Thread.Sleep(1000);
            // ball.MutateX(1);
            // presenter.Print();
            // Thread.Sleep(1000);

            var board = new Board(0, 3);
            var boardPresenter = new BoardPresenter(board);
            
            boardPresenter.Print();
            Thread.Sleep(1000);
            board.MutateY(1); // down by 1
            
            boardPresenter.Print();
            Thread.Sleep(1000);
            board.MutateY(1); // down by 1
            
            boardPresenter.Print();
            Thread.Sleep(1000);
            board.MutateY(1); // down by 1
            boardPresenter.Print();
        }
    }
}
