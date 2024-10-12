/* -*- C++ -*- */

/****************************************************************************
** Copyright (c) 2001-2014
**
** This file is part of the QuickFIX FIX Engine
**
** This file may be distributed under the terms of the quickfixengine.org
** license as defined by quickfixengine.org and appearing in the file
** LICENSE included in the packaging of this file.
**
** This file is provided AS IS with NO WARRANTY OF ANY KIND, INCLUDING THE
** WARRANTY OF DESIGN, MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE.
**
** See http://www.quickfixengine.org/LICENSE for licensing information.
**
** Contact ask@quickfixengine.org if any conditions of this licensing are
** not clear to you.
**
****************************************************************************/

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
        private OleDbConnection anw_cn;
        private OleDbCommand anw_com;

        String English = null;
        String Japanese = null;
        String Kanji = null;
        String Romanji = null;
        String Note = null;

        public AddNewWord()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            English = EnglishRichTextBox.Text;
            Japanese = JapaneseRichTextBox.Text;
            Kanji = KanjiRichTextBox.Text;
            Romanji = RomanjiRichTextBox.Text;
            Note = NoteRichTextBox.Text;   

            if (string.IsNullOrWhiteSpace(EnglishRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(JapaneseRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(KanjiRichTextBox.Text) ||
                string.IsNullOrWhiteSpace(RomanjiRichTextBox.Text))
            {
                MessageBox.Show("Please fill full infomation! (Note field is option)");
            }
            else
            {
                anw_cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                anw_com = new OleDbCommand("INSERT into tableDict (English, Japanese, Kanji, Romanji, [Note]) Values(@English, @Japanese, @Kanji, @Romanji, @Note)", anw_cn);
                anw_com.Connection = anw_cn;
                anw_cn.Open();

                if (anw_cn.State == ConnectionState.Open)
                {
                    anw_com.Parameters.Add("@English", OleDbType.VarChar).Value = English;
                    anw_com.Parameters.Add("@Japanese", OleDbType.VarChar).Value = Japanese;
                    anw_com.Parameters.Add("@Kanji", OleDbType.VarChar).Value = Kanji;
                    anw_com.Parameters.Add("@Romanji", OleDbType.VarChar).Value = Romanji;
                    anw_com.Parameters.Add("@Note", OleDbType.VarChar).Value = Note;

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

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            anw_com = null;
            this.Close();
        }
    }
}
