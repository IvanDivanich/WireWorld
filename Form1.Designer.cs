namespace WireworldForms
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
            this.emptyBtn = new System.Windows.Forms.Button();
            this.wireBtn = new System.Windows.Forms.Button();
            this.headBtn = new System.Windows.Forms.Button();
            this.tailBtn = new System.Windows.Forms.Button();
            this.grid = new WireworldForms.DataGridViewEx();
            this.orPresetBtn = new System.Windows.Forms.Button();
            this.andPresetBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.stopBtn = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // emptyBtn
            // 
            this.emptyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.emptyBtn.FlatAppearance.BorderSize = 0;
            this.emptyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emptyBtn.Location = new System.Drawing.Point(16, 10);
            this.emptyBtn.Name = "emptyBtn";
            this.emptyBtn.Size = new System.Drawing.Size(30, 30);
            this.emptyBtn.TabIndex = 1;
            this.emptyBtn.UseVisualStyleBackColor = false;
            this.emptyBtn.Click += new System.EventHandler(this.emptyBtn_Click);
            // 
            // wireBtn
            // 
            this.wireBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(185)))), ((int)(((byte)(73)))));
            this.wireBtn.FlatAppearance.BorderSize = 0;
            this.wireBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wireBtn.Location = new System.Drawing.Point(16, 46);
            this.wireBtn.Name = "wireBtn";
            this.wireBtn.Size = new System.Drawing.Size(30, 30);
            this.wireBtn.TabIndex = 1;
            this.wireBtn.UseVisualStyleBackColor = false;
            this.wireBtn.Click += new System.EventHandler(this.wireBtn_Click);
            // 
            // headBtn
            // 
            this.headBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(208)))), ((int)(((byte)(239)))));
            this.headBtn.FlatAppearance.BorderSize = 0;
            this.headBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.headBtn.Location = new System.Drawing.Point(16, 82);
            this.headBtn.Name = "headBtn";
            this.headBtn.Size = new System.Drawing.Size(30, 30);
            this.headBtn.TabIndex = 1;
            this.headBtn.UseVisualStyleBackColor = false;
            this.headBtn.Click += new System.EventHandler(this.headBtn_Click);
            // 
            // tailBtn
            // 
            this.tailBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(73)))), ((int)(((byte)(73)))));
            this.tailBtn.FlatAppearance.BorderSize = 0;
            this.tailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tailBtn.Location = new System.Drawing.Point(16, 118);
            this.tailBtn.Name = "tailBtn";
            this.tailBtn.Size = new System.Drawing.Size(30, 30);
            this.tailBtn.TabIndex = 1;
            this.tailBtn.UseVisualStyleBackColor = false;
            this.tailBtn.Click += new System.EventHandler(this.tailBtn_Click);
            // 
            // grid
            // 
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Right;
            this.grid.Location = new System.Drawing.Point(65, 0);
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1058, 687);
            this.grid.TabIndex = 2;
            // 
            // orPresetBtn
            // 
            this.orPresetBtn.BackColor = System.Drawing.Color.Transparent;
            this.orPresetBtn.FlatAppearance.BorderSize = 0;
            this.orPresetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orPresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.orPresetBtn.ForeColor = System.Drawing.Color.White;
            this.orPresetBtn.Location = new System.Drawing.Point(5, 396);
            this.orPresetBtn.Name = "orPresetBtn";
            this.orPresetBtn.Size = new System.Drawing.Size(56, 30);
            this.orPresetBtn.TabIndex = 1;
            this.orPresetBtn.Text = "OR";
            this.orPresetBtn.UseVisualStyleBackColor = false;
            this.orPresetBtn.Click += new System.EventHandler(this.orPresetBtn_Click);
            // 
            // andPresetBtn
            // 
            this.andPresetBtn.BackColor = System.Drawing.Color.Transparent;
            this.andPresetBtn.FlatAppearance.BorderSize = 0;
            this.andPresetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.andPresetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.andPresetBtn.ForeColor = System.Drawing.Color.White;
            this.andPresetBtn.Location = new System.Drawing.Point(5, 432);
            this.andPresetBtn.Name = "andPresetBtn";
            this.andPresetBtn.Size = new System.Drawing.Size(56, 30);
            this.andPresetBtn.TabIndex = 1;
            this.andPresetBtn.Text = "AND";
            this.andPresetBtn.UseVisualStyleBackColor = false;
            this.andPresetBtn.Click += new System.EventHandler(this.andPresetBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.BackColor = System.Drawing.Color.Transparent;
            this.loadBtn.FlatAppearance.BorderSize = 0;
            this.loadBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn.Image = global::WireworldForms.Properties.Resources.export;
            this.loadBtn.Location = new System.Drawing.Point(16, 535);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(30, 30);
            this.loadBtn.TabIndex = 1;
            this.loadBtn.UseVisualStyleBackColor = false;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.Transparent;
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Image = global::WireworldForms.Properties.Resources.diskette;
            this.saveBtn.Location = new System.Drawing.Point(16, 499);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(30, 30);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.Color.Transparent;
            this.clearBtn.FlatAppearance.BorderSize = 0;
            this.clearBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Image = global::WireworldForms.Properties.Resources.trash;
            this.clearBtn.Location = new System.Drawing.Point(16, 328);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(30, 30);
            this.clearBtn.TabIndex = 1;
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.BackColor = System.Drawing.Color.Transparent;
            this.stopBtn.FlatAppearance.BorderSize = 0;
            this.stopBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.stopBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.stopBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBtn.Image = global::WireworldForms.Properties.Resources.pause;
            this.stopBtn.Location = new System.Drawing.Point(16, 292);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(30, 30);
            this.stopBtn.TabIndex = 1;
            this.stopBtn.UseVisualStyleBackColor = false;
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Transparent;
            this.startBtn.FlatAppearance.BorderSize = 0;
            this.startBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.startBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startBtn.Image = global::WireworldForms.Properties.Resources.play;
            this.startBtn.Location = new System.Drawing.Point(16, 256);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(30, 30);
            this.startBtn.TabIndex = 1;
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1123, 687);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.andPresetBtn);
            this.Controls.Add(this.orPresetBtn);
            this.Controls.Add(this.tailBtn);
            this.Controls.Add(this.headBtn);
            this.Controls.Add(this.wireBtn);
            this.Controls.Add(this.emptyBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button emptyBtn;
        private System.Windows.Forms.Button wireBtn;
        private System.Windows.Forms.Button headBtn;
        private System.Windows.Forms.Button tailBtn;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Button stopBtn;
        private DataGridViewEx grid;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button orPresetBtn;
        private System.Windows.Forms.Button andPresetBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
    }
}

