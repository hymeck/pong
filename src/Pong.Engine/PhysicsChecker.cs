using System;

namespace Pong.Engine
{
    public class PhysicsChecker
    {
        private static bool CanBoardMove(int mapHeight, int step, int topY, int bottomY)
        {
            var absStep = Math.Abs(step);
            return step < 0
                ? topY - absStep > 0
                : bottomY + absStep < mapHeight + 1;
        }

        public static bool CanBoardMove(Board board, Map map, int step) => 
            CanBoardMove(map.Height, step, board.TopY, board.BottomY); 

        public static bool CanBoardReflect(Board board, int ballX, int ballY) => 
            Math.Abs(board.X - ballX) == 1 &&
            ballY >= board.TopY && ballY <= board.BottomY;

        public static bool CanMapReflect(Map map, int ballX, int ballY) =>
            (ballY == 1 || Math.Abs(ballY - map.Height) == 0) ||
            (ballX == 1 || Math.Abs(ballX - map.Width) == 0);

        public static bool IsBallOnMap(Map map, int ballX, int ballY) =>
            ballX > 0 && ballX < map.Width + 1 &&
            ballY > 0 && ballY < map.Height + 1;
    }
}
