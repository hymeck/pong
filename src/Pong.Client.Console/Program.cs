using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Pong.Engine;

namespace Pong.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Console.Clear();
            System.Console.CursorVisible = false;
            
            // -- ball rendering --
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

            
            // -- board rendering --
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
            
            
            // -- board moving --
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
            
            
            // -- board reflection --
            // var board = new Board(0, 3);
            // var boardPresenter = new BoardPresenter(board);
            // boardPresenter.Print();
            //
            // var ball = new Ball(3, 3);
            // var ballPresenter = new BallPresenter(ball);
            // ballPresenter.Print();
            //
            // ball.MutateX(-1);
            // ballPresenter.Print();
            // Debug.WriteLine(PhysicsChecker.CanBoardReflect(board, ball)); // false
            //
            // ball.MutateX(-1);
            // ballPresenter.Print();
            // Debug.WriteLine(PhysicsChecker.CanBoardReflect(board, ball)); // true
            
            
            // -- map, control map bounds --
            // var map = new Map(21, 7);
            // var mapPresenter = new MapPresenter(map);
            // mapPresenter.Print();
            //
            // var board = new Board(1, 3);
            // var boardPresenter = new BoardPresenter(board);
            // boardPresenter.Print();
            //
            // var boardMover = new BoardMover(board, map); // it moves board
            // var keyMapper = new KeyMapper(new Dictionary<ConsoleKey, Action>(2)
            // {
            //     {ConsoleKey.W, boardMover.Up},
            //     {ConsoleKey.S, boardMover.Down}
            // });
            //
            // var keyHandler = new KeyHandler(keyMapper); // it handles key pressings and fires board moving
            // boardMover.BoardMoved += boardPresenter.OnBoardMoved; // subscribe to refresh board state
            // while (true)
            // {
            //     // ctrl + c to exit
            //     keyHandler.Handle();
            // }
            
            
            // -- ball rendering --
            // var ball = new Ball(4, 4);
            // var ballPresenter = new BallPresenter(ball);
            // var ballMover = new BallMover(ball);
            // ballMover.BallMoved += ballPresenter.OnBallMoved;
            // ballPresenter.Print();
            //
            // Thread.Sleep(1000);
            // ballMover.MoveUpRight();
            //
            // Thread.Sleep(1000);
            // ballMover.MoveDownRight();
            //
            // Thread.Sleep(1000);
            // ballMover.MoveDownLeft();
            //
            // Thread.Sleep(1000);
            // ballMover.MoveUpLeft();
            
            
            // -- ball moving --
            // var map = new Map(21, 7);
            // var mapPresenter = new MapPresenter(map);
            // mapPresenter.Print();
            //
            // var ball = new Ball(3, 3);
            // var ballPresenter = new BallPresenter(ball);
            // var ballMover = new BallMover(ball, MovementDirection.UpRight);
            // ballMover.BallMoved += ballPresenter.OnBallMoved;
            // ballPresenter.Print();
            //
            // var ballMovementController = new BallMovementController(ballMover, map);
            // var ballMovementTrigger = new BallMovementTrigger(10, ballMovementController.OnMoveOccured);
            // Thread.Sleep(100_000);
            // ballMovementTrigger.Dispose();
            
            
            // -- ball moving with board --
            var map = new Map(21, 10);
            var mapPresenter = new MapPresenter(map);
            mapPresenter.Print();

            var board = new Board(5, 1, 6);
            map.LeftBoard = board;
            var boardPresenter = new BoardPresenter(board);
            boardPresenter.Print();
            var boardMover = new BoardMover(board, map);
            boardMover.BoardMoved += boardPresenter.OnBoardMoved;
            var keyMapper = new KeyMapper(new Dictionary<ConsoleKey, Action>(2)
            {
                {ConsoleKey.W, boardMover.Up},
                {ConsoleKey.S, boardMover.Down}
            });
            var keyHandler = new KeyHandler(keyMapper);
            
            var board2 = new Board(5, 21, 6);
            map.RightBoard = board2;
            var board2Presenter = new BoardPresenter(board2);
            board2Presenter.Print();
            var boardMover2 = new BoardMover(board2, map);
            boardMover2.BoardMoved += board2Presenter.OnBoardMoved;
            var keyMapper2 = new KeyMapper(new Dictionary<ConsoleKey, Action>(2)
            {
                {ConsoleKey.UpArrow, boardMover2.Up},
                {ConsoleKey.DownArrow, boardMover2.Down}
            });
            var keyHandler2 = new KeyHandler(keyMapper2);

            var ball = new Ball(5, 5);
            var ballPresenter = new BallPresenter(ball);
            ballPresenter.Print();
            
            var ballMover = new BallMover(ball, MovementDirection.DownLeft);
            ballMover.BallMoved += ballPresenter.OnBallMoved;

            var ballMovementController = new BallMovementController(ballMover, map);
            var ballMovementTrigger = new BallMovementTrigger(5, ballMovementController.OnMoveOccured);

            while (true)
            {
                Parallel.Invoke(keyHandler.Handle);
                Parallel.Invoke(keyHandler2.Handle);
            }
        }
    }
}
