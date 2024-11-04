using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TechnicalDictionary
{
    public partial class EditWord : Form
    {
        private OleDbConnection ew_cn;
        private OleDbCommand ew_com;

        String English = null;
        String Japanese = null;
        String Kanji = null;
        String Romanji = null;
        String Note = null;

        public EditWord()
        {
            InitializeComponent();
        }

        public void EditWord_Load(String t_English, String t_Japanese, String t_Kanji, String t_Romanji, String t_Note)
        {
            EnglishRichTextBox_Edit.Text = t_English;
            JapaneseRichTextBox_Edit.Text = t_Japanese;
            KanjiRichTextBox_Edit.Text = t_Kanji;
            RomanjiRichTextBox_Edit.Text = t_Romanji;
            NoteRichTextBox_Edit.Text = t_Note;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            ew_com = null;
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to edit this word?", "Confirmation",
                   MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                English = EnglishRichTextBox_Edit.Text;
                Japanese = JapaneseRichTextBox_Edit.Text;
                Kanji = KanjiRichTextBox_Edit.Text;
                Romanji = RomanjiRichTextBox_Edit.Text;
                Note = NoteRichTextBox_Edit.Text;

                //if (string.IsNullOrWhiteSpace(EnglishRichTextBox_Edit.Text) ||
                //    string.IsNullOrWhiteSpace(JapaneseRichTextBox_Edit.Text) ||
                //    string.IsNullOrWhiteSpace(KanjiRichTextBox_Edit.Text) ||
                //    string.IsNullOrWhiteSpace(RomanjiRichTextBox_Edit.Text) ||
                //    string.IsNullOrWhiteSpace(NoteRichTextBox_Edit.Text))
                //{
                //    MessageBox.Show("Please fill full infomation! Type none for field");
                //}
                //else
                {
                    ew_cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                    ew_com = new OleDbCommand("UPDATE tableDict SET English=@English, Japanese=@Japanese, Kanji=@Kanji, Romanji=@Romanji, [Note]=@Note WHERE English=@English", ew_cn);
                    ew_com.Connection = ew_cn;
                    ew_cn.Open();

                    if (ew_cn.State == ConnectionState.Open)
                    {
                        ew_com.Parameters.Add("@English", OleDbType.VarChar).Value = English;
                        ew_com.Parameters.Add("@Japanese", OleDbType.VarChar).Value = Japanese;
                        ew_com.Parameters.Add("@Kanji", OleDbType.VarChar).Value = Kanji;
                        ew_com.Parameters.Add("@Romanji", OleDbType.VarChar).Value = Romanji;
                        ew_com.Parameters.Add("@Note", OleDbType.VarChar).Value = Note;

                        try
                        {
                            ew_com.ExecuteNonQuery();
                            ew_cn.Close();
                            this.Close();
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show(ex.ToString(), "SQL Excution Failed!");
                            ew_cn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Database Connection Failed");
                        ew_cn.Close();
                    }
                }
            }
        }
    }
}
