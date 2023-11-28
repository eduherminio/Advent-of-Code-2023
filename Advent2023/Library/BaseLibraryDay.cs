namespace Advent2023.Library;

public abstract class BaseLibraryDay : BaseDay
{
    protected override string ClassPrefix => "Day";

    public override string InputFilePath =>
        Path.Combine(
            Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!,
            base.InputFilePath);
}
