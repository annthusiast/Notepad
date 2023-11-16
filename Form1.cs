using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Villahermosa_Pad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes before closing?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    SaveFileDialog op = new SaveFileDialog();
                    op.Title = "Save";
                    op.Filter = "Text Document(.txt)|.txt| All Files(.)|*.*";
                    if (op.ShowDialog() == DialogResult.OK)
                        richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
                    this.Text = op.FileName;
                    break;
                case DialogResult.No:
                    richTextBox1.Clear();
                    string message = "Do you want to close this window?";
                    string title = "Close Window";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult Result = MessageBox.Show(message, title, buttons);
                    if (Result == DialogResult.Yes)
                    {
                        // Continue with the closing operation 
                    }
                    else
                    {
                        // cancel the closing operation 
                        e.Cancel = true;
                    }
                    break;
                case DialogResult.Cancel:
                    // cancel the closing operation 
                    e.Cancel = true;
                    break;
            }
        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "open";
            op.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog op = new SaveFileDialog();
            op.Title = "save";
            op.Filter = "Text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.SaveFile(op.FileName, RichTextBoxStreamType.PlainText);
            this.Text = op.FileName;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to close?";
            string title = "Close Window";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("OK", "OK", MessageBoxButtons.OK);
            }


        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = System.DateTime.Now.ToString();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog op = new FontDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.Font = op.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog op = new ColorDialog();
            if (op.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = op.Color;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor += 0.1f;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ZoomFactor -= 0.1f;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {

                 richTextBox1.Visible = !richTextBox1.Visible;
                statusBarToolStripMenuItem.Checked = richTextBox1.Visible;
            

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void richTextBox1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            int pos = richTextBox1.SelectionStart;
            int line = richTextBox1.GetLineFromCharIndex(pos) + 1;
            int col = pos - richTextBox1.GetFirstCharIndexOfCurrentLine() + 1;
            int visibleLines = richTextBox1.ClientSize.Height / richTextBox1.Font.Height;
            int totalLines = richTextBox1.Lines.Length;
            double percentScrolled = (double)line / (visibleLines - totalLines + 1) * 100;

            toolStripStatusLabel2.Text = "Ln " + line + ", Col " + col;
            toolStripStatusLabel3.Text = $"{percentScrolled:F2}%";
            
        }

        private void statusStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
