using System.Diagnostics;
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

            // boardPresenter.Print();
            // Thread.Sleep(1000);
            // board.MutateY(1); // down by 1
            //
            // boardPresenter.Print();
            // Thread.Sleep(1000);
            // board.MutateY(1); // down by 1
            //
            // boardPresenter.Print();
            // Thread.Sleep(1000);
            // board.MutateY(1); // down by 1
            // boardPresenter.Print();
            
            // var board = new Board(0, 3);
            // var boardPresenter = new BoardPresenter(board);
            // boardPresenter.Print();
            //
            // var boardMover = new BoardMover(board); // it moves board
            // var keyHandler = new KeyHandler(boardMover); // it handles key pressings and fires boardMover
            // boardMover.BoardMoved += boardPresenter.OnBoardMoved; // subscribe to refresh board state
            // while (true)
            // {
            //     // ctrl + c to exit
            //     keyHandler.Handle();
            // }
            
            
            var board = new Board(0, 3);
            var boardPresenter = new BoardPresenter(board);
            boardPresenter.Print();

            var ball = new Ball(3, 3);
            var ballPresenter = new BallPresenter(ball);
            ballPresenter.Print();
            
            ball.MutateX(-1);
            ballPresenter.Print();
            Debug.WriteLine(PhysicsChecker.CanBoardReflect(board, ball)); // false
            
            ball.MutateX(-1);
            ballPresenter.Print();
            Debug.WriteLine(PhysicsChecker.CanBoardReflect(board, ball)); // true
        }
    }
}
