namespace GerenciarTarefas
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            vScrollBar1 = new VScrollBar();
            SuspendLayout();
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("News701 BT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(651, 185);
            button2.Name = "button2";
            button2.Size = new Size(86, 23);
            button2.TabIndex = 1;
            button2.Text = "Excluir";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("News701 BT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(651, 226);
            button3.Name = "button3";
            button3.Size = new Size(86, 23);
            button3.TabIndex = 2;
            button3.Text = "Voltar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // vScrollBar1
            // 
            vScrollBar1.Location = new Point(786, -3);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(19, 454);
            vScrollBar1.TabIndex = 3;
            vScrollBar1.Scroll += vScrollBar1_Scroll;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(805, 450);
            Controls.Add(vScrollBar1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("News701 BT", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            Text = "Visualizar";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private VScrollBar vScrollBar1;
    }
}