namespace AdventOfCode.Puzzles._2023;

[Puzzle(2023, 01, CodeType.Original)]
public class Day_01_Original : IPuzzle
{
	private static string[] _numbers =
	[
		"zero",
		"one",
		"two",
		"three",
		"four",
		"five",
		"six",
		"seven",
		"eight",
		"nine",
		"0",
		"1",
		"2",
		"3",
		"4",
		"5",
		"6",
		"7",
		"8",
		"9"
	];

	public (string, string) Solve(PuzzleInput input)
	{
		var part1 = 0;
		foreach (var line in input.Lines)
		{
			part1 += int.Parse("" + line.First(char.IsDigit) + line.Last(char.IsDigit));
		}


		var part2 = string.Empty;
		var sum = 0;
		foreach (var line in input.Lines)
		{
			var first = _numbers.OrderBy(x => (uint)line.IndexOf(x)).First();
			var last = _numbers.OrderBy(x => line.LastIndexOf(x)).Last();

			sum += ParseNumber(first) * 10 + ParseNumber(last);
		}

		part2 = sum.ToString();

		return (part1.ToString(), part2);
	}

	private int ParseNumber(string num)
	{
		if (char.IsDigit(num[0]))
			return num[0] - '0';

		return num switch
		{
			"one" => 1,
			"two" => 2,
			"three" => 3,
			"four" => 4,
			"five" => 5,
			"six" => 6,
			"seven" => 7,
			"eight" => 8,
			"nine" => 9
		};
	}
}
