namespace Advent2023.WebUi.Pages;

public partial class Home
{
    private List<Solution> Solutions { get; set; } = [];

    private async Task GetSolutions()
    {
        Solutions.Clear();

        var problems = typeof(Library.Days.LibraryDay01).Assembly.GetTypes()
                .Where(type => typeof(BaseProblem).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                .OrderBy(t => t.FullName);


        foreach (var problem in problems)
        {
            if (Activator.CreateInstance(problem) is not BaseProblem instance)
            {
                continue;
            }

            var dayString = problem.Name.Replace("Day", string.Empty);
            int.TryParse(dayString, out var day);

            var solution1 = await instance.Solve_1();
            var solution2 = await instance.Solve_2();

            Solutions.Add(new Solution
            {
                Day = day,
                Part1 = solution1,
                Part2 = solution2
            });
        }
    }
}
