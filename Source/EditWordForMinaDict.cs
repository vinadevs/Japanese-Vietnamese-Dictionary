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
    public partial class EditWordForMinaDict : Form
    {
        private OleDbConnection anw_cn;
        private OleDbCommand anw_com;

        String Kita = null;
        String TiengViet = null;
        String Kanji = null;
        String Romanji = null;
        String TiengHan = null;

        public EditWordForMinaDict()
        {
            InitializeComponent();
        }

        public void EditWord_Load(String t_Kita, String t_TiengViet, String t_Kanji, String t_Romanji, String t_TiengHan)
        {
            KitaRichTextBox.Text = t_Kita;
            TiengHanRichTextBox.Text = t_TiengHan;
            TiengVietRichTextBox.Text = t_TiengViet;
            KanjiRichTextBox.Text = t_Kanji;
            RomanjiRichTextBox.Text = t_Romanji;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to edit this word?", "Confirmation",
                  MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Kita = KitaRichTextBox.Text;
                TiengHan = TiengHanRichTextBox.Text;
                TiengViet = TiengVietRichTextBox.Text;
                Kanji = KanjiRichTextBox.Text;
                Romanji = RomanjiRichTextBox.Text;

                //if (string.IsNullOrWhiteSpace(KitaRichTextBox.Text) ||
                //    string.IsNullOrWhiteSpace(TiengHanRichTextBox.Text) ||
                //    string.IsNullOrWhiteSpace(TiengVietRichTextBox.Text) ||
                //    string.IsNullOrWhiteSpace(RomanjiRichTextBox.Text) ||
                //    string.IsNullOrWhiteSpace(KanjiRichTextBox.Text))
                //{
                //    MessageBox.Show("Please fill full infomation!");
                //}
                //else
                {
                    anw_cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\MinnanonihongoDatabase.accdb;");
                    anw_com = new OleDbCommand("UPDATE tblMinnaDict SET Japanese=@Japanese, Romanji=@Romanji, Kanji=@Kanji, ChineseMeaning=@ChineseMeaning, Vietnamese=@Vietnamese WHERE Romanji=@Romanji", anw_cn);
                    anw_com.Connection = anw_cn;
                    anw_cn.Open();

                    if (anw_cn.State == ConnectionState.Open)
                    {
                        anw_com.Parameters.Add("@Japanese", OleDbType.VarChar).Value = Kita;
                        anw_com.Parameters.Add("@Romanji", OleDbType.VarChar).Value = Romanji;
                        anw_com.Parameters.Add("@Kanji", OleDbType.VarChar).Value = Kanji;
                        anw_com.Parameters.Add("@ChineseMeaning", OleDbType.VarChar).Value = TiengHan;
                        anw_com.Parameters.Add("@Vietnamese", OleDbType.VarChar).Value = TiengViet;

                        try
                        {
                            anw_com.ExecuteNonQuery();
                            anw_cn.Close();
                            this.Close();
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show(ex.ToString(), "SQL Excution Failed!");
                            anw_cn.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Database Connection Failed");
                        anw_cn.Close();
                    }
                }
            }
        }
    }
}
