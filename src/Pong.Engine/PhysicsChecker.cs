using System;

namespace Pong.Engine
{
    public class PhysicsChecker
    {
        public static bool CanBoardReflect(Board board, Ball ball)
        {
            var topY = FindTopY(board);
            return CheckReflection(topY, board, ball);
        }

        private static int FindTopY(Board board)
        {
            var y = board.Y;
            var half = board.SizeY >> 1;
            var topY = y - half;
            return topY;
        }

        private static int AbsDiffX(Board board, Ball ball) => Math.Abs(board.X - ball.X);

        private static bool CheckReflection(int topY, Board board, Ball ball)
        {
            if (AbsDiffX(board, ball) != 1)
                return false;

            return DoCheckReflection(topY, board, ball);
        }

        private static bool DoCheckReflection(int currentY, Board board, Ball ball)
        {
            var canReflect = false;
            for (var i = 0; i < board.SizeY; i++)
            {
                // todo: crap: double indent
                if (currentY++ == ball.Y)
                {
                    canReflect = true;
                    break;
                }
            }

            return canReflect;
        }
    }
}
