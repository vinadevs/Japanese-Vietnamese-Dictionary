
﻿using System;
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
    public partial class AddNewWord : Form
    {
        private OleDbConnection m_oleDbConnection;
        private OleDbCommand m_oleDbCommand;

        String m_english = null;
        String m_japanese = null;
        String m_kanji = null;
        String m_romanji = null;
        String m_note = null;

        public AddNewWord()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            m_english = EnglishRichTextBox.Text;
            m_japanese = JapaneseRichTextBox.Text;
            m_kanji = KanjiRichTextBox.Text;
            m_romanji = RomanjiRichTextBox.Text;
            m_note = NoteRichTextBox.Text;   

            if (string.IsNullOrWhiteSpace(EnglishRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(JapaneseRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(KanjiRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(RomanjiRichTextBox.Text))
            {
                MessageBox.Show("Please fill full infomation! (m_note field is option)");
            }
            else
            {
                m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                m_oleDbCommand = new OleDbCommand("INSERT into tableDict (m_english, m_japanese, m_kanji, m_romanji, [m_note]) Values(@m_english, @m_japanese, @m_kanji, @m_romanji, @m_note)", m_oleDbConnection);
                m_oleDbCommand.Connection = m_oleDbConnection;
                m_oleDbConnection.Open();

                if (m_oleDbConnection.State == ConnectionState.Open)
                {
                    m_oleDbCommand.Parameters.Add("@m_english", OleDbType.VarChar).Value = m_english;
                    m_oleDbCommand.Parameters.Add("@m_japanese", OleDbType.VarChar).Value = m_japanese;
                    m_oleDbCommand.Parameters.Add("@m_kanji", OleDbType.VarChar).Value = m_kanji;
                    m_oleDbCommand.Parameters.Add("@m_romanji", OleDbType.VarChar).Value = m_romanji;
                    m_oleDbCommand.Parameters.Add("@m_note", OleDbType.VarChar).Value = m_note;

                    try
                    {    
                        m_oleDbCommand.ExecuteNonQuery();
                        m_oleDbConnection.Close();
                        this.Close();                 
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show(ex.ToString(), "SQL Excution Failed!");
                        m_oleDbConnection.Close();
                    }
                }
                else
                {
                    MessageBox.Show(" Database Connection Failed");
                    m_oleDbConnection.Close();
                }
            }
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            m_oleDbCommand = null;
            this.Close();
        }
    }
}
