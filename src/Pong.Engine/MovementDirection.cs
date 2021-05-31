namespace Pong.Engine
{
    public record MovementDirection(int Dx, int Dy)
    {
        public static readonly MovementDirection DownLeft = new(-1, 1);
        public static readonly MovementDirection DownRight = new(1, 1);
        public static readonly MovementDirection UpLeft = new(-1, -1);
        public static readonly MovementDirection UpRight = new(1, -1);

        public MovementDirection ReverseX() => 
            new (-Dx, Dy);
        
        public MovementDirection ReverseY() => 
            new (Dx, -Dy);
        
        public MovementDirection ReverseXY() => 
            new (-Dx, -Dy);
        
        public MovementDirection GetReversedDirection(Axis reverseAxis) =>
            reverseAxis switch
            {
                Axis.Y => ReverseY(),
                Axis.X => ReverseX(),
                Axis.XY => ReverseXY(),
                _ => this
            };
    }
}
