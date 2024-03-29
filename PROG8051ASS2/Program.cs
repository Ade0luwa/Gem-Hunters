﻿using System;

class Position
{
    //X and Y coordinates
    public int X;
    public int Y;

    // Constructor that is used to initialize the position with given coordinates
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Represents a cell on the game board
class Cell
{
    public string Occupant; // An occupant of the cell which could be "P1", "P2", "G", "O", or "-" for empty

    public Cell(string occupant) // Constructor to initialize the cell with an occupant
    {
        Occupant = occupant;
    }
}

// Represents a player (P1 or P2) in the game
class Player
{
    public string Name; // Player's name
    public Position Position; // Player's current position
    public int GemCount; // Number of gems collected by the player
    public int Turns; // Number of turns taken by the player

   
    public Player(string name, Position position) // Constructor to initialize player with name and position
    {
        Name = name;
        Position = position;
        GemCount = 0;
        Turns = 0;
    }

    // method that updates the player's position based on the input direction 
    public void Move(char direction)
    {
        Turns++; // Increment the number of turns taken

        switch (direction)
        {
            case 'U': // Move up
                if (Position.Y > 0) Position.Y--;//if the player is not at the extreme top of the board, Y coordinate of the player's position is decremented by 1 and the player is moved one position to the top on the board.
                break;

            case 'D': // Move down
                if (Position.Y < 5) Position.Y++;//if the player is not at the extreme bottom of the board, Y coordinate of the player's position is incremented by 1 and the player is moved one position to the bottom on the board.
                break;

            case 'L': // Move left
                if (Position.X > 0) Position.X--;//if the player is not at the extreme left of the board, X coordinate of the player's position is decremented by 1 and the player is moved one position to the left on the board.
                break;

            case 'R': // Move right
                if (Position.X < 5) Position.X++;//if the player is not at the extreme right of the board, X coordinate of the player's position is incremented by 1 and the player is moved one position to the right on the board.
                break;
        }
    }
}

// Represents the game board
class Board
{
    public Cell[,] Grid; // 2D array representation of the grid of cells

    public Board()
    {
        Grid = new Cell[6, 6];
        InitializeBoard(); // Initializing the cells of the board
    }

    // Initializes the cells of the board with players, gems, obstacles, and empty spaces
    private void InitializeBoard()
    {
        // putting "-" in empty spaces in the cells
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Grid[i, j] = new Cell("-");
            }
        }

        // Place players at opposite ends of each other
        Grid[0, 0].Occupant = "P1"; // Player 1
        Grid[5, 5].Occupant = "P2"; // Player 2


        // Placing gems in random positions
        Random random = new Random();
        for (int i = 0; i < 8; i++)
        {
            int gemX = random.Next(6);
            int gemY = random.Next(6);
            Grid[gemX, gemY].Occupant = "G";
        }

        // Place obstacles in random positions
        for (int i = 0; i < 8; i++)
        {
            int obstacleX = random.Next(6);
            int obstacleY = random.Next(6);
            // Make sure not to overwrite players or gems
            if (Grid[obstacleX, obstacleY].Occupant == "-")
            {
                Grid[obstacleX, obstacleY].Occupant = "O"; // Obstacles being placed in empty spaces only
            }
            else
            {
                i--;
            }
        }
    }

    // Displays the current state of the board
    public void Display()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write($"{Grid[i, j].Occupant} ");
            }
            Console.WriteLine();
        }
    }

    // Checks if a move is valid for the given player and direction
    public bool IsValidMove(Player player, char direction)
    {
        int newX = player.Position.X;
        int newY = player.Position.Y;

        switch (direction)
        {
            case 'U':
                newY--;
                break;

            case 'D':
                newY++;
                break;

            case 'L':
                newX--;
                break;

            case 'R':
                newX++;
                break;
        }

        // Check if the new position is within bounds and not an obstacle
        return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newY, newX].Occupant != "O";
    }

    // Updates the position of a player on the board
    public void UpdatePlayerPosition(Player player, Position previousPosition)
    {
        Grid[previousPosition.Y, previousPosition.X].Occupant = "-"; // Clear previous position
        Grid[player.Position.Y, player.Position.X].Occupant = player.Name; // Update current position
    }

    // Handles the collection of gems by a player
    public void CollectGem(Player player)
    {
        if (Grid[player.Position.Y, player.Position.X].Occupant == "G")
        {
            player.GemCount++; // Increment gem count
            Grid[player.Position.Y, player.Position.X].Occupant = "-"; // Remove gem from board
            Console.WriteLine($"\nYayyyyyy {player.Name} has found a gem!");
        }
    }
}

// Represents the game logic and controls
class Game
{
    public Board Board; // The game board
    public Player Player1; // Player 1
    public Player Player2; // Player 2
    public int TotalTurns; // Total number of turns taken

    // Constructor to initialize the game
    public Game()
    {
        Board = new Board(); // Create the game board
        Player1 = new Player("P1", new Position(0, 0)); // Create Player 1
        Player2 = new Player("P2", new Position(5, 5)); // Create Player 2
        TotalTurns = 0; // Initialize total turns
    }

    // Starts the game loop
    public void Start()
    {
        while (!IsGameOver())
        {
            // Determine current player
            Player currentPlayer = TotalTurns % 2 == 0 ? Player1 : Player2;
            Position previousPosition = new Position(currentPlayer.Position.X, currentPlayer.Position.Y);

            Console.Clear();
            Board.Display();
            Console.WriteLine($"Current turn: {currentPlayer.Name}");
            Console.WriteLine($"Gems collected: {Player1.GemCount} (P1) - {Player2.GemCount} (P2)");
            Console.WriteLine($"Number of turns: {Player1.Turns} (P1) - {Player2.Turns} (P2)");
            Console.WriteLine("Enter 'U' to move up, 'D' to come down, 'L' to move left, 'R' to move right");

            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.U || key.Key == ConsoleKey.D || key.Key == ConsoleKey.L || key.Key == ConsoleKey.R)
            {
                char direction = char.ToUpper(key.KeyChar);

                if (Board.IsValidMove(currentPlayer, direction))
                {
                    currentPlayer.Move(direction);
                    Board.CollectGem(currentPlayer);
                    Board.UpdatePlayerPosition(currentPlayer, previousPosition);
                    TotalTurns++;
                }
                else
                {
                    Console.WriteLine("\nInvalid move. Try again.");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Use U, D, L, R keys to move.");
            }

            // Pause to allow players to see the current state before proceeding
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        AnnounceWinner();
    }

    // Checks if the game is over
    public bool IsGameOver()
    {
        return TotalTurns >= 30; // Game ends after 30 turns
    }

    // Announces the winner of the game
    public void AnnounceWinner()
    {
        Console.Clear();
        Console.WriteLine("Game over!");

        Console.WriteLine($"Gems collected: {Player1.GemCount} (P1) - {Player2.GemCount} (P2)");
        Console.WriteLine($"Number of turns: {Player1.Turns} (P1) - {Player2.Turns} (P2)");

        if (Player1.GemCount > Player2.GemCount)
        {
            Console.WriteLine("Player 1 (P1) wins!");
        }
        else if (Player2.GemCount > Player1.GemCount)
        {
            Console.WriteLine("Player 2 (P2) wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}


class Program
{
    static void Main()
    {
        Game gemHunters = new Game(); // Create a new game instance
        gemHunters.Start(); // Start the game
    }
}
