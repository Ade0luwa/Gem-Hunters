# PROG8051ASS2

Name of application: Gem Hunters

Programming Language used: C#

The application is a console-based 2D game called "Gem Hunters" where players compete to collect the most gems within a set number of turns

The game is conducted on a 6x6 square board.

Game Elements:

Players: Player 1 starts in the top-left corner and Player 2 starts in the bottom-right corner.

Gems: Randomly placed on the board at the start of the game.

Obstacles: Random positions on the board (represented by an "O") that players cannot pass through.

Rules:

Movement:
Players input their movement through the console: U for up, D for down, L for left, R for right.

Players can move up, down, left, or right by one square on their turn.

Players cannot move onto or through squares with obstacles.

Collecting Gems:

If a player moves onto a square containing a gem, they collect that gem.

The gem is then removed from the board (the square becomes an empty space).

 Turns:

Players alternate turns.

Each player gets 15 turns. The game ends after 30 moves (15 turns for each player).

Winning:
The player with the most gems collected after all turns are exhausted wins.

If both players have the same number of gems, it's a tie.

SETUP INSTRUCTIONS

1. Navigate this repository on GitHub

2. Clone the repository

3. Run the application on your IDE

Sample demo

P1 - - - - -

O - - G - G

G - G O - O

O - G O O -
    
O - G G O -

G O - O - P2
          
Current turn: P1

Gems collected: 0 (P1) - 0 (P2)

Number of turns: 0 (P1) - 0 (P2)

Enter 'U' to move up, 'D' to come down, 'L' to move left, 'R' to move right

sample output when the game ends

Game over!

Gems collected: 3 (P1) - 4 (P2)

Number of turns: 15 (P1) - 15 (P2)

Player 2 (P2) wins!

Link to recorded demo: https://drive.google.com/file/d/10a75Ia5pMKzaBhUueX1OiMjAsxwuByOX/view?usp=drive_link
