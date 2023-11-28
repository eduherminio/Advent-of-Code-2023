await Solver.SolveAll(options =>
{
    options.ProblemAssemblies = [typeof(Advent2023.Library.Days.LibraryDay01).Assembly];
});
