namespace Advent2023.Library.Days;

public class Day05 : BaseDay
{
    private readonly string fileInput;

    public Day05() =>
        fileInput = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1()
    {
        var fileLines = fileInput.Split('\n');
        var stackLines = fileLines[..8];
        var stepLines = fileLines[10..(fileLines[^1].Trim() is { Length: 0 } ? ^1 : ^0)];

        List<List<string>> lines = [];

        for (var i = 0; i < 8; i++)
        {
            var stackLine = stackLines[i];
            List<string> cols = [];

            for (var col = 0; col < 9; col++)
            {
                cols.Add(stackLine[(col * 4)..((col + 1) * 4 - 1)]);
            }

            lines.Add(cols);
        }

        List<Stack<string>> stacks = [];

        for (var col = 0; col < 9; col++)
        {
            var column = new Stack<string>(lines.Select(x => x[col].Trim()).Where(x => !string.IsNullOrEmpty(x)).Reverse());
            stacks.Add(column);
        }

        foreach (var stepLine in stepLines)
        {
            var stepLineSplit = stepLine.Split(' ');

            var number = int.Parse(stepLineSplit[1]);
            var start = int.Parse(stepLineSplit[3]);
            var end = int.Parse(stepLineSplit[5]);

            var fromStack = stacks[start - 1];
            var toStack = stacks[end - 1];

            for (var i = 0; i < number; i++)
            {
                toStack.Push(fromStack.Pop());
            }
        }

        StringBuilder sbSolution = new();

        for (var i = 0; i < stacks.Count; i++)
        {
            var stack = stacks[i];
            sbSolution.Append(stack.Peek().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty));
        }

        return new(sbSolution.ToString());
    }
    public override ValueTask<string> Solve_2()
    {
        var fileLines = fileInput.Split('\n');
        var stackLines = fileLines[..8];
        var stepLines = fileLines[10..(fileLines[^1].Trim() is { Length: 0 } ? ^1 : ^0)];

        List<List<string>> lines = [];

        for (var i = 0; i < 8; i++)
        {
            var stackLine = stackLines[i];
            List<string> cols = [];

            for (var col = 0; col < 9; col++)
            {
                cols.Add(stackLine[(col * 4)..((col + 1) * 4 - 1)]);
            }

            lines.Add(cols);
        }

        List<Stack<string>> stacks = [];

        for (var col = 0; col < 9; col++)
        {
            var column = new Stack<string>(lines.Select(x => x[col].Trim()).Where(x => !string.IsNullOrEmpty(x)).Reverse());
            stacks.Add(column);
        }

        foreach (var stepLine in stepLines)
        {
            var stepLineSplit = stepLine.Split(' ');

            var number = int.Parse(stepLineSplit[1]);
            var start = int.Parse(stepLineSplit[3]);
            var end = int.Parse(stepLineSplit[5]);

            var fromStack = stacks[start - 1];
            var toStack = stacks[end - 1];
            var tempStack = new List<string>();

            for (var i = 0; i < number; i++)
            {
                tempStack.Add(fromStack.Pop());
            }

            tempStack.Reverse();

            for (var i = 0; i < number; i++)
            {
                toStack.Push(tempStack[i]);
            }
        }

        StringBuilder sbSolution = new();

        for (var i = 0; i < stacks.Count; i++)
        {
            var stack = stacks[i];
            sbSolution.Append(stack.Peek().Replace("[", string.Empty).Replace("]", string.Empty).Replace(" ", string.Empty));
        }

        return new(sbSolution.ToString());
    }
}
