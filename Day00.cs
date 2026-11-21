// THIS IS A TEST DAY FROM THE PREVIOUS YEAR TO TEST THE UTILS AND FUNCTIONALITY.

using static AdventOfCode2026.Utils;

namespace AdventOfCode2026;

class Day00 : Day {
    public override int DayNumber => 0;
    
    public override void PartOne() {
        Grid<char> grid = new(ParseLines(InputPath), c => c);
        int result = 0;

        for (int r = 0; r < grid.Height; r++) {
            for (int c = 0; c < grid.Width; c++) {
                Position currentPos = new(r, c);
                if (grid[r, c] == '@') {
                    int adjacentRolls = 0;
                    foreach (Position direction in Positions.SoroundingPositions) {
                        Position newPos = currentPos + direction;
                        if (!grid.IsInBounds(newPos))
                            continue;
                        if (grid[newPos.X, newPos.Y] == '@')
                            adjacentRolls++;
                    }
                    if (adjacentRolls < 4)
                        result++;
                } else {
                    continue;
                }
            }
        }

        Console.WriteLine(result);
    }

    public override void PartTwo() {
        Grid<char> grid = new(ParseLines(InputPath), c => c);
        int result = 0;

        while (true) {
            int removedRolls = 0;
            for (int r = 0; r < grid.Height; r++) {
                for (int c = 0; c < grid.Width; c++) {
                    Position currentPos = new(r, c);
                    if (grid[r, c] == '@') {
                        int adjacentRolls = 0;
                        foreach (Position direction in Positions.SoroundingPositions) {
                            Position newPos = currentPos + direction;
                            if (!grid.IsInBounds(newPos))
                                continue;
                            if (grid[newPos.X, newPos.Y] == '@')
                                adjacentRolls++;
                        }
                        if (adjacentRolls < 4) {
                            grid[r, c] = '.';
                            removedRolls++;
                        }
                    } else {
                        continue;
                    }
                }
            }
            result += removedRolls;
            //grid.Print();
            if (removedRolls == 0)
                break;
        }

        Console.WriteLine(result);
    }
}
