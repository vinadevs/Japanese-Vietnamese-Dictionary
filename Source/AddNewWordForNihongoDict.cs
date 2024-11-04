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
    public partial class AddNewWordForNihongoDict : Form
    {
        private OleDbConnection anw_cn;
        private OleDbCommand anw_com;

        String Kita = null;
        String TiengViet = null;
        String Kanji = null;
        String Romanji = null;
        String TiengHan = null;

        public AddNewWordForNihongoDict()
        {
            InitializeComponent();
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Kita = KitaRichTextBox.Text;
            TiengHan = TiengHanRichTextBox.Text;
            TiengViet = TiengVietRichTextBox.Text;
            Kanji = KanjiRichTextBox.Text;
            Romanji = RomanjiRichTextBox.Text;

            if (string.IsNullOrWhiteSpace(KitaRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(TiengHanRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(TiengVietRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(RomanjiRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(KanjiRichTextBox.Text))
            {
                MessageBox.Show("Please fill full infomation!");
            }
            else
            {
                anw_cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\MinnanonihongoDatabase.accdb;");
                anw_com = new OleDbCommand("INSERT into tblMinnaDict (Japanese, Romanji, Kanji, ChineseMeaning, Vietnamese) Values(@Japanese, @Romanji, @Kanji, @ChineseMeaning, @Vietnamese)", anw_cn);
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
