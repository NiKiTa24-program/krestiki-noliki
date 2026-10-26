namespace krestiki_noliki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[3, 3]
           {
              { ".", ".", "." },
              { ".", ".", "." },
              { ".", ".", "." }
           };
            DrawBoard(board);
            int isPlaying = 1;
            while (isPlaying <= 3)
            {
                Console.WriteLine("Ход крестиков (Х)");
                Console.Write("Введите номер строки (1-3): ");
                int row = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Введите номер столбца (1-3): ");
                int col = Convert.ToInt32(Console.ReadLine()) - 1;

                board[row, col] = "X";
                DrawBoard(board);

                Console.WriteLine("Ход ноликов (О)"); 
                Console.Write("Введите номер строки (1-3): ");
                row = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Введите номер столбца (1-3): ");
                col = Convert.ToInt32(Console.ReadLine()) - 1;

                board[row, col] = "O";
                DrawBoard(board);

                isPlaying++;
            }
        }

        static void DrawBoard(string[,] board)
        {
            Console.WriteLine("  1 2 3");

            for (int row = 0; row < 3; row++)
            {
                Console.Write((row + 1) + " ");

                for (int col = 0; col < 3; col++)
                {
                    Console.Write(board[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
