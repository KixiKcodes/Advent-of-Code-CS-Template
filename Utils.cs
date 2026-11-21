namespace AdventOfCode2026;

public static class Utils {
    public readonly record struct Position(int X, int Y) {
        public static Position operator +(Position a, Position b) =>
            new(a.X + b.X, a.Y + b.Y);
    }

    public readonly struct Positions {
        public static readonly Position TopLeft = new(-1, -1);
        public static readonly Position Top = new(0, -1);
        public static readonly Position TopRight = new(1, -1);
        public static readonly Position Left = new(-1, 0);
        public static readonly Position Right = new(1, 0);
        public static readonly Position BottomLeft = new(-1, 1);
        public static readonly Position Bottom = new(0, 1);
        public static readonly Position BottomRight = new(1, 1);

        public static readonly Position[] SoroundingPositions = [
            TopLeft,    Top,    TopRight,
            Left,       /*@*/   Right,
            BottomLeft, Bottom, BottomRight
        ];

        public static readonly Position[] CardinalPositions = [
                  Top,
            Left, /*@*/  Right,
                  Bottom
        ];
    }

    public static List<string> ParseLines(string inputPath) {
        return [.. File.ReadAllLines(inputPath)];
    }

    public static string ParseText(string inputPath) {
        return File.ReadAllText(inputPath);
    }

    public static bool IsInBounds(int x, int y, int width, int height) {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
