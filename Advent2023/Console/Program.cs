await Solver.SolveAll(options =>
{
    options.ProblemAssemblies = [typeof(Day01).Assembly];
});
