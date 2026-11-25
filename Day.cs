namespace AdventOfCodeXXXX;

public interface IDay {
    void LoadInput(bool test);
    object PartOne();
    object PartTwo();
}

/// <summary>
/// Abstract class for each day.
/// </summary>
/// <typeparam name="TInput">The parsed type of the input data for the day.</typeparam>
public abstract class Day<TInput>(int DayNumber) : IDay {
    protected string InputFile { get; private set; } = "";

    /// <summary>
    /// Loads the input from the resources based on the day number and the test option. Stores the path to the file in the Day's InputPath.
    /// </summary>
    /// <param name="test">If the test input is used instead of the regular input.</param>
    public void LoadInput(bool test) {
        string directory = test ? "tests" : "inputs";

        InputFile = Path.Combine( "Resources", directory, $"Day{DayNumber:D2}.txt");
        if (!File.Exists(InputFile))
            throw new FileNotFoundException($"Missing {(test ? "test" : "input")} file for Day {DayNumber}.", InputFile);
    }

    /// <summary>
    /// Abstract method for the most steps of parsing which may be common between parts one and two.
    /// </summary>
    /// <returns>The parsed input as any data structure to the puzzle.</returns>
    public abstract TInput ParseInput();

    /// <summary>
    /// Abstract method for solving part one of the day.
    /// </summary>
    /// <param name="input">The parsed input of the day.</param>
    /// <returns>The result of part one.</returns>
    public abstract object PartOne(TInput input);

    /// <summary>
    /// Abstract method for solving part two of the day.
    /// </summary>
    /// <param name="input">The parsed input of the day.</param>
    /// <returns>The result of part 2.</returns>
    public abstract object PartTwo(TInput input);

    // Automatically pass the result of parsing the input into the part methods.
    object IDay.PartOne() => PartOne(ParseInput());
    object IDay.PartTwo() => PartTwo(ParseInput());
}
