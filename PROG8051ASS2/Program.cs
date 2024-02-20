using System;

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
    public Cell[,] Grid; // 2D array representing the grid of cells

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
    } 
}

        


class Program
{
    public static void Main()
    {
        
    }
}
