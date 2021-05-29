namespace Pong.Client.Console
{
    public static class ConsoleUtils
    {
        public static void SetCursorAt(int x, int y) => System.Console.SetCursorPosition(x, y);

        public static void ClearCharAtCurrentCursorPosition() => System.Console.Write(" \b");
    }
}