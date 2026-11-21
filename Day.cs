namespace AdventOfCode2026;

public abstract class Day {
    public abstract int DayNumber { get; }
    protected string InputPath { get; private set; } = "";

    public void LoadInput(bool test) {
        string directory = test ? "tests" : "inputs";

        InputPath = Path.Combine( "resources", directory, $"Day{DayNumber:D2}.txt");
        if (!File.Exists(InputPath))
            throw new FileNotFoundException($"Missing {(test ? "test" : "input")} file for Day {DayNumber}.", InputPath);
    }

    public abstract void PartOne();
    public abstract void PartTwo();
}
