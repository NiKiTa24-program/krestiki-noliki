namespace krestiki_noliki
{
    internal class Program
    {
        // главный метод - запускает игру в цикле
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Крестики-нолики");
            Console.WriteLine("Игроки ходят по очереди. Х ходит первым.");
            Console.WriteLine();
            while (true)
            {
                PlayOneGame();

                Console.Write("Хотите сыграть ещё раз? (да/нет): ");
                string answer = Console.ReadLine().ToLower();

                if (answer != "да" && answer != "д" && answer != "yes" && answer != "y")
                {
                    Console.WriteLine("Спасибо за игру! До встречи!");
                    break;
                }

                Console.WriteLine();
            }
        }
        // Одна полноценная партия
        static void PlayOneGame()
        {
            Console.Clear();
            string[,] board = new string[3, 3]
            {
                { ".", ".", "." },
                { ".", ".", "." },
                { ".", ".", "." }
            };

            string currentPlayer = "X";
            bool gameOver = false;

            for (int move = 0; move < 9; move++)
            {
                DrawBoard(board);
                Console.WriteLine($"Ходит игрок {currentPlayer}");

                int row, col;

                while (true)
                {
                    row = GetValidNumber("Введите номер строки (1-3): ");
                    col = GetValidNumber("Введите номер столбца (1-3): ");

                    if (board[row, col] == ".")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Эта клетка уже занята! Выберите другую.");
                    }
                }

                board[row, col] = currentPlayer;

                if (CheckWin(board, currentPlayer))
                {
                    DrawBoard(board);
                    Console.WriteLine($"Победил игрок {currentPlayer}!");
                    gameOver = true;
                    break;
                }

                if (IsBoardFull(board))
                {
                    DrawBoard(board);
                    Console.WriteLine("Ничья!");
                    gameOver = true;
                    break;
                }

                currentPlayer = (currentPlayer == "X") ? "O" : "X";
                Console.WriteLine();
            }

            if (!gameOver)
            {
                DrawBoard(board);
                Console.WriteLine("Игра окончена.");
            }
        }
        // Проверяет, есть ли три одинаковых знака в ряд 
        static bool CheckWin(string[,] board, string player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                    return true;
            }

            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                    return true;
            }

            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
                return true;

            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
                return true;

            return false;
        }
        // Проверяет, заполнены ли все клетки
        static bool IsBoardFull(string[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ".")
                        return false;
                }
            }
            return true;
        }
        // Запрашивает у игрока число от 1 до 3 с проверкой
        static int GetValidNumber(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out int number))
                {
                    if (number >= 1 && number <= 3)
                        return number - 1;
                    else
                        Console.WriteLine("Ошибка: число должно быть от 1 до 3. Попробуйте ещё раз.");
                }
                else
                {
                    Console.WriteLine("Ошибка: нужно ввести число. Попробуйте ещё раз.");
                }
            }
        }
        // РИсует текущее состояние поля
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