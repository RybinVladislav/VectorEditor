namespace VectorEditor
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новыйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.stripBtn1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.stripBtn2 = new System.Windows.Forms.ToolStripMenuItem();
            this.stripBtn3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.stripBtn4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.размерИзображенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CopyButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.lvlDownButton = new System.Windows.Forms.Button();
            this.lvlUpButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.fillColorButton = new System.Windows.Forms.Button();
            this.borderColorButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pathButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.ellipseButton = new System.Windows.Forms.Button();
            this.actionButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(938, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новыйToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.сохранитьКакToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // новыйToolStripMenuItem
            // 
            this.новыйToolStripMenuItem.Name = "новыйToolStripMenuItem";
            this.новыйToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.новыйToolStripMenuItem.Text = "Создать";
            this.новыйToolStripMenuItem.Click += new System.EventHandler(this.новыйToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            this.сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьКакToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.сохранитьToolStripMenuItem.Text = "Экспорт в .svg";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoButton,
            this.toolStripMenuItem6,
            this.stripBtn1,
            this.toolStripMenuItem3,
            this.stripBtn2,
            this.stripBtn3,
            this.toolStripMenuItem4,
            this.stripBtn4,
            this.toolStripMenuItem5,
            this.размерИзображенияToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.editToolStripMenuItem.Text = "Правка";
            // 
            // undoButton
            // 
            this.undoButton.Enabled = false;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(191, 22);
            this.undoButton.Text = "Отменить";
            this.undoButton.Click += new System.EventHandler(this.отменитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(188, 6);
            // 
            // stripBtn1
            // 
            this.stripBtn1.Enabled = false;
            this.stripBtn1.Name = "stripBtn1";
            this.stripBtn1.Size = new System.Drawing.Size(191, 22);
            this.stripBtn1.Text = "Дублировать";
            this.stripBtn1.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 6);
            // 
            // stripBtn2
            // 
            this.stripBtn2.Enabled = false;
            this.stripBtn2.Name = "stripBtn2";
            this.stripBtn2.Size = new System.Drawing.Size(191, 22);
            this.stripBtn2.Text = "Переместить вперёд";
            this.stripBtn2.Click += new System.EventHandler(this.lvlUpButton_Click);
            // 
            // stripBtn3
            // 
            this.stripBtn3.Enabled = false;
            this.stripBtn3.Name = "stripBtn3";
            this.stripBtn3.Size = new System.Drawing.Size(191, 22);
            this.stripBtn3.Text = "Переместить назад";
            this.stripBtn3.Click += new System.EventHandler(this.lvlDownButton_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(188, 6);
            // 
            // stripBtn4
            // 
            this.stripBtn4.Enabled = false;
            this.stripBtn4.Name = "stripBtn4";
            this.stripBtn4.Size = new System.Drawing.Size(191, 22);
            this.stripBtn4.Text = "Удалить фигуру";
            this.stripBtn4.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(188, 6);
            // 
            // размерИзображенияToolStripMenuItem
            // 
            this.размерИзображенияToolStripMenuItem.Name = "размерИзображенияToolStripMenuItem";
            this.размерИзображенияToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.размерИзображенияToolStripMenuItem.Text = "Размер изображения";
            this.размерИзображенияToolStripMenuItem.Click += new System.EventHandler(this.размерИзображенияToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(36, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 490);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(48, 48);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.numericUpDown1);
            this.panel3.Controls.Add(this.fillColorButton);
            this.panel3.Controls.Add(this.borderColorButton);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 514);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(938, 47);
            this.panel3.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.CopyButton);
            this.panel5.Controls.Add(this.DeleteButton);
            this.panel5.Controls.Add(this.lvlDownButton);
            this.panel5.Controls.Add(this.lvlUpButton);
            this.panel5.Location = new System.Drawing.Point(222, 8);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(229, 32);
            this.panel5.TabIndex = 6;
            this.panel5.Visible = false;
            // 
            // CopyButton
            // 
            this.CopyButton.Location = new System.Drawing.Point(138, 2);
            this.CopyButton.Margin = new System.Windows.Forms.Padding(2);
            this.CopyButton.Name = "CopyButton";
            this.CopyButton.Size = new System.Drawing.Size(88, 29);
            this.CopyButton.TabIndex = 3;
            this.CopyButton.Text = "Дублировать";
            this.CopyButton.UseVisualStyleBackColor = true;
            this.CopyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(68, 2);
            this.DeleteButton.Margin = new System.Windows.Forms.Padding(2);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(65, 29);
            this.DeleteButton.TabIndex = 2;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // lvlDownButton
            // 
            this.lvlDownButton.Image = global::VectorEditor.Properties.Resources.leveldown;
            this.lvlDownButton.Location = new System.Drawing.Point(37, 2);
            this.lvlDownButton.Margin = new System.Windows.Forms.Padding(2);
            this.lvlDownButton.Name = "lvlDownButton";
            this.lvlDownButton.Size = new System.Drawing.Size(27, 29);
            this.lvlDownButton.TabIndex = 1;
            this.lvlDownButton.UseVisualStyleBackColor = true;
            this.lvlDownButton.Click += new System.EventHandler(this.lvlDownButton_Click);
            // 
            // lvlUpButton
            // 
            this.lvlUpButton.Image = global::VectorEditor.Properties.Resources.levelup;
            this.lvlUpButton.Location = new System.Drawing.Point(5, 2);
            this.lvlUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.lvlUpButton.Name = "lvlUpButton";
            this.lvlUpButton.Size = new System.Drawing.Size(27, 29);
            this.lvlUpButton.TabIndex = 0;
            this.lvlUpButton.UseVisualStyleBackColor = true;
            this.lvlUpButton.Click += new System.EventHandler(this.lvlUpButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Толщина";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(169, 8);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(41, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.TabStop = false;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // fillColorButton
            // 
            this.fillColorButton.BackColor = System.Drawing.Color.Transparent;
            this.fillColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fillColorButton.Location = new System.Drawing.Point(62, 28);
            this.fillColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.fillColorButton.Name = "fillColorButton";
            this.fillColorButton.Size = new System.Drawing.Size(37, 11);
            this.fillColorButton.TabIndex = 0;
            this.fillColorButton.TabStop = false;
            this.fillColorButton.UseVisualStyleBackColor = false;
            this.fillColorButton.Click += new System.EventHandler(this.fillColorButton_Click);
            // 
            // borderColorButton
            // 
            this.borderColorButton.BackColor = System.Drawing.Color.Black;
            this.borderColorButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.borderColorButton.Location = new System.Drawing.Point(62, 12);
            this.borderColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(37, 11);
            this.borderColorButton.TabIndex = 0;
            this.borderColorButton.TabStop = false;
            this.borderColorButton.UseVisualStyleBackColor = false;
            this.borderColorButton.Click += new System.EventHandler(this.borderColorButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Обводка";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заливка";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pathButton);
            this.panel2.Controls.Add(this.rectangleButton);
            this.panel2.Controls.Add(this.ellipseButton);
            this.panel2.Controls.Add(this.actionButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(36, 490);
            this.panel2.TabIndex = 6;
            // 
            // pathButton
            // 
            this.pathButton.Image = global::VectorEditor.Properties.Resources.path;
            this.pathButton.Location = new System.Drawing.Point(4, 106);
            this.pathButton.Margin = new System.Windows.Forms.Padding(2);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(27, 29);
            this.pathButton.TabIndex = 3;
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.Image = global::VectorEditor.Properties.Resources.rectangle;
            this.rectangleButton.Location = new System.Drawing.Point(4, 72);
            this.rectangleButton.Margin = new System.Windows.Forms.Padding(2);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(27, 29);
            this.rectangleButton.TabIndex = 2;
            this.rectangleButton.UseVisualStyleBackColor = true;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // ellipseButton
            // 
            this.ellipseButton.Image = global::VectorEditor.Properties.Resources.ellipse;
            this.ellipseButton.Location = new System.Drawing.Point(4, 38);
            this.ellipseButton.Margin = new System.Windows.Forms.Padding(2);
            this.ellipseButton.Name = "ellipseButton";
            this.ellipseButton.Size = new System.Drawing.Size(27, 29);
            this.ellipseButton.TabIndex = 1;
            this.ellipseButton.UseVisualStyleBackColor = true;
            this.ellipseButton.Click += new System.EventHandler(this.ellipseButton_Click);
            // 
            // actionButton
            // 
            this.actionButton.Image = global::VectorEditor.Properties.Resources.selection;
            this.actionButton.Location = new System.Drawing.Point(4, 4);
            this.actionButton.Margin = new System.Windows.Forms.Padding(2);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(27, 29);
            this.actionButton.TabIndex = 0;
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Vector Image (*.svg)|*.svg";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Binary File (*.dat)|*.dat";
            // 
            // saveFileDialog2
            // 
            this.saveFileDialog2.Filter = "Binary File (*.dat)|*.dat";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Векторный редактор";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem новыйToolStripMenuItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button fillColorButton;
        private System.Windows.Forms.Button borderColorButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Button ellipseButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button lvlUpButton;
        private System.Windows.Forms.Button lvlDownButton;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CopyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stripBtn1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem stripBtn2;
        private System.Windows.Forms.ToolStripMenuItem stripBtn3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem stripBtn4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem размерИзображенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem undoButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;

    }
}

