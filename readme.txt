READ ME
You run the game by opening the executable in the folder.
We have provided the source code in case something goes wrong, and if that does not work there is also the project folder which requires visual studio 2022 to run.
Have fun!

In this mathematical board game duel between Alice and Bob, their goal is to navigate through a grid of numbered cells while strategically solving math operations. As former classmates turned rivals, their duel arises from a fierce competition to prove who has the superior mathematical prowess, with each player aiming to outsmart the other through clever moves and quick mental calculations.

Both players take turns inputting in the console, starting with player one. The starting position for player one is the top left corner (cor. 0,0) and for player two is the bottom right corner (cor. N,M). The available moves are Up, Down, Right, Left, Diagonal up left, Diagonal up right, Diagonal down left, and Diagonal down right. 
Only numbers between 4 to 15 (included) are allowed in the console as the board’s height and width. Each of the player’s points are displayed in the console at all times, right below the board.

The objective is simple: whichever player accumulates the greater total number until the cells are depleted wins with a congratulating message “Player 1 (or 2) wins!”. If a player accidentally makes a move that puts them outside of the board, the message "That move is not allowed" gets printed in the console and they are reverted back to the last playable square. Every cell that has been collected by either of the players is rendered unplayable with the symbol "!" and the colour red. We wish you a legendary duel!