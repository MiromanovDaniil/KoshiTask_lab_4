
namespace KoshiTask_lab_4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.F_eps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.Run_Runge_Kutta_3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.F_h = new System.Windows.Forms.TextBox();
            this.F_t0 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // F_eps
            // 
            this.F_eps.AcceptsReturn = true;
            this.F_eps.Location = new System.Drawing.Point(650, 58);
            this.F_eps.Name = "F_eps";
            this.F_eps.Size = new System.Drawing.Size(93, 20);
            this.F_eps.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(594, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "eps = ";
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(12, 32);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(550, 550);
            this.zedGraphControl.TabIndex = 3;
            // 
            // Run_Runge_Kutta_3
            // 
            this.Run_Runge_Kutta_3.Font = new System.Drawing.Font("Times New Roman", 10.86792F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Run_Runge_Kutta_3.Location = new System.Drawing.Point(620, 291);
            this.Run_Runge_Kutta_3.Name = "Run_Runge_Kutta_3";
            this.Run_Runge_Kutta_3.Size = new System.Drawing.Size(166, 48);
            this.Run_Runge_Kutta_3.TabIndex = 4;
            this.Run_Runge_Kutta_3.Text = "Run ";
            this.Run_Runge_Kutta_3.UseVisualStyleBackColor = true;
            this.Run_Runge_Kutta_3.Click += new System.EventHandler(this.Run_Runge_Kutta_3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(611, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "h = ";
            // 
            // F_h
            // 
            this.F_h.AcceptsReturn = true;
            this.F_h.Location = new System.Drawing.Point(650, 100);
            this.F_h.Name = "F_h";
            this.F_h.Size = new System.Drawing.Size(93, 20);
            this.F_h.TabIndex = 6;
            // 
            // F_t0
            // 
            this.F_t0.AcceptsReturn = true;
            this.F_t0.Location = new System.Drawing.Point(650, 138);
            this.F_t0.Name = "F_t0";
            this.F_t0.Size = new System.Drawing.Size(93, 20);
            this.F_t0.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 6.792453F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(618, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(611, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "t₀ = ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 619);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.F_t0);
            this.Controls.Add(this.F_h);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Run_Runge_Kutta_3);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.F_eps);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox F_eps;
        private System.Windows.Forms.Label label1;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.Button Run_Runge_Kutta_3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox F_h;
        private System.Windows.Forms.TextBox F_t0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

