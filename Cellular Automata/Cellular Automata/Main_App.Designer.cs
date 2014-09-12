using System;
using System.Windows.Forms;
namespace Cellular_Automata
{
    partial class Main_App
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_App));
            this.Run_Button = new System.Windows.Forms.Button();
            this.Cell_Size_Label = new System.Windows.Forms.Label();
            this.Cell_Size = new System.Windows.Forms.TextBox();
            this.Play_Button = new System.Windows.Forms.Button();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Speed_Label = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.TextBox();
            this.Choose_File = new System.Windows.Forms.Button();
            this.Rules_Path = new System.Windows.Forms.TextBox();
            this.Apply_Rules = new System.Windows.Forms.Button();
            this.Display = new System.Windows.Forms.TextBox();
            this.Reset_Generation = new System.Windows.Forms.Button();
            this.Save_State = new System.Windows.Forms.Button();
            this.Load_State = new System.Windows.Forms.Button();
            this.X_Shift_Label = new System.Windows.Forms.Label();
            this.X_Shift = new System.Windows.Forms.TextBox();
            this.Y_Shift = new System.Windows.Forms.TextBox();
            this.Y_Shift_Label = new System.Windows.Forms.Label();
            this.Shift_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Run_Button
            // 
            this.Run_Button.Location = new System.Drawing.Point(12, 12);
            this.Run_Button.Name = "Run_Button";
            this.Run_Button.Size = new System.Drawing.Size(75, 23);
            this.Run_Button.TabIndex = 0;
            this.Run_Button.Text = "Next Frame";
            this.Run_Button.UseVisualStyleBackColor = true;
            this.Run_Button.Click += new System.EventHandler(this.Run_Button_Click);
            // 
            // Cell_Size_Label
            // 
            this.Cell_Size_Label.AutoSize = true;
            this.Cell_Size_Label.Location = new System.Drawing.Point(9, 41);
            this.Cell_Size_Label.Name = "Cell_Size_Label";
            this.Cell_Size_Label.Size = new System.Drawing.Size(47, 13);
            this.Cell_Size_Label.TabIndex = 1;
            this.Cell_Size_Label.Text = "Cell Size";
            // 
            // Cell_Size
            // 
            this.Cell_Size.Location = new System.Drawing.Point(57, 38);
            this.Cell_Size.Name = "Cell_Size";
            this.Cell_Size.Size = new System.Drawing.Size(30, 20);
            this.Cell_Size.TabIndex = 2;
            this.Cell_Size.Text = "32";
            this.Cell_Size.TextChanged += new System.EventHandler(this.Cell_Size_TextChanged);
            // 
            // Play_Button
            // 
            this.Play_Button.BackColor = System.Drawing.Color.White;
            this.Play_Button.Image = ((System.Drawing.Image)(resources.GetObject("Play_Button.Image")));
            this.Play_Button.Location = new System.Drawing.Point(12, 57);
            this.Play_Button.Name = "Play_Button";
            this.Play_Button.Size = new System.Drawing.Size(39, 29);
            this.Play_Button.TabIndex = 3;
            this.Play_Button.UseVisualStyleBackColor = false;
            this.Play_Button.Click += new System.EventHandler(this.Play_Button_Click);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Image = ((System.Drawing.Image)(resources.GetObject("Reset_Button.Image")));
            this.Reset_Button.Location = new System.Drawing.Point(57, 57);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(28, 29);
            this.Reset_Button.TabIndex = 4;
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // Speed_Label
            // 
            this.Speed_Label.AutoSize = true;
            this.Speed_Label.Location = new System.Drawing.Point(9, 89);
            this.Speed_Label.Name = "Speed_Label";
            this.Speed_Label.Size = new System.Drawing.Size(38, 13);
            this.Speed_Label.TabIndex = 1;
            this.Speed_Label.Text = "Speed";
            // 
            // Speed
            // 
            this.Speed.Location = new System.Drawing.Point(57, 86);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(30, 20);
            this.Speed.TabIndex = 2;
            this.Speed.Text = "3";
            this.Speed.TextChanged += new System.EventHandler(this.Speed_Change);
            // 
            // Choose_File
            // 
            this.Choose_File.Location = new System.Drawing.Point(12, 112);
            this.Choose_File.Name = "Choose_File";
            this.Choose_File.Size = new System.Drawing.Size(75, 23);
            this.Choose_File.TabIndex = 5;
            this.Choose_File.Text = "Choose File";
            this.Choose_File.UseVisualStyleBackColor = true;
            this.Choose_File.Click += new System.EventHandler(this.Choose_File_Click);
            // 
            // Rules_Path
            // 
            this.Rules_Path.Location = new System.Drawing.Point(12, 141);
            this.Rules_Path.Name = "Rules_Path";
            this.Rules_Path.Size = new System.Drawing.Size(73, 20);
            this.Rules_Path.TabIndex = 6;
            // 
            // Apply_Rules
            // 
            this.Apply_Rules.Location = new System.Drawing.Point(12, 167);
            this.Apply_Rules.Name = "Apply_Rules";
            this.Apply_Rules.Size = new System.Drawing.Size(75, 23);
            this.Apply_Rules.TabIndex = 7;
            this.Apply_Rules.Text = "Apply Rules";
            this.Apply_Rules.UseVisualStyleBackColor = true;
            this.Apply_Rules.Click += new System.EventHandler(this.Apply_Rules_Click);
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(12, 196);
            this.Display.Multiline = true;
            this.Display.Name = "Display";
            this.Display.ReadOnly = true;
            this.Display.Size = new System.Drawing.Size(75, 35);
            this.Display.TabIndex = 8;
            // 
            // Reset_Generation
            // 
            this.Reset_Generation.Location = new System.Drawing.Point(12, 237);
            this.Reset_Generation.Name = "Reset_Generation";
            this.Reset_Generation.Size = new System.Drawing.Size(75, 23);
            this.Reset_Generation.TabIndex = 9;
            this.Reset_Generation.Text = "Make Gen 1";
            this.Reset_Generation.UseVisualStyleBackColor = true;
            this.Reset_Generation.Click += new System.EventHandler(this.Reset_Generation_Click);
            // 
            // Save_State
            // 
            this.Save_State.Location = new System.Drawing.Point(12, 266);
            this.Save_State.Name = "Save_State";
            this.Save_State.Size = new System.Drawing.Size(75, 23);
            this.Save_State.TabIndex = 10;
            this.Save_State.Text = "Save State";
            this.Save_State.UseVisualStyleBackColor = true;
            this.Save_State.Click += new System.EventHandler(this.Save_State_Click);
            // 
            // Load_State
            // 
            this.Load_State.Location = new System.Drawing.Point(12, 295);
            this.Load_State.Name = "Load_State";
            this.Load_State.Size = new System.Drawing.Size(75, 23);
            this.Load_State.TabIndex = 11;
            this.Load_State.Text = "Load State";
            this.Load_State.UseVisualStyleBackColor = true;
            this.Load_State.Click += new System.EventHandler(this.Load_State_Click);
            // 
            // X_Shift_Label
            // 
            this.X_Shift_Label.AutoSize = true;
            this.X_Shift_Label.Location = new System.Drawing.Point(12, 321);
            this.X_Shift_Label.Name = "X_Shift_Label";
            this.X_Shift_Label.Size = new System.Drawing.Size(14, 13);
            this.X_Shift_Label.TabIndex = 12;
            this.X_Shift_Label.Text = "X";
            // 
            // X_Shift
            // 
            this.X_Shift.Location = new System.Drawing.Point(12, 337);
            this.X_Shift.Name = "X_Shift";
            this.X_Shift.Size = new System.Drawing.Size(35, 20);
            this.X_Shift.TabIndex = 13;
            this.X_Shift.Text = "0";
            this.X_Shift.TextChanged += new System.EventHandler(this.Shift_TextChanged);
            // 
            // Y_Shift
            // 
            this.Y_Shift.Location = new System.Drawing.Point(50, 337);
            this.Y_Shift.Name = "Y_Shift";
            this.Y_Shift.Size = new System.Drawing.Size(35, 20);
            this.Y_Shift.TabIndex = 13;
            this.Y_Shift.Text = "0";
            this.Y_Shift.TextChanged += new System.EventHandler(this.Shift_TextChanged);
            // 
            // Y_Shift_Label
            // 
            this.Y_Shift_Label.AutoSize = true;
            this.Y_Shift_Label.Location = new System.Drawing.Point(47, 321);
            this.Y_Shift_Label.Name = "Y_Shift_Label";
            this.Y_Shift_Label.Size = new System.Drawing.Size(14, 13);
            this.Y_Shift_Label.TabIndex = 12;
            this.Y_Shift_Label.Text = "Y";
            // 
            // Shift_Button
            // 
            this.Shift_Button.Location = new System.Drawing.Point(10, 363);
            this.Shift_Button.Name = "Shift_Button";
            this.Shift_Button.Size = new System.Drawing.Size(75, 23);
            this.Shift_Button.TabIndex = 14;
            this.Shift_Button.Text = "Shift";
            this.Shift_Button.UseVisualStyleBackColor = true;
            this.Shift_Button.Click += new System.EventHandler(this.Shift_Button_Click);
            // 
            // Main_App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.Shift_Button);
            this.Controls.Add(this.Y_Shift);
            this.Controls.Add(this.X_Shift);
            this.Controls.Add(this.Y_Shift_Label);
            this.Controls.Add(this.X_Shift_Label);
            this.Controls.Add(this.Load_State);
            this.Controls.Add(this.Save_State);
            this.Controls.Add(this.Reset_Generation);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.Apply_Rules);
            this.Controls.Add(this.Rules_Path);
            this.Controls.Add(this.Choose_File);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.Play_Button);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Cell_Size);
            this.Controls.Add(this.Speed_Label);
            this.Controls.Add(this.Cell_Size_Label);
            this.Controls.Add(this.Run_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main_App";
            this.Text = "Cellular Automata";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.Activated += new System.EventHandler(this.Draw_Grid);
            this.Deactivate += new System.EventHandler(this.Lose_Focus);
            this.Load += new System.EventHandler(this.Draw_Grid);
            this.SizeChanged += new System.EventHandler(this.Resizer);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_App_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Change_Point);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Choose_Value);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Choose_Value(object sender, MouseEventArgs e)
        {
            var Mouse_Point = this.PointToClient(Cursor.Position);
            int X_Val = (Mouse_Point.X - Shift) / Cell_Pixels;
            int Y_Val = Mouse_Point.Y / Cell_Pixels;
            if (X_Val < G.Length && Y_Val < G.Width && Mouse_Point.X > Shift && Mouse_Point.Y > 0 && MouseButtons.Left == e.Button)
            {
                Choose_Amount Popup = new Choose_Amount();
                Popup.ShowDialog();
                if (Popup.EnteredText != "")
                    G.Value[X_Val, Y_Val] = Convert.ToInt32(Popup.EnteredText);
                    if (G.Value[X_Val, Y_Val] >= G.Rules.Rules[0].Criteria.Length)
                        G.Value[X_Val, Y_Val] = 0;
                    Draw_Point(X_Val, Y_Val);
                    Display_Info();
            }
        }
        private void Lose_Focus(object sender, System.EventArgs e)
        {
            Playing = false;
        }

        private void Change_Point(object sender, System.EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Change_Point(me);
        }

        private void Draw_Grid(object sender, System.EventArgs e)
        {
            Draw_Grid(500);
        }

        #endregion

        private System.Windows.Forms.Button Run_Button;
        private Label Cell_Size_Label;
        private TextBox Cell_Size;
        private Button Play_Button;
        private Button Reset_Button;
        private Label Speed_Label;
        private TextBox Speed;
        private Button Choose_File;
        private TextBox Rules_Path;
        private Button Apply_Rules;
        private TextBox Display;
        private Button Reset_Generation;
        private Button Save_State;
        private Button Load_State;
        private Label X_Shift_Label;
        private TextBox X_Shift;
        private TextBox Y_Shift;
        private Label Y_Shift_Label;
        private Button Shift_Button;

    }
}

