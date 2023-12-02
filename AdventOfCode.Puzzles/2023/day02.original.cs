namespace AdventOfCode.Puzzles._2023;

[Puzzle(2023, 02, CodeType.Original)]
public class Day_02_Original : IPuzzle
{
	public (string, string) Solve(PuzzleInput input)
	{
		var games = new List<Game>();
		var maxes = new Dictionary<string, int>() { ["red"] = 12, ["green"] = 13, ["blue"] = 14 };
		foreach (var line in input.Lines)
		{
			var split = line.Split(':');
			var game = new Game(int.Parse(split[0].Split(' ')[1]), new() { { "red", 0 }, { "green", 0 }, { "blue", 0 } });
			var pulls = split[1].Split(';');
			foreach (var pull in pulls)
			{
				var split3 = pull.Split(',', StringSplitOptions.RemoveEmptyEntries);
				foreach (var s in split3)
				{
					var split2 = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
					var num = int.Parse(split2[0]);
					game.CubeMaxes[split2[1]] = Math.Max(game.CubeMaxes[split2[1]], num);
				}
			}
			games.Add(game);
		}

		var sum = games.Where(x => x.CubeMaxes.All(y => y.Value <= maxes[y.Key])).Sum(x => x.Id);
		var power = games.Select(x => x.CubeMaxes["red"] * x.CubeMaxes["green"] * x.CubeMaxes["blue"]).Sum();

		return (sum.ToString(), power.ToString());
	}

	private record Game(int Id, Dictionary<string, int> CubeMaxes);
}
