using System.Reflection;

namespace Advent2023.Library.Days;

public class LibraryDay01 : BaseLibraryDay
{
    private readonly string fileInput;

    public LibraryDay01() =>
        fileInput = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1() =>
        new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() =>
        new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}

public abstract class BaseLibraryDay : BaseDay
{
    protected override string ClassPrefix => "LibraryDay";

    public override string InputFilePath =>
        Path.Combine(
            Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!,
            base.InputFilePath);
}
