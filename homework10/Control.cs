using System.Text;

static class Control
{
	public static void MySetColor(ConsoleColor foreground, ConsoleColor background)
	{
		Console.ForegroundColor = foreground;
		Console.BackgroundColor = background;
	}

	public static int Keyboard(ref int select, int count, bool Esc)
	{
		ConsoleKey keyboard = Console.ReadKey().Key;

		switch (keyboard)
		{
			case ConsoleKey.UpArrow:
			case ConsoleKey.LeftArrow:
			case ConsoleKey.W:
			case ConsoleKey.A:
				if (select == 0)
					select = count;
				select--;
				return 1;
			case ConsoleKey.DownArrow:
			case ConsoleKey.RightArrow:
			case ConsoleKey.S:
			case ConsoleKey.D:
				select++;
				select %= count;
				return 1;
			case ConsoleKey.Enter:
				return 0;
			case ConsoleKey.Escape:
				if (Esc)
					return -1;
				return 1;
			default:
				return 1;
		}
	}

	public static int GetSelect(string selection, string[] selections, bool Esc = false)
	{
		int select = default;
		int selectionsCount = Convert.ToInt32(selections.Length);

		int isStart = 1;
		while (isStart > 0)
		{
			Console.Clear();
			Console.WriteLine(selection);

			for (int i = 0; i < selectionsCount; i++)
			{
				char arrow = ' ';
				if (i == select)
				{
					MySetColor(ConsoleColor.Blue, ConsoleColor.Red);
					arrow = ' ';
				}

				Console.WriteLine($" {arrow} {selections[i]}");
				Console.ResetColor();
			}

			if (Esc)
				Console.WriteLine("\nPress Esc to exit...\n");
			isStart = Convert.ToInt32(Keyboard(ref select, selectionsCount, Esc));

			if (isStart == -1)
				return isStart;
		}

		return select;
	}
}