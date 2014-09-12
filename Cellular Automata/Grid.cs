using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cellular_Automata
{
    public class Grid
    {
        public int Width;
        public int Length;
        public int[,] Value;
        public Rule_Set Rules;
        int[,] Old_Value;

        public Grid(int Length, int Width)
        {
            Value = new int[Length,Width];
            this.Width = Width;
            this.Length = Length;
        }

        public Grid(int Length, int Width, Grid Old)
        {
            Value = new int[Length, Width];
            this.Width = Width;
            this.Length = Length;
            Rules = Old.Rules;
            int Length_Limit;
            int Width_Limit;
            if (Length >= Old.Length)
                Length_Limit = Old.Length;
            else
                Length_Limit = Length;
            if (Width >= Old.Width)
                Width_Limit = Old.Width;
            else
                Width_Limit = Width;
            for (int i = 0; i < Length_Limit; i++)
                for (int j = 0; j < Width_Limit; j++)
                    this.Value[i, j] = Old.Value[i, j];
        }
        public void Run() 
        {
            this.Old_Value = new int[this.Length,this.Width];
            Array.Copy(Value, Old_Value, Value.Length);
            int[] Adjacent;
            for (int i = 0; i < this.Length; i++)
                for (int j = 0; j < this.Width; j++)
                {
                    Adjacent = Create_Adjacent(i, j);
                    this.Value[i, j] = Rules.Apply_Rules(Adjacent, this.Value[i, j]);
                }
        }

        public int[] Create_Adjacent(int i, int j)
        {
            int[] Adjacent;
            Adjacent = new int[8];
            int inci = i + 1;
            int incj = j + 1;
            int deci = i - 1;
            int decj = j - 1;

            if (inci == this.Length)
                inci = 0;
            if (deci == -1)
                deci = this.Length - 1;
            if (incj == this.Width)
                incj = 0;
            if (decj == -1)
                decj = this.Width - 1;

            Adjacent[0] = this.Old_Value[i, decj];
            Adjacent[1] = this.Old_Value[inci, decj];
            Adjacent[2] = this.Old_Value[inci, j];
            Adjacent[3] = this.Old_Value[inci, incj];
            Adjacent[4] = this.Old_Value[i, incj];
            Adjacent[5] = this.Old_Value[deci, incj];
            Adjacent[6] = this.Old_Value[deci, j];
            Adjacent[7] = this.Old_Value[deci, decj];
            return Adjacent;
        }

        internal void Shift(int Shift_X, int Shift_Y)
        {
            int[] X_New;
            int[] Y_New;
            X_New = new int[this.Value.GetLength(0)];
            Y_New = new int[this.Value.GetLength(1)];
            this.Old_Value = new int[this.Length, this.Width];
            Array.Copy(Value, Old_Value, Value.Length);
            for (int i = 0; i < X_New.Length; i++)
            {
                X_New[i] = i - Shift_X;
                if (X_New[i] >= X_New.Length)
                    X_New[i] -= X_New.Length;
                if (X_New[i] < 0)
                    X_New[i] += X_New.Length;
            }
            for (int i = 0; i < Y_New.Length; i++)
            {
                Y_New[i] = i - Shift_Y;
                if (Y_New[i] >= Y_New.Length)
                    Y_New[i] -= Y_New.Length;
                if (Y_New[i] < 0)
                    Y_New[i] += Y_New.Length;
            }
            for (int i = 0; i < this.Length; i++)
                for (int j = 0; j < this.Width; j++)
                {
                    this.Value[i, j] = this.Old_Value[X_New[i], Y_New[j]];
                }
        }
    }
}
