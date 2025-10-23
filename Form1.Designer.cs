namespace LexicalAnalyzerOdev
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.Lexeme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TokenType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTitle.Location = new System.Drawing.Point(-1, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Lexical Analyzer ";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSource.Location = new System.Drawing.Point(1, 56);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(131, 23);
            this.lblSource.TabIndex = 1;
            this.lblSource.Text = "Kod Girişi:";
            this.lblSource.Click += new System.EventHandler(this.lblSource_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 82);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(480, 427);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.BackColor = System.Drawing.Color.Yellow;
            this.btnAnalyze.Font = new System.Drawing.Font("Consolas", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAnalyze.Location = new System.Drawing.Point(80, 555);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(299, 59);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "Analiz Et";
            this.btnAnalyze.UseVisualStyleBackColor = false;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // dgvTokens
            // 
            this.dgvTokens.BackgroundColor = System.Drawing.Color.FloralWhite;
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lexeme,
            this.TokenType,
            this.Line,
            this.Column});
            this.dgvTokens.Location = new System.Drawing.Point(477, 82);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.RowHeadersWidth = 51;
            this.dgvTokens.RowTemplate.Height = 24;
            this.dgvTokens.Size = new System.Drawing.Size(555, 657);
            this.dgvTokens.TabIndex = 4;
            this.dgvTokens.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTokens_CellContentClick);
            // 
            // Lexeme
            // 
            this.Lexeme.FillWeight = 95F;
            this.Lexeme.HeaderText = "Lexeme";
            this.Lexeme.MinimumWidth = 6;
            this.Lexeme.Name = "Lexeme";
            this.Lexeme.Width = 125;
            // 
            // TokenType
            // 
            this.TokenType.FillWeight = 95F;
            this.TokenType.HeaderText = "Token Type";
            this.TokenType.MinimumWidth = 6;
            this.TokenType.Name = "TokenType";
            this.TokenType.Width = 125;
            // 
            // Line
            // 
            this.Line.FillWeight = 95F;
            this.Line.HeaderText = "Line";
            this.Line.MinimumWidth = 6;
            this.Line.Name = "Line";
            this.Line.Width = 125;
            // 
            // Column
            // 
            this.Column.FillWeight = 95F;
            this.Column.HeaderText = "Column";
            this.Column.MinimumWidth = 6;
            this.Column.Name = "Column";
            this.Column.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(1033, 737);
            this.Controls.Add(this.dgvTokens);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Lexical Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lexeme;
        private System.Windows.Forms.DataGridViewTextBoxColumn TokenType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column;
    }
}

