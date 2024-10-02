namespace GerenciarTarefas
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnVisualizar = new Button();
            mCDataTarefa = new MonthCalendar();
            lblError = new Label();
            label1 = new Label();
            txbTarefa = new TextBox();
            btnTarefa = new Button();
            SuspendLayout();
            // 
            // btnVisualizar
            // 
            btnVisualizar.FlatStyle = FlatStyle.Popup;
            btnVisualizar.Font = new Font("News706 BT", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnVisualizar.Location = new Point(97, 208);
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Size = new Size(101, 33);
            btnVisualizar.TabIndex = 12;
            btnVisualizar.Text = "Visualizar";
            btnVisualizar.UseVisualStyleBackColor = true;
            btnVisualizar.Click += btnVisualizar_Click;
            // 
            // mCDataTarefa
            // 
            mCDataTarefa.Location = new Point(297, 55);
            mCDataTarefa.Name = "mCDataTarefa";
            mCDataTarefa.TabIndex = 11;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(381, 226);
            lblError.Name = "lblError";
            lblError.Size = new Size(51, 15);
            lblError.TabIndex = 10;
            lblError.Text = "[ERROR]";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("News706 BT", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(59, 55);
            label1.Name = "label1";
            label1.Size = new Size(155, 19);
            label1.TabIndex = 9;
            label1.Text = "Escreva sua tarefa";
            // 
            // txbTarefa
            // 
            txbTarefa.Location = new Point(59, 94);
            txbTarefa.Name = "txbTarefa";
            txbTarefa.Size = new Size(202, 23);
            txbTarefa.TabIndex = 8;
            // 
            // btnTarefa
            // 
            btnTarefa.FlatStyle = FlatStyle.Popup;
            btnTarefa.Font = new Font("News706 BT", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            btnTarefa.Location = new Point(109, 142);
            btnTarefa.Name = "btnTarefa";
            btnTarefa.Size = new Size(76, 27);
            btnTarefa.TabIndex = 7;
            btnTarefa.Text = "Enviar";
            btnTarefa.UseVisualStyleBackColor = true;
            btnTarefa.Click += btnTarefa_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Cornsilk;
            ClientSize = new Size(583, 296);
            Controls.Add(btnVisualizar);
            Controls.Add(mCDataTarefa);
            Controls.Add(lblError);
            Controls.Add(label1);
            Controls.Add(txbTarefa);
            Controls.Add(btnTarefa);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Cadastrar";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnVisualizar;
        private MonthCalendar mCDataTarefa;
        private Label lblError;
        private Label label1;
        private TextBox txbTarefa;
        private Button btnTarefa;
    }
}