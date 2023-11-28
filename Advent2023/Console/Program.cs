await Solver.SolveAll(options =>
{
    options.ProblemAssemblies = [typeof(Advent2023.Library.Days.Day01).Assembly];
});
