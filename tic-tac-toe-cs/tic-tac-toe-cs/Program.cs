using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tic_tac_toe
{
    internal class Program
    {
        static char[,] playField =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };



        static int turns = 0;
        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;


            do
            {

                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }

                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }
                SetField();


                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((playField[0, 0] == playerChar) && (playField[0, 1] == playerChar) && (playField[0, 2] == playerChar))
                        || ((playField[1, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[1, 2] == playerChar))
                        || ((playField[2, 0] == playerChar) && (playField[2, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 0] == playerChar) && (playField[2, 0] == playerChar))
                        || ((playField[0, 1] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 1] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 2] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 0] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 2] == playerChar))
                        || ((playField[0, 2] == playerChar) && (playField[1, 1] == playerChar) && (playField[2, 0] == playerChar))
                        )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\nPlayer 2 has won!");
                        }else
                        {
                            Console.WriteLine("\nPlayer 1 has won!");
                        }
                        Console.WriteLine("Press enter to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("Draw!");
                        Console.WriteLine("Press enter to reset the game!");
                        Console.ReadKey();
                        ResetField();
                        break;
                    }

                }

                
                do
                {
                    Console.WriteLine("\nPlayer {0}: Choose your field!", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {

                        Console.WriteLine("Please enter a number!");
                    }

                    if ((input == 1) && (playField[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playField[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playField[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playField[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playField[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playField[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playField[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playField[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playField[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input.");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);


            } while (true);


        }
        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("     |     |     ");
            turns++;
        }

        public static void ResetField()
        {
            char[,] initialPlayField =
            {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
            };

            playField = initialPlayField;
            SetField();
            turns = 0;
        }
        public static void EnterXorO(int player, int input)
        {
            char pleyerSign = ' ';

            if (player == 1)
                pleyerSign = 'X';
            else if (player == 2)
                pleyerSign = 'O';

            switch (input)
            {
                case 1:
                    playField[0, 0] = pleyerSign; break;
                case 2:
                    playField[0, 1] = pleyerSign; break;
                case 3:
                    playField[0, 2] = pleyerSign; break;
                case 4:
                    playField[1, 0] = pleyerSign; break;
                case 5:
                    playField[1, 1] = pleyerSign; break;
                case 6:
                    playField[1, 2] = pleyerSign; break;
                case 7:
                    playField[2, 0] = pleyerSign; break;
                case 8:
                    playField[2, 1] = pleyerSign; break;
                case 9:
                    playField[2, 2] = pleyerSign; break;
            }

        }
    }
}
