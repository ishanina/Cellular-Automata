using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automata
{
    public class State
    {
        public int Start = 0;
        public int Value = 0;
        public int[] Criteria;
        public bool Custom_Adjacent = false;
        public bool[] Custom_Adjacents;
        public int[] Treat;
        public State(int No_of_States = 2)
        {
            Criteria = new int[No_of_States];
            Treat = new int[No_of_States];
            for (int i = 0; i < No_of_States; i++ )
                Treat[i] = i;
        }
        public bool Check_State(int[] Adjacent, bool[] Adjacents, int Current_State)
        {
            int[] Check;
            Check = new int[Criteria.Length];
            for (int i = 0; i < 8; i++)
            {
                if ((Adjacents[i] && !Custom_Adjacent) || (Custom_Adjacent && Custom_Adjacents[i]))
                    Check[Treat[Adjacent[i]]]++;
            }
            if (Custom_Adjacent)
            {
                foreach (bool i in Custom_Adjacents)
                    Console.WriteLine(i);
                Console.WriteLine(Check[Check.Length - 1]);
                Console.WriteLine(Criteria[Check.Length - 1]);
            }
            return Enumerable.SequenceEqual(Check, Criteria) && Current_State == Start;
        }
    }
}
