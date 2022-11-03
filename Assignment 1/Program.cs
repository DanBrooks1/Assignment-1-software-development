using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleShip_Final
{
    class BattleshipBoard
    {


        public void DisplayBoard(char[,] Board)
        {
            int Row;
            int Column;

            Console.WriteLine("  ¦ 0 1 2 3 4 5 6 7 8 9");  // numbers 1 to 9 will be charted on the board so the player knows the exact coordinate of a ship 
            Console.WriteLine("--+--------------------"); // a simple border to seperate the numbers form the ships
            for (Row = 0; Row <= 9; Row++) 
            {
                Console.Write((Row).ToString() + " ¦ "); // puts ¦ infront of every number on the y axis to create the rest of the border 
                for (Column = 0; Column <= 9; Column++)
                {
                    Console.Write(Board[Column, Row] + " "); // any spaces that are not filled with S shall be left blank on the screen
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n"); 
        }
    }

    class Player
    {
        char[,] Grid = new char[10, 10]; // this section displays a new board when a new player begins to play the game, it does this by making a 10 x 10 board and reseting all hit points and misses
        public int HitCount = 0;
        public int MissCount = 0;
        int x = 0;
        int y = 0;

        public int getHitCount()
        {
            return HitCount; // registers all hits that hit a ship marker on the board 
        }
        public int getMissCount()
        {
            return MissCount; // registers all misses that missed a ship marker on the board 
        }
        public void AskCoordinates()
        {
            Console.WriteLine("Enter X"); // asks player to enter an X coordinate on the board between 0 - 9
            string line = Console.ReadLine();
            int value;
            if (int.TryParse(line, out value))
            {
                x = value; //if value entered by player is a number between 0 - 9 it will move onto the next question 
            }
            else
            {
                Console.WriteLine("Not a valid answer!"); // if value entered by play is more than 9 or a letter/word than "Not an integer" shall be displayed meaning that what they entered was not a vaild answer 
            }

            Console.WriteLine("Enter Y"); // asks player to enter an Y coordinate on the board between 0 - 9
            line = Console.ReadLine();
            if (int.TryParse(line, out value)) 
            {
                y = value; //if value entered by player is a number between 0 - 9 it will move onto the next question
            }
            else
            {
                Console.WriteLine("Not a vaild answer!"); // if value entered by play is more than 9 or a letter/word than "Not an integer" shall be displayed meaning that what they entered was not a vaild answer
            }

            try
            {
                if (Grid[x, y].Equals('S')) // all  ships presented on the board shall be repersented by the letter S
                {
                    Grid[x, y] = 'H';
                    Console.Clear();
                    Console.WriteLine("Hit!\r\n"); // if the player enters an correct coordinate where a ship is present than "Hit" shall be displayed on the screen
                    HitCount += 1; // once programme has relised a ship has been hit than 1 point shall be added to the hit count 
                }
                else
                {
                    Grid[x, y] = 'M';
                    Console.Clear();
                    Console.WriteLine("Miss!\r\n"); // if the player enters an incorrect coordinate where a ship is not present than "Miss" shall be displayed on the screen
                    MissCount += 1; // once programme has relised a ship has been missed than 1 point shall be added to the miss count
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Error: Please enter a valid number between 0 and 9"); // if the player enters a number higher than 9 then this text shall display at the top of the screen
            }
        }
        public char[,] GetGrid()
        {
            return Grid;
        }
        public void SetGrid(int q, int w)
        {
            Grid[q, w] = 'S'; // displays all ship coordinates onto display so that the user can see what they are shooting at by displaying them as the letter S
        }
        public void Randomize()
        {

            Random r = new Random(2); // will decide where ships are placed on the board by giving them set coordinates 
            SetGrid(1, 5);
            SetGrid(2, 0);
            SetGrid(4, 3);
            SetGrid(4, 5);
            SetGrid(6, 0);
            SetGrid(7, 0);
            SetGrid(0, 8);
            SetGrid(1, 2);
            SetGrid(2, 5);
            SetGrid(3, 8);
            SetGrid(7, 4);
            SetGrid(7, 7);
        }

    }

    class Program
    {

        static void Main(string[] args)
        {

            Console.Title = "BattleShips!";  // Displays the title of the game
            Console.WriteLine("Welcome to Battleship!\r\n\r\n"); // displays text welcoming the player to the game
            Console.WriteLine("Please enter username?"); // ask player to enter their username
            string name = System.Console.ReadLine();
            Console.WriteLine();
            BattleshipBoard b = new BattleshipBoard(); // displays new board for the player to use
            Player p = new Player(); // displays new player onto the board 
            p.Randomize();
            while (p.getHitCount() < 17)
            {
                b.DisplayBoard(p.GetGrid()); // when player name is entered, the board shall display onto screen with coordinates and the  X and Y axis
                p.AskCoordinates();
            }
            Console.WriteLine("Congratulations, " + name + "! You have defeated all 12 Battleships!\r\n"); // diplays once game has ended and all 12 battleships have been destroyed 
            Console.WriteLine("You missed: " + p.getMissCount() + " times\r\n"); // diplays how many times the player missed a shot 
            Console.WriteLine("Thankyou for playing BattleShips. Press enter to quit game."); // displays to player how to quit the game once they have finished playing 
            System.Console.ReadLine();
        }


    }
}