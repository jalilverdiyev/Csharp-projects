using System;
using System.Threading;

namespace Tictactoe
{
    class Game
    {

        struct Player
        {
            public string sign;
            public bool is_won;

            public Player(string sign, bool is_won)
            {
                this.sign = sign;
                this.is_won = is_won;
            }
        }

        static Player checkPlayers(string[] moves)
        {
            //horizontal
            for(int i=0;i<moves.Length;i+=3)
            {
                if(moves[i] == moves[i+1] && moves[i] == moves[i+2])
                {
                    Player player = new Player(moves[i],true);                            
                    return player;
                }
            }
            //vertical 
            for (int i = 0; i < 3; i++)
            {
                if(moves[i] == moves[i+3] && moves[i] == moves[i+6])
                {
                    Player player = new Player(moves[i],true);                            
                    return player;
                }
            }
            //diagonal
            if(moves[0] == moves[4] && moves[0] == moves[8])
            {
                Player player = new Player(moves[0],true);                            
                return player;
            }
            if(moves[2] == moves[4] && moves[2] == moves[6])
            {
                Player player = new Player(moves[2],true);                            
                return player;
            }
            Player loser = new Player("",false);                            
            return loser;
        }

        static bool IsDraw(bool[] moves)
        {
            int full = 0;
            foreach (bool move in moves)
            {
                if(move == false)
                {
                    full++;
                }
            }
            return full == moves.Length ? true : false;
        }

        static void DrawTable(string[] table)
        {
            Console.Clear();
            Console.WriteLine("+---+---+---+");
            for(int i = 0; i < 9; i+=3)
            {
                Console.WriteLine("| "+table[i]+" | "+table[i+1]+" | "+table[i+2]+" |");
                Console.WriteLine("+---+---+---+");
            }
        }

        static void Main(string[] args)
        {
            bool[] table = {true,true,true,true,true,true,true,true,true};
            string[] moves = {"1","2","3","4","5","6","7","8","9"};
            int state = 0;
            bool won = false;
            int move;
            while (!won)
            {
                DrawTable(moves);
                switch (state)
                {
                    case 0:
                        Console.WriteLine("It is X's turn. Choose your move: ");
                        move = Convert.ToInt32(Console.ReadLine());
                        if(table[move-1])
                        {
                            moves[move-1] = "X";
                            table[move-1] = false;
                            state = 1;
                        }
                        else
                        {
                            Console.WriteLine("You can't move like that!");
                            Thread.Sleep(2000);
                        }
                        break;
                    case 1:
                        Console.WriteLine("It is O's turn. Choose your move: ");
                        move = Convert.ToInt32(Console.ReadLine());
                        if (table[move-1])
                        {
                            moves[move-1] = "O";
                            table[move-1] = false;
                            state = 0;
                        }
                        else
                        {
                            Console.WriteLine("You can't move like that!");
                            Thread.Sleep(2000);
                        }
                        break;
                    default:
                        Console.WriteLine("Unexpected Error");
                        break;
                }
                if(IsDraw(table))
                {
                    DrawTable(moves);
                    Console.WriteLine("The game is on draw. No one wins -_-");
                    break;
                }
                Player plyr = checkPlayers(moves);
                if(plyr.is_won)
                {
                    won = true;
                    DrawTable(moves);
                    Console.WriteLine(plyr.sign + " is won!");
                }
            }


        }
   }
}


