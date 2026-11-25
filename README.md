# Advent of Code C# Template by KixiK

This is my template for Advent of Code designed for C# on Linux.

There is a script called `aoc` which can handle a few different command to make your life easier.
Additionally, you can automatically set it up in your `/.local/bin` with the `setup.sh` script.

## Single Command Install

```sh
git clone https://github.com/KixiKcodes/Advent-of-Code-CS-Template.git && chmod +x ./scripts/setup.sh && exec ./scripts/setup.sh
```

## AOC Commands

- `aoc [day] [part] [optional: "test"]` will run the day and part with either the real or test input. This calls the actual Program through dotnet directly.
- `aoc new [day number]` will create the new day class in `Days` and add it to the program switch statement. It will also automatically create the input files.
- `aoc create [year number]` will use the dotnet template to generate an entirely new AOC project as you see it here. From there on you can use the pther commands to create and run days.

## Template Project Structure

```text
.
├── .gitignore                       # Ignores build output, IDE files, and real puzzle inputs
├── .template.config/
│   └── template.json                # .NET template metadata; replaces AdventOfCodeXXXX
├── AdventOfCodeXXXX.csproj          # Project settings and target framework
├── Day.cs                           # Shared day interface and input/solution base class
├── Days/
│   └── .gitkeep                     # Keeps the folder for generated DayNN.cs files
├── Program.cs                       # Validates arguments and dispatches to each day's solution
├── README.md                        # Usage instructions and the day-class example
├── Resources/
│   ├── inputs/
│   │   └── .gitkeep                 # Keeps the folder for puzzle input files
│   └── tests/                       # Test inputs; populated by `aoc new`
├── Utils.cs                         # Shared grid, position, and parsing helpers
└── scripts/
    ├── aoc                          # Runs solutions and creates days or year projects
    └── setup.sh                     # Copies `aoc` into ~/.local/bin (run from scripts/)
```

## Day Class Format

```cs
using static AdventOfCodeXXXX.Utils;

namespace AdventOfCodeXXXX.Days;

class DayXX() : Day<ParsedInputType>(XX) {
    public override ParsedInputType ParseInput() {
        // Parsing code. Use "InputPath" attribute of Day to access the input file.

        return ParsedInputType;
    }

    public override object PartOne(ParsedInputType parsedInput) {
        int result = 0;

        // Solution code

        return result;
    }

    public override object PartTwo(ParsedInputType parsedInput) {
        int result = 0;

        // Solution code

        return result;
    }
}
```

And you can always just do `dotnet run -- [day] [part]` and add your days to the `Program` class and handle the files yourself.
