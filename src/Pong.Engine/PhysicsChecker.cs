using System;

namespace Pong.Engine
{
    public class PhysicsChecker
    {
        public static bool CanBoardMove(Board board, Map map, int step)
        {
            var topY = FindTopY(board);
            var bottomY = FindBottomY(board);
            var absStep = Math.Abs(step);
            return step < 0 
                ? topY - absStep > 0 
                : bottomY + absStep < map.Height + 1;
        } 
        public static bool CanBoardReflect(Board board, int ballX, int ballY)
        {
            // var topY = FindTopY(board);
            // return CheckReflection(topY, board, ballX, ballY);
            return board.HasTakenPlace(ballX, ballY);
        }

        public static bool IsBallOnMap(Map map, int ballX, int ballY) =>
            ballX > 0 && ballX < map.Width + 1 &&
            ballY > 0 && ballY < map.Height + 1;

        private static int FindTopY(Board board) => board.Y - (board.SizeY >> 1);
        private static int FindBottomY(Board board) => board.Y + (board.SizeY >> 1);

        private static int DiffX(Board board, int ballX) => Math.Abs(board.X - ballX);

        private static bool CheckReflection(int topY, Board board, int ballX, int ballY)
        {
            if (DiffX(board, ballX) >= 0)
                return false;

            return DoCheckReflection(topY, board, ballY);
        }

        private static bool DoCheckReflection(int currentY, Board board, int ballY)
        {
            var canReflect = false;
            for (var i = 0; i < board.SizeY; i++)
            {
                // todo: crap: double indent
                if (currentY++ == ballY)
                {
                    canReflect = true;
                    break;
                }
            }

            return canReflect;
        }
    }
}
