﻿namespace Advent2023.Library.Days;

public class Day01 : BaseLibraryDay
{
    private readonly string fileInput;

    public Day01() =>
        fileInput = File.ReadAllText(InputFilePath);

    public override ValueTask<string> Solve_1() =>
        new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1");

    public override ValueTask<string> Solve_2() =>
        new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}