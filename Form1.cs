using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection; 

namespace LexicalAnalyzerOdev
{
    public partial class Form1 : Form
    {
        
        private LexicalAnalyzer analyzer = new LexicalAnalyzer();

        public Form1()
        {
            InitializeComponent();
            dgvTokens.AutoGenerateColumns = false;

            dgvTokens.Columns.Add("Lexeme", "Lexeme");
            dgvTokens.Columns.Add("TokenType", "Token Type");
            dgvTokens.Columns.Add("Line", "Line");
            dgvTokens.Columns.Add("Column", "Column");

            dgvTokens.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

           
            string keywordPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "keywords.csv");

            if (analyzer.LoadKeywords(keywordPath))
            {
                
            }
            else
            {
                
            }
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
           
            string code = richTextBox1.Text;

            

           
            List<Token> tokens = analyzer.Analyze(code);

           
            dgvTokens.Rows.Clear();

           
            foreach (var token in tokens)
            {
               
                dgvTokens.Rows.Add(token.Lexeme, token.TokenType, token.Line, token.Column);
            }

        }

       
        private void lblSource_Click(object sender, EventArgs e)
        {
        }

        private void dgvTokens_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}