using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad4Me
{
    public partial class frmMain : Form
    {
        string ourFileName;

        string lastFindWorld;
        bool lastFindDown;
        bool lastFindMatchCase;

        void doSave(string filename)
        {
            ourFileName = filename;
            textBox.SaveFile(filename);
        }

        void doSaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                doSave(saveFileDialog1.FileName);
            }
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        bool checkChanges()
        {
            return true;
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmFind find = new frmFind();
            find.Show(this);
        }
        

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmMain parent_form = (frmMain)Owner;
             parent_form.DoFind(textFind.Text, rdoDown, chkmatch.Checked);
        }

        public void DoFind(string search, bool down, bool match_case)
        {
            lastFindWorld = search;
            lastFindDown = down;
            lastFindMatchCase = match_case;
            if (down)
            {
                if (match_case)
                {
                    textBox.Find(search, textBox.SelectionStart + 1, RichTextBoxFinds.MatchCase);
                }
                else
                {
                    textBox.Find(search, textBox.SelectionStart + 1, RichTextBoxFinds.None);
                }
            }
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.SelectAll();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkChanges())
            {

            
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ourFileName))
            {
                doSaveAs();
            }
            else
            {
                doSave(ourFileName);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
