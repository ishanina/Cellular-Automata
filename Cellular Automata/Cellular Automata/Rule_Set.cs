using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automata
{
    public class Rule_Set
    {
        public State[] Rules;
        public bool[] Adjacents;
        public int No_States;
        public Rule_Set(int Number_of_States = 2)
        {
            Rules = new State[1];
            No_States = Number_of_States;
            Rules[0] = new State(No_States);
            Adjacents = new bool[8];
            for (int i = 0; i < 8; i++)
                Adjacents[i] = true;
        }

        public void Add_Rule()
        {
            State[] Old_Rules = Rules;
            this.Rules = new State[Rules.Length + 1];
            Rules[Old_Rules.Length] = new State(No_States);
            Array.Copy(Old_Rules,Rules,Old_Rules.Length);
        }

        public void Fill_Zeros(int Rule_Number)
        {
            int Total_Adjacents = 0;
            int Total_Used = 0;
            for (int i = 0; i < 8; i++)
                if ((Adjacents[i] && !Rules[Rule_Number].Custom_Adjacent) || (Rules[Rule_Number].Custom_Adjacent && Rules[Rule_Number].Custom_Adjacents[i]))
                    Total_Adjacents++;
            for (int i = 1; i < No_States; i++)
                Total_Used += Rules[Rule_Number].Criteria[i];
            Rules[Rule_Number].Criteria[0] = Total_Adjacents - Total_Used;
        }

        public int Apply_Rules(int[] Adjacent, int Current_State)
        {
            foreach (State Instance in Rules)
            {
                if (Instance.Check_State(Adjacent, Adjacents, Instance.Treat[Current_State]))
                    return Instance.Value;
            }
            return 0;
        }
    }
}
