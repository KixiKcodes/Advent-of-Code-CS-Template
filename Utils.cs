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

    public readonly struct Grid<T> {
        private readonly T[,] cells;
        public int Height { get; }
        public int Width { get; }

        public Grid(IReadOnlyList<string> lines, Func<char, T> converter) {
            Height = lines.Count;
            Width = lines[0].Length;
            cells = new T[Height, Width];

            for (int r = 0; r < Height; r++)
                for (int c = 0; c < Width; c++)
                    cells[r, c] = converter(lines[r][c]);
        }

        public T this[int row, int col] {
            get => cells[row, col];
            set => cells[row, col] = value;
        }

        public bool IsInBounds(Position pos) {
            return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height;
        }

        public void Print() {
            for (int r = 0; r < Height; r++) {
                for (int c = 0; c < Width; c++)
                    Console.Write(cells[r, c]);
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }


    public static List<string> ParseLines(string inputPath) {
        return [.. File.ReadAllLines(inputPath)];
    }

    public static string ParseText(string inputPath) {
        return File.ReadAllText(inputPath);
    }
}
