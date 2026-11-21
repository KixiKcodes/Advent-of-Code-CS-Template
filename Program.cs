namespace AdventOfCode2026;

class Program {
    public static int Main(string[] args) {
        const int MaximumDays = 12; // Halfed as of 2025.

        if (args.Length < 2 || args.Length > 3 || (args.Length == 3 && args[2] != "test")) {
            Console.WriteLine("Invalid input."); // Usage: dotnet run -- <day> <part> [optional "test" to solve using the test input]
            return 1;
        }
        if (!int.TryParse(args[0], out int day) || !int.TryParse(args[1], out int part) || day < 0 || day > MaximumDays || part < 1 || part > 2) {
            Console.WriteLine("Invalid day or part.");
            return 1;
        }

        bool test = args.Length == 3 && args[2] == "test";
        Day? selectedDay = day switch {
            0 => new Day00(), // TEST DAY
            // Add days...
            _ => null
        };

        if (selectedDay is null) {
            Console.WriteLine($"Day {day} has not been implemented.");
            return 1;
        }
        try {
            selectedDay.LoadInput(test);
            if (part == 1)
                selectedDay.PartOne();
            else
                selectedDay.PartTwo();
        } catch (FileNotFoundException e) {
            Console.WriteLine(e.Message);
            return 1;
        }

        return 0;
    }
}
