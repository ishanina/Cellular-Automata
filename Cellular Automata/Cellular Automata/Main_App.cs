using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cellular_Automata
{
    public partial class Main_App : Form
    {
        public Rule_Set Rules = new Rule_Set();
        public Grid G;
        public int Shift = 96;
        public int Cell_Pixels = 32;
        public bool Playing = false;
        public double Run_Speed = 3.0;
        public long Generation = 1;
        public int Key_Pressed = -1;
        public MouseEventArgs Mouse;
        public string Last_Applied_Ruleset = "";
        public Main_App(string[] args)
        {
            InitializeComponent();
            Initialize_Grid(0);
            Initialize_File(args);

       }

        private void Initialize_File(string[] args)
        {
            try
            {
                if (!args[0].EndsWith(".cas"))
                {
                    Rules_Path.Text = args[0];
                    System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini", Rules_Path.Text);
                    Apply_Rule();
                }
                else
                {
                    string[] all_lines;
                    all_lines = System.IO.File.ReadAllLines(args[0]);
                    if (all_lines[all_lines.Length - 1] != "")
                    {
                        Rules_Path.Text = all_lines[all_lines.Length - 1];
                        Apply_Rule();
                    }
                    else if (System.IO.File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini"))
                        Rules_Path.Text = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini");
                    G = new Grid(Convert.ToInt32(all_lines[all_lines.Length - 3]), Convert.ToInt32(all_lines[all_lines.Length - 2]), G);
                    for (int i = 0; i < G.Length; i++)
                        for (int j = 0; j < G.Width; j++)
                        {
                            if (G.Rules.No_States > Convert.ToInt32(all_lines[i * G.Width + j]))
                                G.Value[i, j] = Convert.ToInt32(all_lines[i * G.Width + j]);
                            else
                                G.Value[i, j] = G.Rules.No_States - 1;
                        }
                    Generation = Convert.ToInt32(all_lines[all_lines.Length - 4]);
                    Speed.Text = all_lines[all_lines.Length - 5];
                    Cell_Size.Text = all_lines[all_lines.Length - 6].Substring(all_lines[all_lines.Length - 6].LastIndexOf(' ') + 1);
                    this.Size = new Size(Convert.ToInt32(all_lines[all_lines.Length - 8]), Convert.ToInt32(all_lines[all_lines.Length - 7]));
                    Draw_Grid(100);
                    Display_Info();
                }
            }
            catch (IndexOutOfRangeException)
            {
                if (System.IO.File.Exists(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini"))
                    Rules_Path.Text = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini");
            }
        }

        private void Initialize_Grid(int Apply_Ruleset = -1)
        {
            G = new Grid((this.Size.Width - Shift) / Cell_Pixels - 1, this.Size.Height / Cell_Pixels - 1);
            if (Apply_Ruleset == 0)
                Conway();
            G.Rules = Rules;
            Draw_Grid(1);
        }

        private void Conway()
        {
            // If 3 Adjacents are 1, a 0 will turn 1
            Rules.Rules[0].Start = 0;
            Rules.Rules[0].Criteria[0] = 5;
            Rules.Rules[0].Criteria[1] = 3;
            Rules.Rules[0].Value = 1;
            Rules.Add_Rule();
            // If 3 Adjacents are 1, a 1 will stay a 1
            Rules.Rules[1].Start = 1;
            Rules.Rules[1].Criteria[0] = 5;
            Rules.Rules[1].Criteria[1] = 3;
            Rules.Rules[1].Value = 1;
            Rules.Add_Rule();
            // If 2 Adjacents are 1, a 1 will stay a 1
            Rules.Rules[2].Start = 1;
            Rules.Rules[2].Criteria[0] = 6;
            Rules.Rules[2].Criteria[1] = 2;
            Rules.Rules[2].Value = 1;
        }
       
        private void Run_Button_Click(object sender, EventArgs e)
        {
            Frame();
        }

        private void Frame()
        {
            G.Run();
            Generation++;
            Draw_Grid();
        }

        async Task Draw_Grid(int Time_Miliseconds)
        {
            await Task.Delay(Time_Miliseconds);
            Draw_Grid();
        }
        public void Draw_Point(int x, int y)
        {
            System.Drawing.Color Col = GetColor(G.Value[x, y]);
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Col);
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            formGraphics.FillRectangle(myBrush, new Rectangle(x * Cell_Pixels + Shift, y * Cell_Pixels, Cell_Pixels, Cell_Pixels));
            myBrush.Dispose();
            formGraphics.Dispose();
        }
        public void Draw_Grid()
        {
            for (int j = 0; j < G.Length; j++)
                for (int k = 0; k < G.Width; k++)
                {
                    System.Drawing.Color Col = GetColor(G.Value[j,k]);
                    System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(Col);
                    System.Drawing.Graphics formGraphics = this.CreateGraphics();
                    formGraphics.FillRectangle(myBrush, new Rectangle(j * Cell_Pixels + Shift, k * Cell_Pixels, Cell_Pixels, Cell_Pixels));
                    myBrush.Dispose();
                    formGraphics.Dispose();
                }
            Display_Info();
        }

        public Color GetColor(int Value)
        {
            Color Col = new Color();
            switch (Value)
            {
                case 1:
                    Col = Color.Red;
                    break;
                case 2:
                    Col = Color.Orange;
                    break;
                case 3:
                    Col = Color.Yellow;
                    break;
                case 4:
                    Col = Color.Green;
                    break;
                case 5:
                    Col = Color.Blue;
                    break;
                case 6:
                    Col = Color.Purple;
                    break;
                case 7:
                    Col = Color.Black;
                    break;
                case 8:
                    Col = Color.Brown;
                    break;
                case 9:
                    Col = Color.Gray;
                    break;
                case 10:
                    Col = Color.Pink;
                    break;
                case 11:
                    Col = Color.LightGreen;
                    break;
                case 12:
                    Col = Color.Maroon;
                    break;
                default:
                    Col = Color.White;
                    break;
            }
            return Col;
        }

        private async Task Change_Point(MouseEventArgs e)
        {
            var Mouse_Point = this.PointToClient(Cursor.Position);
            int X_Val = (Mouse_Point.X - Shift) / Cell_Pixels;
            int Y_Val = Mouse_Point.Y / Cell_Pixels;
            if (X_Val < G.Length && Y_Val < G.Width && Mouse_Point.X > Shift && Mouse_Point.Y > 0 && MouseButtons.Left == e.Button)
            {
                G.Value[X_Val, Y_Val]++;
                if (G.Value[X_Val, Y_Val] >= G.Rules.Rules[0].Criteria.Length)
                    G.Value[X_Val, Y_Val] = 0;
                Draw_Point(X_Val, Y_Val);
                Display_Info();
            }
            else if (X_Val < G.Length && Y_Val < G.Width && Mouse_Point.X > Shift && Mouse_Point.Y > 0 && MouseButtons.Right == e.Button)
            {
                G.Value[X_Val, Y_Val] = 0;
                Draw_Point(X_Val, Y_Val);
                Display_Info();
            }
        }

        private void Resizer(object sender, EventArgs e)
        {
            Resizer();
        }

        public void Resizer()
        {
            int X_Cells = (this.Size.Width - Shift) / Cell_Pixels - 1;
            int Y_Cells = (this.Size.Height) / Cell_Pixels - 1;
            if ((X_Cells != G.Length || Y_Cells != G.Width) && X_Cells >= 2 && Y_Cells >= 2)
            {
                G = new Grid(X_Cells, Y_Cells, G);
                Draw_Grid();
                Display_Info();
            }
        }

        public void Cell_Size_Adjust()
        {
            try
            {
                if (Convert.ToInt32(Cell_Size.Text) > 3)
                {
                    Cell_Pixels = Convert.ToInt32(Cell_Size.Text);
                    Cell_Size.BackColor = Color.White;
                    Resizer();
                }
                else
                    Cell_Size.BackColor = Color.Yellow;
            }
            catch (FormatException)
            {
                Cell_Size.BackColor = Color.Red;
            }
        }

        private void Cell_Size_TextChanged(object sender, EventArgs e)
        {
            Cell_Size_Adjust();
        }

        private void Speed_Change(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(Speed.Text) > 0)
                {
                    Run_Speed = Convert.ToDouble(Speed.Text);
                    Speed.BackColor = Color.White;
                }
                else
                    Speed.BackColor = Color.Yellow;
            }
            catch (FormatException)
            {
                Speed.BackColor = Color.Red;
            }
        }

        private void Play_Button_Click(object sender, EventArgs e)
        {
            if (!Playing)
            {
                Playing = true;
                Run_Button.Enabled = false;
                Start_Playing();
            }
            else
            {
                Playing = false;
                Run_Button.Enabled = true;
            }
        }

        public async Task Start_Playing()
        {
            while (Playing)
            {
                Frame();
                await Task.Delay(Convert.ToInt32(1000/Run_Speed));
            }
        }

        private void Reset_Button_Click(object sender, EventArgs e)
        {
            G = new Grid(G.Length, G.Width);
            Initialize_Grid();
            Draw_Grid();
            Generation = 1;
            Display_Info();
        }

        public async Task Display_Info()
        {
            string Put_In = "Gen " + Convert.ToString(Generation) + Environment.NewLine;
            int[] Pop;
            Pop = new int[Rules.No_States - 1];
            for (int j = 0; j < G.Length; j++)
                for (int k = 0; k < G.Width; k++)
                    if (G.Value[j,k] != 0)
                        Pop[G.Value[j, k] - 1]++;
            for (int i = 0; i < Pop.Length; i++)
                Put_In += "Pop " + Convert.ToString(i + 1) + ": " + Convert.ToString(Pop[i]) + Environment.NewLine;
            Display.Text = Put_In;
        }

        private void Choose_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog Out_File = new OpenFileDialog();
            Out_File.Filter = "Cellular Automata Ruleset File (.car)|*.car|All Files (*.*)|*.*";
            Out_File.FilterIndex = 1;
            Out_File.Title = "Choose a Ruleset";
            bool okClicked = Convert.ToBoolean(Out_File.ShowDialog());
            if (okClicked)
            {
                Rules_Path.Text = Out_File.FileName;
                System.IO.File.WriteAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\setup.ini", Rules_Path.Text);
            }
        }

        private void Apply_Rules_Click(object sender, EventArgs e)
        {
            Apply_Rule();
        }
        private void Apply_Rule()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(Rules_Path.Text);
                int Rules_Number = 0;
                Rules = new Rule_Set();
                int first = 0;
                bool Custom_Adjacent = false;
                bool[] Custom_Adjacents;
                Custom_Adjacents = new bool[8];
                int[] Treat;
                int Treater;
                int Aser;
                bool Start = false;
                Treat = new int[Rules.Rules.Length];
                for (int i = 0; i < Treat.Length; i++)
                    Treat[i] = i;
                foreach (string line in lines)
                {
                    try
                    {
                        if (line.ToUpper().StartsWith("TREAT"))
                        {
                            Treater = Convert.ToInt32(line.Substring(line.ToUpper().LastIndexOf("T") + 1, line.ToUpper().LastIndexOf("A") - line.ToUpper().LastIndexOf("T") - 1));
                            Aser = Convert.ToInt32(line.Substring(line.ToUpper().LastIndexOf("S") + 1));
                            Treat[Treater] = Aser;
                        }
                        else if (line.ToUpper().StartsWith("CUSTOM"))
                        {
                            Custom_Adjacent = true;
                            if (line.IndexOf('1') != -1 && line.IndexOf('0') != -1)
                            {
                                first = Math.Min(line.IndexOf('1'), line.IndexOf('0'));
                                for (int i = 0; i < 8; i++)
                                {
                                    if (line[first + i] == '0')
                                        Custom_Adjacents[i] = false;
                                    else
                                        Custom_Adjacents[i] = true;
                                }
                            }
                            else if (line.IndexOf('0') == -1)
                            {
                                for (int i = 0; i < 8; i++)
                                    Custom_Adjacents[i] = true;
                                Console.Write(Custom_Adjacent);
                            }
                            else
                                for (int i = 0; i < 8; i++)
                                    Custom_Adjacents[i] = false;
                        }
                        else if (line.ToUpper().StartsWith("ADJACENT"))
                        {
                            if (line.IndexOf('1') != -1 && line.IndexOf('0') != -1)
                            {
                                first = Math.Min(line.IndexOf('1'), line.IndexOf('0'));
                                for (int i = 0; i < 8; i++)
                                {
                                    if (line[first + i] == '0')
                                        Rules.Adjacents[i] = false;
                                    else
                                        Rules.Adjacents[i] = true;
                                }
                            }
                            else if (line.IndexOf('0') == -1)
                                for (int i = 0; i < 8; i++)
                                    Rules.Adjacents[i] = true;
                            else
                                for (int i = 0; i < 8; i++)
                                    Rules.Adjacents[i] = false;
                        }
                        else if (line.ToUpper().StartsWith("STATE"))
                        {
                            Treat = new int[Convert.ToInt32(line.Substring(6))];
                            for (int i = 0; i < Treat.Length; i++)
                                Treat[i] = i;
                            Rules = new Rule_Set(Convert.ToInt32(line.Substring(6)));
                            if (Rules.No_States < G.Rules.No_States)
                                Initialize_Grid();
                        }
                        else if (line.ToUpper().StartsWith("RULE"))
                        {
                            if (Start)
                            {
                                Rules.Fill_Zeros(Rules_Number);
                                Rules_Number++;
                                Rules.Add_Rule();
                            }
                            else
                            {
                                Start = true;
                            }
                            Array.Copy(Treat,Rules.Rules[Rules_Number].Treat,Treat.Length);
                            if (Custom_Adjacent)
                            {
                                Rules.Rules[Rules_Number].Custom_Adjacent = true;
                                Rules.Rules[Rules_Number].Custom_Adjacents = new bool[8];
                                Array.Copy(Custom_Adjacents, Rules.Rules[Rules_Number].Custom_Adjacents, 8);
                            }
                        }
                        else if (line.ToUpper().StartsWith("START"))
                            Rules.Rules[Rules_Number].Start = Convert.ToInt32(line.Substring(5));
                        else if (line.ToUpper().StartsWith("END"))
                            Rules.Rules[Rules_Number].Value = Convert.ToInt32(line.Substring(3));
                        else if (line != "" && !line.StartsWith(" ") && !line.StartsWith("/"))
                            Rules.Rules[Rules_Number].Criteria[Convert.ToInt32(line.Substring(0, line.IndexOf(' ')))] = Convert.ToInt32(line.Substring(line.IndexOf(' ')));
                    }
                    catch (Exception)
                    {
                        Rules_Path.Text = "Error with File";
                    }
                    Display.Size = new Size(75, 9 + 13 * Rules.No_States);
                    Reset_Generation.Location = new Point(12, Convert.ToInt32(211 + 13 * Rules.No_States));
                    Save_State.Location = new Point(12, Convert.ToInt32(211 + 29 + 13 * Rules.No_States));
                    Load_State.Location = new Point(12, Convert.ToInt32(211 + 29 * 2 + 13 * Rules.No_States));
                    X_Shift_Label.Location = new Point(12, Convert.ToInt32(211 + 29 * 2 + 26 + 13 * Rules.No_States));
                    X_Shift.Location = new Point(12, Convert.ToInt32(211 + 29 * 2 + 26 + 16 + 13 * Rules.No_States));
                    Y_Shift_Label.Location = new Point(47, Convert.ToInt32(211 + 29 * 2 + 26 + 13 * Rules.No_States));
                    Y_Shift.Location = new Point(50, Convert.ToInt32(211 + 29 * 2 + 26 + 16 + 13 * Rules.No_States));
                    Shift_Button.Location = new Point(12, Convert.ToInt32(211 + 29 * 2 + 26 * 2 + 16 + 13 * Rules.No_States));
                }
            }
            catch (Exception)
            {
               Rules_Path.Text = "Cannot Find/Open File";
            }
            Rules.Fill_Zeros(Rules.Rules.Length - 1);
            G.Rules = Rules;
            Display_Info();
            if (System.IO.File.Exists(Rules_Path.Text))
                Last_Applied_Ruleset = Rules_Path.Text;
        }

        private void Reset_Generation_Click(object sender, EventArgs e)
        {
            Generation = 1;
            Display_Info();
        }

        private void Save_State_Click(object sender, EventArgs e)
        {
            string[] all_lines;
            SaveFileDialog Out_File = new SaveFileDialog();
            Out_File.OverwritePrompt = false;
            Out_File.Filter = "Cellular Automata State File (.cas)|*.cas|All Files (*.*)|*.*";
            Out_File.FilterIndex = 1;
            Out_File.Title = "Choose a State to Save to";
            bool okClicked = Convert.ToBoolean(Out_File.ShowDialog());
            if (okClicked && Out_File.FileName != "")
            {
                all_lines = new string[G.Length * G.Width + 8];
                for (int i = 0; i < G.Length; i++)
                    for (int j = 0; j < G.Width; j++)
                        all_lines[i * G.Width + j] = Convert.ToString(G.Value[i, j]);
                all_lines[all_lines.Length - 2] = Convert.ToString(G.Width);
                all_lines[all_lines.Length - 3] = Convert.ToString(G.Length);
                all_lines[all_lines.Length - 1] = Last_Applied_Ruleset;
                all_lines[all_lines.Length - 4] = Convert.ToString(Generation);
                all_lines[all_lines.Length - 5] = Convert.ToString(Run_Speed);
                all_lines[all_lines.Length - 6] = Convert.ToString(Cell_Size);
                all_lines[all_lines.Length - 7] = Convert.ToString(this.Height);
                all_lines[all_lines.Length - 8] = Convert.ToString(this.Width);
                System.IO.File.WriteAllLines(Out_File.FileName,all_lines);
            }
        }

        private void Load_State_Click(object sender, EventArgs e)
        {
            string[] all_lines;
            OpenFileDialog Out_File = new OpenFileDialog();
            Out_File.Filter = "Cellular Automata State File (.cas)|*.cas|All Files (*.*)|*.*";
            Out_File.FilterIndex = 1;
            Out_File.Title = "Choose a State to Load from";
            bool okClicked = Convert.ToBoolean(Out_File.ShowDialog());
            if (okClicked && Out_File.FileName != "")
            {
                all_lines = System.IO.File.ReadAllLines(Out_File.FileName);
                G = new Grid(Convert.ToInt32(all_lines[all_lines.Length - 3]), Convert.ToInt32(all_lines[all_lines.Length - 2]), G);
                for (int i = 0; i < G.Length; i++)
                    for (int j = 0; j < G.Width; j++)
                    {
                        if (G.Rules.No_States > Convert.ToInt32(all_lines[i * G.Width + j]))
                            G.Value[i, j] = Convert.ToInt32(all_lines[i * G.Width + j]);
                        else
                            G.Value[i, j] = G.Rules.No_States - 1;
                    }
                Generation = Convert.ToInt32(all_lines[all_lines.Length - 4]);
                Speed.Text = all_lines[all_lines.Length - 5];
                Cell_Size.Text = all_lines[all_lines.Length - 6].Substring(all_lines[all_lines.Length - 6].LastIndexOf(' ') + 1);
                this.Size = new Size(Convert.ToInt32(all_lines[all_lines.Length - 8]), Convert.ToInt32(all_lines[all_lines.Length - 7]));
                Draw_Grid();
                Display_Info();
            }
        }

        private void Main_App_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "S")
                Save_State_Click(sender, (EventArgs)e);
            if (e.Control && e.KeyCode.ToString() == "O")
                Load_State_Click(sender, (EventArgs)e);
        }

        private void Shift_TextChanged(object sender, EventArgs e)
        {
            TextBox send = (TextBox)sender;
            try
            {
                if (Math.Abs(Convert.ToInt32(send.Text)) < G.Length && Math.Abs(Convert.ToInt32(send.Text)) < G.Width)
                {
                    Run_Speed = Convert.ToDouble(send.Text);
                    send.BackColor = Color.White;
                }
                else
                    send.BackColor = Color.Yellow;
            }
            catch (FormatException)
            {
                send.BackColor = Color.Red;
            }
        }

        private void Shift_Button_Click(object sender, EventArgs e)
        {
            try
            {
                G.Shift(Convert.ToInt32(X_Shift.Text), Convert.ToInt32(Y_Shift.Text));
                Draw_Grid(10);
            }
            catch (FormatException)
            { }
        }

    }
}
