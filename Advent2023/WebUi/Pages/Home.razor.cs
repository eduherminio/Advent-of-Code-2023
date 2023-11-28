using DateRange = (System.DateTime StartDate, System.DateTime EndDate);

namespace Advent2023.WebUi.Pages;

public partial class Home
{
    private const string PageTitle = "Advent of Code 2023 - by Michael Bond";

    private DateRange ValidDateRange = (new DateTime(2023, 12, 01), new DateTime(2023, 12, 25));

    private List<Solution> Solutions { get; set; } = [];

    private int NumberOfProblems { get; set; }

    private bool IncludeTodaysProblems { get; set; }

    private void GetNumberOfProblems() => NumberOfProblems = typeof(BaseLibraryDay).Assembly.GetTypes().Count(IsValidProblem);

    private void OnIncludeTodaysProblemsChanged(bool newValue)
    {
        IncludeTodaysProblems = newValue;
        GetNumberOfProblems();
        Solutions.Clear();
    }

    protected override void OnInitialized()
    {
        GetNumberOfProblems();
        base.OnInitialized();
    }

    private async Task GetSolutions()
    {
        Solutions.Clear();

        var problems = typeof(BaseLibraryDay).Assembly.GetTypes()
                .Where(IsValidProblem)
                .OrderBy(t => t.FullName);

        foreach (var problem in problems)
        {
            if (Activator.CreateInstance(problem) is not BaseProblem instance)
            {
                continue;
            }

            if (!int.TryParse(problem.Name.Replace("Day", string.Empty), out var day))
            {
                Console.WriteLine("Unable to parse day");
                day = 0;
            }

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

    private bool IsValidProblem(Type type)
    {
        if (!typeof(BaseProblem).IsAssignableFrom(type) || type.IsInterface || type.IsAbstract)
        {
            return false;
        }

        if (IncludeTodaysProblems)
        {
            return true;
        }

        var dayString = type.Name.Replace("Day", string.Empty).Replace("_", string.Empty);
        if (!int.TryParse(dayString, out var day))
        {
            return false;
        }

        var date = new DateTime(2023, 12, day);

        return DateTime.Today.Date >= date && date >= ValidDateRange.StartDate && date <= ValidDateRange.EndDate;
    }
}
