using UnityEngine;

public class Offset2
{
    public int X;
    public int Y;
    public Offset2(int x, int y) {
        X = x;
        Y = y;
    }

    public static Offset2 operator +(Offset2 a, Offset2 b) {
        return new Offset2(a.X + b.X, a.Y + b.Y);
    }

    public static Offset2 operator -(Offset2 a, Offset2 b) {
        return new Offset2(a.X - b.X, a.Y - b.Y);
    }
}
