using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace math_tricks
{
    class Player
    {
        public int playerNumber;
        public int currentPositionX;
        public int currentPositionY;
        public double playerValue = 0;

    }


    internal class Program
    {
        static void Move(Player player,int n, int m, int[,] board, char[,]boardOperations, bool endGame, int playerNumberA)
        {
            if (player.playerNumber == 1)
            {
                Console.WriteLine("It is Player 1's turn to play...");
            }
            else
                Console.WriteLine("It is Player 2's turn to play...");
            bool ValidMoveCondition = true;
            while (ValidMoveCondition)
                {
                Console.WriteLine("Make your move. Your options are: Up, Down, Left, Right,\n " +
                    "Diagonal right up, Diagonal left down, Diagonal right down, Diagonal left up. " +
                    "\n Please make sure you don't miss the capital letters!");
                string moveDirection = Console.ReadLine();
                ValidMoveCondition = true;
                  switch (moveDirection)
                      {
                          case "Left":
                              player.currentPositionY--;
                          if (!checkMoveValidity(player, n, m,boardOperations)) 
                              {
                                  Console.WriteLine("That move is not allowed");
                                  player.currentPositionY++;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Right":
                              player.currentPositionY++;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                 player.currentPositionY--;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Up":
                              player.currentPositionX--;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                 player.currentPositionX++;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Down":
                              player.currentPositionX++;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                player.currentPositionX--;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Diagonal right up":
                              player.currentPositionX--;
                              player.currentPositionY++;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                  player.currentPositionX++;
                                  player.currentPositionY--;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Diagonal right down":
                              player.currentPositionX++;
                              player.currentPositionY++;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                  player.currentPositionX--;
                                  player.currentPositionY--;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Diagonal left up":
                              player.currentPositionX--;
                              player.currentPositionY--;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                  player.currentPositionX++;
                                  player.currentPositionY++;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          case "Diagonal left down":
                              player.currentPositionX++;
                              player.currentPositionY--;
                              if (!checkMoveValidity(player, n, m, boardOperations))
                              {
                                  Console.WriteLine("That move is not allowed");
                                 player.currentPositionX--;
                                 player.currentPositionY++;
                                  break;
                              }
                              else
                              {

                                  ValidMoveCondition = false;
                                  break;
                              }
                          default:
                              Console.WriteLine("Incorrect input. Please make sure you used capital letters");
                              break;

                      }
              
            }

            switch (boardOperations[player.currentPositionX,player.currentPositionY])
            {
                case '+':
                    player.playerValue += board[player.currentPositionX, player.currentPositionY];
                    break;
                case '-':
                    player.playerValue -= board[player.currentPositionX, player.currentPositionY];
                    break;
                case 'x':
                    player.playerValue= player.playerValue* board[player.currentPositionX, player.currentPositionY];
                    break;
                case '/':
                    if (board[player.currentPositionX, player.currentPositionY] == 0)
                    {
                        break;
                    }
                    else
                    {
                        player.playerValue /= board[player.currentPositionX, player.currentPositionY];
                        break;
                    }
                default:
                    break;
            }

           
            board[player.currentPositionX, player.currentPositionY] = 0;
            boardOperations[player.currentPositionX, player.currentPositionY] = '!';

            PrintBoard(board, boardOperations, n, m, playerNumberA);

        }

        static bool WinCheck(char[,] boardOperations, int n, int m, Player player)
        {
            player.currentPositionX++;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionX--;
                return false;
            }
            player.currentPositionX--;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionX++;
                return false;
            }
            player.currentPositionY++;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionY--;
                return false;
            }
            player.currentPositionY--;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionY++;
                return false;
            }

            player.currentPositionY--;
            player.currentPositionX++;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionY++;
                player.currentPositionX--;
                return false;
            }

            player.currentPositionY++;
            player.currentPositionX++;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionY--;
                player.currentPositionX--;
                return false;
            }
            player.currentPositionY--;
            player.currentPositionX--;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionY++;
                player.currentPositionX++;
                return false;
            }
            player.currentPositionY++;
            player.currentPositionX--;
            if (checkMoveValidity(player, n, m, boardOperations))
            {
                player.currentPositionY--;
                player.currentPositionX++;
                return false;
            }

            return true;
        }
        public static bool checkMoveValidity(Player player,int n,int m, char[,] boardOperations)
        {
            if ((player.currentPositionX >= n) || (player.currentPositionX < 0))
            {
                return false;
            }
            else if ((player.currentPositionY >= m) || (player.currentPositionY < 0))
            {
                return false;
            }
            else if (boardOperations[player.currentPositionX, player.currentPositionY] == '!') 
            {
                return false;
            }
            else if ((player.currentPositionY == m-1) && (player.currentPositionX == n-1))
            {
                return false;
            }
            else if ((player.currentPositionX==0)&&(player.currentPositionY==0))
            {
                return false;
            }
            else 
            { 
                return true;
            }
        }

        static void PrintBoard(int[,] board,char[,] boardOperation, int n, int m,int playerNumberA)
        {
            Console.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                     if (boardOperation[i, j]=='!')
                     {
                         Console.ForegroundColor = ConsoleColor.Red;
                     }
                    Console.Write(boardOperation[i,j]);
                    Console.Write(board[i, j] + "  ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }

        }

        static int inputBoardSize()
        {
            while (true)
            {
                int num;
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if ((num >= 4) && (num <= 15)) 
                    {
                        return num;
                    }
                    else
                        Console.WriteLine("You can only use numbers between 4 and 15. Please try again.");
                }
                else
                { Console.WriteLine("You can only use numbers between 4 and 15. Please try again."); }
            }
        }

        static void WinNumber(Player player1, Player player2)
        {
            if (player1.playerValue>player2.playerValue)
            {
                Console.WriteLine("Player 1 Wins! Congratulations!");
            }
            else if (player2.playerValue>player1.playerValue)
            {
                Console.WriteLine("Player 2 Wins! What a game!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        static void Main(string[] args)
        {
            int n, m;
            Console.WriteLine("Welcome to Math Tricks!");
            Console.WriteLine("Here two players control their target and each move does a different mathematical equation \n" +
                " with their points depending on the tile that the player landed on.");
            Console.WriteLine( "The game ends when one of the players can no longer move. And the one with more points wins!");
            Console.WriteLine("Remember that you cannot step on the red tiles and on your original tiles. Have fun!");

            Console.Write("Please write down the height of the board that you want: ");
            n = inputBoardSize();
            Console.Write("Please write down the width of the board that you want:  ");
            m = inputBoardSize();

            int[,] board = new int[n, m];

            char[,] boardOperation = new char[n, m];

            Random r = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    switch (r.Next(1, 4))
                    {
                        case 1:
                            //+
                            board[i, j] = r.Next(1, 10);
                            boardOperation[i, j] = '+';
                            break;
                        case 2:
                            //-
                            board[i, j] = r.Next(1, 10);
                            boardOperation[i, j] = '-';
                            break;
                        case 3:
                            //*
                            board[i, j] = r.Next(1, 10);
                            boardOperation[i, j] = 'x';
                            break;
                        case 4:
                            // /
                            board[i, j] = r.Next(1, 10);
                            boardOperation[i, j] = '/';
                            break;
                        default:
                            Console.WriteLine("The operation couldn't be calculated.");
                            break;
                    }
                }
                Console.WriteLine();
            }

            board[0, 0] = (char)0;
            board[n-1, m-1] = (char)0;
            boardOperation[0, 0] = ' ';
            boardOperation[n-1, m-1] = ' ';


            Player player1 = new Player();
            player1.playerNumber = 1;
            Player player2 = new Player();
            player2.playerNumber = 2;

            //start game

            player1.currentPositionX = 0;
            player1.currentPositionY = 0;

            player2.currentPositionX = n-1;
            player2.currentPositionY = m-1;

            PrintBoard(board, boardOperation, n, m, 0);
            bool endGame = false;

            while (!endGame)
            {
                if (WinCheck(boardOperation, n, m, player1))
                {
                    WinNumber(player1, player2);
                    endGame = true;
                }
                if (endGame)
                    break;

                Move(player1, n, m, board, boardOperation, endGame,1);
                Console.WriteLine("Player 1's points are " + player1.playerValue);
                 Console.WriteLine("Player 2's points are " +player2.playerValue);



                if (WinCheck(boardOperation, n, m, player1))
                {
                    WinNumber(player1,player2);
                    endGame = true;
                }
                if (endGame)
                    break;

                Move(player2, n, m, board, boardOperation, endGame,2);
                Console.WriteLine("Player 1's points are " + player1.playerValue);
                 Console.WriteLine("Player 2's points are " + player2.playerValue);
            }
        }
    }
}
