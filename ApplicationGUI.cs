using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.IO;

namespace TechnicalDictionary
{
    public partial class ApplicationGUI : Form
    {
        public ApplicationGUI()
        {
            InitializeComponent();
            RtbTextSetting();
        }

        private void ApplicationGUI_Load(object sender, EventArgs e)
        {

            ConnectTechnicalDatabase();
            this.Resize += new EventHandler(ApplicationGUI_Resize);
        }

        public void PopuldateDatabase()
        {
            while (m_oleDbDataReader.Read())
            {
                g_listBoxWords.Items.Add(m_oleDbDataReader[0].ToString());
            }
        }

        public void ConnectTechnicalDatabase()
        {
            if (m_searchFunctionflag)
            {
                try
                {
                    m_dataSet = new DataSet();
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                    m_oleDbConnection.Open();
                    m_oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM tableDict ORDER BY English", m_oleDbConnection);
                    m_oleDbDataAdapter.Fill(m_dataSet, "tableDict");
                    m_oleDbCommand = new OleDbCommand("SELECT English FROM tableDict ORDER BY English", m_oleDbConnection);
                    m_oleDbDataReader = m_oleDbCommand.ExecuteReader();
                    g_listBoxWords.Items.Clear();
                    g_translatedText.Text = "";

                    PopuldateDatabase();
                }
                catch (Exception)
                {
                    // IF YOU ARE FACING AN EXCEPTION HERE: PLEASE INSTALL MISSING ACCESS DATABASE DEPENDECY PACKAGES /Dependencies/Intall_this_engine_firstly.exe
                    MessageBox.Show("Can not find DictDatabase.accdb at your run path!", "Error! Please contact us to improve this issue!");
                    this.Close();
                }
                g_textToSearch.Focus();
            }
            else
            {
                try
                {
                    //connect to database
                    m_dataSet = new DataSet();
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                    m_oleDbConnection.Open();
                    m_oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM tableDict ORDER BY Romanji", m_oleDbConnection);
                    m_oleDbDataAdapter.Fill(m_dataSet, "tableDict");
                    m_oleDbCommand = new OleDbCommand("SELECT Romanji FROM tableDict ORDER BY Romanji", m_oleDbConnection);
                    m_oleDbDataReader = m_oleDbCommand.ExecuteReader();
                    g_listBoxWords.Items.Clear();
                    g_translatedText.Text = "";
                    //display data into listbox
                    while (m_oleDbDataReader.Read())
                    {
                        g_listBoxWords.Items.Add(m_oleDbDataReader[0].ToString());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not find TecnostarDatabase.accdb at your run path!", "Error! Please contact us to improve this issue!");
                    this.Close();
                }
                g_textToSearch.Focus();
            }
        }

        public void ConnectMinnanonihongoDatabase()
        {
            //reset all
            m_oleDbConnection.Close();
            m_oleDbCommand = null;
            m_oleDbDeleter = null;
            m_oleDbDataReader = null;
            m_oleDbDataAdapter = null;
            m_dataSet = null;

            if (m_minanoSearchFunctionFlag)
            {
                try
                {
                    //connect to database
                    m_dataSet = new DataSet();
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\MinnanonihongoDatabase.accdb;");
                    m_oleDbConnection.Open();
                    m_oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM tblMinnaDict ORDER BY Romanji", m_oleDbConnection);
                    m_oleDbDataAdapter.Fill(m_dataSet, "tableDict");
                    m_oleDbCommand = new OleDbCommand("SELECT Romanji FROM tblMinnaDict ORDER BY Romanji", m_oleDbConnection);
                    m_oleDbDataReader = m_oleDbCommand.ExecuteReader();
                    g_listBoxWords.Items.Clear();
                    g_translatedText.Text = "";
                    //display data into listbox
                    while (m_oleDbDataReader.Read())
                    {
                        g_listBoxWords.Items.Add(m_oleDbDataReader[0].ToString());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not find MinnanonihongoDatabase.accdb at your run path!", "Error! Please contact us to improve this issue!");
                    this.Close();
                }
                g_textToSearch.Focus();
            }
            else
            {
                try
                {
                    //connect to database
                    m_dataSet = new DataSet();
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\MinnanonihongoDatabase.accdb;");
                    m_oleDbConnection.Open();
                    m_oleDbDataAdapter = new OleDbDataAdapter("SELECT * FROM tblMinnaDict ORDER BY Vietnamese", m_oleDbConnection);
                    m_oleDbDataAdapter.Fill(m_dataSet, "tableDict");
                    m_oleDbCommand = new OleDbCommand("SELECT Vietnamese FROM tblMinnaDict ORDER BY Vietnamese", m_oleDbConnection);
                    m_oleDbDataReader = m_oleDbCommand.ExecuteReader();
                    g_listBoxWords.Items.Clear();
                    g_translatedText.Text = "";
                    //display data into listbox
                    while (m_oleDbDataReader.Read())
                    {
                        g_listBoxWords.Items.Add(m_oleDbDataReader[0].ToString());
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Can not find MinnanonihongoDatabase.accdb at your run path!", "Error! Please contact us to improve this issue!");
                    this.Close();
                }
                g_textToSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int i;
            DataRow dr;

            if (m_minanoFunctionFlag)
            {
                if (m_minanoSearchFunctionFlag)
                {
                    try
                    {
                        for (i = 0; i <= g_listBoxWords.Items.Count - 1; i++)
                        {
                            if (g_textToSearch.TextLength <= g_listBoxWords.Items[i].ToString().Length)
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper().Substring(0, g_textToSearch.TextLength))
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();

                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString() 
                                        + "\n\n--- Tiếng Việt ---\n" + dr[4].ToString().Trim()
                                        + "\n\n--- Tiếng Hán ---\n" + dr[3].ToString().Trim() 
                                        + "\n\n --- Hiragana/Katakana ---\n" + dr[0].ToString().Trim()
                                        + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim();

                                    HighLight();
                                    break;
                                }
                            }
                            else
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper())
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();

                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString() 
                                        + "\n\n--- Tiếng Việt ---\n" + dr[4].ToString().Trim() 
                                        + "\n\n--- Tiếng Hán ---\n" + dr[3].ToString().Trim()
                                        + "\n\n--- Hiragana/Katakana ---\n" + dr[0].ToString().Trim()
                                        + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim();

                                    HighLight();
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Can not find your word!", "Error! Please contact us to improve this issue!");
                    }
                }
                else
                {
                    try
                    {
                        for (i = 0; i <= g_listBoxWords.Items.Count - 1; i++)
                        {
                            if (g_textToSearch.TextLength <= g_listBoxWords.Items[i].ToString().Length)
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper().Substring(0, g_textToSearch.TextLength))
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();
                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString()  
                                       + "\n\n--- Tiếng Hán ---\n" + dr[3].ToString().Trim() 
                                       + "\n\n--- Hiragana/Katakana ---\n" + dr[0].ToString().Trim()
                                       + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                       + "\n\n--- Pronunciation (Romanji) ---\n" + dr[1].ToString().Trim();
                                    HighLight();
                                    break;
                                }
                            }
                            else
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper())
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();
                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString()
                                      + "\n\n--- Tiếng Hán ---\n" + dr[3].ToString().Trim()
                                      + "\n\n--- Hiragana/Katakana ---\n" + dr[0].ToString().Trim()
                                      + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim()
                                      + "\n\n--- Pronunciation (Romanji) ---\n" + dr[1].ToString().Trim();
                                    HighLight();
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Can not find your word!", "Error! Please contact us to improve this issue!");
                    }
                }
            }
            else
            {
                if (m_searchFunctionflag)
                {
                    try
                    {
                        for (i = 0; i <= g_listBoxWords.Items.Count - 1; i++)
                        {
                            if (g_textToSearch.TextLength <= g_listBoxWords.Items[i].ToString().Length)
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper().Substring(0, g_textToSearch.TextLength))
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();
                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString() 
                                        + "\n\n" + "--- Hiragana/Katakana ---\n" + dr[1].ToString().Trim()
                                        + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                        + "\n\n--- Pronunciation(Romanji) ---\n" + dr[3].ToString().Trim()
                                        + "\n\n--- Note ---\n" + dr[4].ToString().Trim();
                                    HighLight();
                                    break;
                                }
                            }
                            else
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper())
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();
                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString() 
                                       + "\n\n--- Hiragana/Katakana ---\n" + dr[1].ToString().Trim()
                                       + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                       + "\n\n--- Pronunciation(Romanji) ---\n" + dr[3].ToString().Trim()
                                       + "\n\n--- Note ---\n" + dr[4].ToString().Trim();
                                    HighLight();
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Can not find your word!", "Error! Please contact us to improve this issue!");
                    }
                }
                else
                {
                    try
                    {
                        for (i = 0; i <= g_listBoxWords.Items.Count - 1; i++)
                        {
                            if (g_textToSearch.TextLength <= g_listBoxWords.Items[i].ToString().Length)
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper().Substring(0, g_textToSearch.TextLength))
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();
                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString() 
                                        + "\n\n--- Hiragana/Katakana ---\n" + dr[1].ToString().Trim()
                                        + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                        + "\n\n--- English ---\n" + dr[0].ToString().Trim()
                                        + "\n\n--- Note ---\n" + dr[4].ToString().Trim();
                                    HighLight();
                                    break;
                                }
                            }
                            else
                            {
                                if (g_textToSearch.Text.Trim().ToUpper() == g_listBoxWords.Items[i].ToString().ToUpper())
                                {
                                    //Select matched term
                                    g_listBoxWords.SelectedIndex = i;
                                    //Display translation
                                    dr = m_dataSet.Tables[0].Rows[i];
                                    g_translatedText.Clear();
                                    g_translatedText.Text = g_listBoxWords.Items[i].ToString() 
                                        + "\n\n--- Hiragana/Katakana ---\n" + dr[1].ToString().Trim()
                                       + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                       + "\n\n--- English ---\n" + dr[0].ToString().Trim()
                                       + "\n\n--- Note ---\n" + dr[4].ToString().Trim();
                                    HighLight();
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Can not find your word!", "Error! Please contact us to improve this issue!");
                    }
                }
            }
        }

        public void RtbTextSetting()
        {
            g_translatedText.Font = new Font("Open Sans", 18, FontStyle.Bold);
        }

        private void lstTerms_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow dr;

            if (m_minanoFunctionFlag)
            {
                if (m_dataSet.Tables[0].Rows.Count > 0)
                {
                    if (g_listBoxWords.SelectedIndex != -1)
                    {
                        dr = m_dataSet.Tables[0].Rows[g_listBoxWords.SelectedIndex];

                        g_translatedText.Clear();

                        if (m_minanoSearchFunctionFlag)
                        {
                            g_translatedText.Text = g_listBoxWords.SelectedItem.ToString()
                              + "\n\n--- Tiếng Việt ---\n" + dr[4].ToString().Trim()
                              + "\n\n--- Tiếng Hán ---\n" + dr[3].ToString().Trim()
                              + "\n\n --- Hiragana/Katakana ---\n" + dr[0].ToString().Trim()
                              + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim();
                            //Color making
                            HighLight();
                        }
                        else
                        {
                            g_translatedText.Text = g_listBoxWords.SelectedItem.ToString() 
                            + "\n\n--- Tiếng Hán ---\n" + dr[3].ToString().Trim()
                            + "\n\n--- Hiragana/Katakana ---\n" + dr[0].ToString().Trim()
                            + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim()
                            + "\n\n--- Pronunciation (Romanji) ---\n" + dr[1].ToString().Trim();
                            //Color making
                            HighLight();
                        }
                    }
                }
            }
            else
            {
                if (m_dataSet.Tables[0].Rows.Count > 0)
                {
                    if (g_listBoxWords.SelectedIndex != -1)
                    {
                        dr = m_dataSet.Tables[0].Rows[g_listBoxWords.SelectedIndex];

                        g_translatedText.Clear();

                        if (m_searchFunctionflag)
                        {
                            g_translatedText.Text = g_listBoxWords.SelectedItem.ToString() 
                                + "\n\n--- Hiragana/Katakana ---\n" + dr[1].ToString().Trim()
                                + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                + "\n\n--- Pronunciation(Romanji) ---\n" + dr[3].ToString().Trim()
                                + "\n\n--- Note ---\n" + dr[4].ToString().Trim();
                            //Color making
                            HighLight();
                        }
                        else
                        {
                            g_translatedText.Text = g_listBoxWords.SelectedItem.ToString() 
                                + "\n\n--- Hiragana/Katakana ---\n" + dr[1].ToString().Trim()
                                + "\n\n--- Kanji ---\n" + dr[2].ToString().Trim() 
                                + "\n\n--- English ---\n" + dr[0].ToString().Trim()
                                + "\n\n--- Note ---\n" + dr[4].ToString().Trim();
                            //Color making
                            HighLight();
                        }
                    }
                }
            }

            //Mouse events
            ContextMenuStrip cm = new ContextMenuStrip();
            cm.Items.Add("Online Search");
            cm.Items.Add("Delete");
            cm.Items.Add("Edit");
            g_listBoxWords.ContextMenuStrip = cm;
            cm.ItemClicked += new ToolStripItemClickedEventHandler(contexMenu_ItemClicked);
        }

        void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Online Search")
            {
                System.Diagnostics.Process.Start("http://jisho.org/search/" + g_listBoxWords.SelectedItem);
            }
            else if (e.ClickedItem.Text == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this word?", "Confirmation",
                    MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    DeleteDatabase(g_listBoxWords.SelectedItem.ToString());

                    m_oleDbConnection.Close();

                    if (m_minanoFunctionFlag)
                    {
                        ConnectMinnanonihongoDatabase();
                    }
                    else
                    {
                        ConnectTechnicalDatabase();
                    }
                }
            }
            else if (e.ClickedItem.Text == "Edit")
            {
                DataRow dr;

                if (m_dataSet.Tables[0].Rows.Count > 0)
                {
                    if (g_listBoxWords.SelectedIndex != -1)
                    {
                        dr = m_dataSet.Tables[0].Rows[g_listBoxWords.SelectedIndex];

                        g_translatedText.Clear();

                        if (m_minanoFunctionFlag)
                        {
                            if (m_minanoSearchFunctionFlag)
                            {
                                //ewnd.EditWord_Load(Kita, TiengViet, Kanji, Romanji, TiengHan);
                                EditDatabaseMinnadict(dr[0].ToString().Trim(), dr[4].ToString().Trim(),
                                               dr[2].ToString().Trim(), g_listBoxWords.SelectedItem.ToString() ,
                                               dr[3].ToString().Trim());
                            }
                            else
                            {
                                EditDatabaseMinnadict(dr[0].ToString().Trim(), g_listBoxWords.SelectedItem.ToString(),
                                               dr[2].ToString().Trim(), dr[1].ToString().Trim(), 
                                               dr[3].ToString().Trim());
                            }
                        }
                        else
                        {
                            if (m_searchFunctionflag)
                            {
                                EditDatabaseTechDict(g_listBoxWords.SelectedItem.ToString(), dr[1].ToString().Trim(),
                                               dr[2].ToString().Trim(), dr[3].ToString().Trim(),
                                               dr[4].ToString().Trim());
                            }
                            else
                            {
                                EditDatabaseTechDict(dr[0].ToString().Trim(), dr[1].ToString().Trim(),
                                               dr[2].ToString().Trim(), g_listBoxWords.SelectedItem.ToString(), 
                                               dr[4].ToString().Trim());
                            }
                        }
                    }
                }
            }
        }

        public void EditDatabaseTechDict(String English, String Japanese, String Kanji, String Romanji, String Note)
        {
            EditWord ewtd = new EditWord();
            ewtd.EditWord_Load(English, Japanese, Kanji, Romanji, Note);
            ewtd.FormBorderStyle = FormBorderStyle.FixedDialog;
            ewtd.StartPosition = FormStartPosition.CenterParent;
            ewtd.MaximizeBox = false;
            ewtd.MinimizeBox = false;
            ewtd.FormClosed += new FormClosedEventHandler(ewtd_FormClosed);
            ewtd.ShowDialog();
        }
        private void ewtd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Load updated word into list words
            ConnectTechnicalDatabase();
        }

        public void EditDatabaseMinnadict(String Kita, String TiengViet, String Kanji, String Romanji, String TiengHan)
        {
            EditWordForMinaDict ewnd = new EditWordForMinaDict();
            ewnd.EditWord_Load(Kita, TiengViet, Kanji, Romanji, TiengHan);
            ewnd.FormBorderStyle = FormBorderStyle.FixedDialog;
            ewnd.StartPosition = FormStartPosition.CenterParent;
            ewnd.MaximizeBox = false;
            ewnd.MinimizeBox = false;
            ewnd.FormClosed += new FormClosedEventHandler(ewnd_FormClosed);
            ewnd.ShowDialog();
        }
        private void ewnd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Load updated word into list words
            ConnectMinnanonihongoDatabase();
        }

        public void DeleteDatabase(String SelectedItem)
        {
            if (!m_minanoFunctionFlag)
            {
                if (m_searchFunctionflag)
                {
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                    m_oleDbDeleter = new OleDbCommand("DELETE FROM tableDict WHERE English = @ItemSelected", m_oleDbConnection);
                    m_oleDbDeleter.Connection = m_oleDbConnection;
                    m_oleDbConnection.Open();

                    if (m_oleDbConnection.State == ConnectionState.Open)
                    {
                        m_oleDbDeleter.Parameters.Add("@ItemSelected", OleDbType.VarChar).Value = SelectedItem;

                        try
                        {
                            m_oleDbDeleter.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show(ex.ToString(), "SQL Excution Failed! ,Can not delete this word!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Database Connection Failed, Can not delete this word!");
                    }
                }
                else
                {
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\TechnicalDatabase.accdb;");
                    m_oleDbDeleter = new OleDbCommand("DELETE FROM tableDict WHERE Romanji = @ItemSelected", m_oleDbConnection);
                    m_oleDbDeleter.Connection = m_oleDbConnection;
                    m_oleDbConnection.Open();

                    if (m_oleDbConnection.State == ConnectionState.Open)
                    {
                        m_oleDbDeleter.Parameters.Add("@ItemSelected", OleDbType.VarChar).Value = SelectedItem;

                        try
                        {
                            m_oleDbDeleter.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show(ex.ToString(), "SQL Excution Failed!, Can not delete this word!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Database Connection Failed, Can not delete this word!");
                    }
                }
            }
            else
            {
                if (m_minanoSearchFunctionFlag)
                {
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\MinnanonihongoDatabase.accdb;");
                    m_oleDbDeleter = new OleDbCommand("DELETE FROM tblMinnaDict WHERE Romanji = @ItemSelected", m_oleDbConnection);
                    m_oleDbDeleter.Connection = m_oleDbConnection;
                    m_oleDbConnection.Open();

                    if (m_oleDbConnection.State == ConnectionState.Open)
                    {
                        m_oleDbDeleter.Parameters.Add("@ItemSelected", OleDbType.VarChar).Value = SelectedItem;

                        try
                        {
                            m_oleDbDeleter.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show(ex.ToString(), "SQL Excution Failed! ,Can not delete this word!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Database Connection Failed, Can not delete this word!");
                    }
                }
                else
                {
                    m_oleDbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\\Databases\\MinnanonihongoDatabase.accdb;");
                    m_oleDbDeleter = new OleDbCommand("DELETE FROM tblMinnaDict WHERE Vietnamese = @ItemSelected", m_oleDbConnection);
                    m_oleDbDeleter.Connection = m_oleDbConnection;
                    m_oleDbConnection.Open();

                    if (m_oleDbConnection.State == ConnectionState.Open)
                    {
                        m_oleDbDeleter.Parameters.Add("@ItemSelected", OleDbType.VarChar).Value = SelectedItem;

                        try
                        {
                            m_oleDbDeleter.ExecuteNonQuery();
                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show(ex.ToString(), "SQL Excution Failed!, Can not delete this word!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(" Database Connection Failed, Can not delete this word!");
                    }
                }
            }
        }

        private void ApplicationGUI_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                g_listBoxWords.Height = this.Height;
                g_textToSearch.Height = this.Height;
                g_translatedText.Width = this.Width;
            }
        }

        private void ApplicationGUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_oleDbConnection.Close();
            m_oleDbCommand = null;
            m_oleDbDeleter = null;
            m_oleDbDataReader = null;
            m_oleDbDataAdapter = null;
            m_dataSet = null;
        }

        private void mnuFileClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void addNewWordForTechDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewWord anw = new AddNewWord();
            anw.FormBorderStyle = FormBorderStyle.FixedDialog;
            anw.StartPosition = FormStartPosition.CenterParent;
            anw.MaximizeBox = false;
            anw.MinimizeBox = false;
            anw.FormClosed += new FormClosedEventHandler(anwftd_FormClosed);
            anw.ShowDialog();
        }

        private void anwftd_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Load new word added into list words
            this.g_groupBox1.Text = "Find English";
            this.g_groupBox2.Text = "Technical Tecnical Dictionary";
            ConnectTechnicalDatabase();
        }

        private void addNewWordForMinnaDictToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewWordForNihongoDict anwfmina = new AddNewWordForNihongoDict();
            anwfmina.FormBorderStyle = FormBorderStyle.FixedDialog;
            anwfmina.StartPosition = FormStartPosition.CenterParent;
            anwfmina.MaximizeBox = false;
            anwfmina.MinimizeBox = false;
            anwfmina.FormClosed += new FormClosedEventHandler(anwfmina_FormClosed);
            anwfmina.ShowDialog();
        }

        private void anwfmina_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Load new word added into list words
            this.g_groupBox1.Text = "Find Romanji";
            this.g_groupBox2.Text = "Minna No Nihongo Dictionary";
            ConnectMinnanonihongoDatabase();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Japanese-Vietnamese Dictionary 2024, MIT License.");
        }

        private void languageChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_minanoFunctionFlag)
            {
                m_minanoSearchFunctionFlag = !m_minanoSearchFunctionFlag;
                ConnectMinnanonihongoDatabase();

                if (m_minanoSearchFunctionFlag)
                {
                    this.g_groupBox1.Text = "Find Romanji";
                }
                else
                {
                    this.g_groupBox1.Text = "Find Vietnamese";
                }
            }
            else
            {
                m_searchFunctionflag = !m_searchFunctionflag;
                m_oleDbConnection.Close();
                ConnectTechnicalDatabase();

                if (m_searchFunctionflag)
                {
                    this.g_groupBox1.Text = "Find English";
                }
                else
                {
                    this.g_groupBox1.Text = "Find Romanji";
                }
            }
        }

        private void dictChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_minanoFunctionFlag = !m_minanoFunctionFlag;

            m_minanoSearchFunctionFlag = true;

            if (m_minanoFunctionFlag)
            {
                this.g_groupBox2.Text = "Minna No Nihongo Dictionary";
                this.g_groupBox1.Text = "Find Romanji";
                ConnectMinnanonihongoDatabase();
            }
            else
            {
                this.g_groupBox2.Text = "Technical Technical Dictionary";
                this.g_groupBox1.Text = "Find English";
                m_oleDbConnection.Close();
                ConnectTechnicalDatabase();
            }
        }

        private void HighLight()
        {
            try
            {
                //Colors making
                Regex rex = new Regex(g_listBoxWords.SelectedItem.ToString());
                MatchCollection mc = rex.Matches(g_translatedText.Text);
                int StarCursorPosition = g_translatedText.SelectionStart;
                foreach (Match m in mc)
                {
                    int starIndex = m.Index;
                    int StopIndex = m.Length;
                    g_translatedText.Select(starIndex, StopIndex);
                    g_translatedText.SelectionColor = Color.Blue;
                    g_translatedText.SelectionStart = StarCursorPosition;
                }

                char[] c = g_translatedText.Text.ToString().ToCharArray();

                int i;

                for (i = 1; i <= g_translatedText.Text.ToString().Length - 2; i++)
                {
                    if (c[i - 1] == '-' && c[i] == ' ' && c[i + 1] == 'H')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 25;
                        g_translatedText.SelectionColor = Color.Red;
                    }
                    else if (c[i - 1] == '-' && c[i] == ' ' && c[i + 1] == 'K')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 13;
                        g_translatedText.SelectionColor = Color.Purple;
                    }
                    else if (c[i - 1] == '-' && c[i] == ' ' && c[i + 1] == 'P')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 30;
                        g_translatedText.SelectionColor = Color.Orange;
                    }
                    else if (c[i - 1] == '-' && c[i] == ' ' && c[i + 1] == 'E')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 15;
                        g_translatedText.SelectionColor = Color.Green;
                    }
                    else if (c[i - 1] == '-' && c[i] == ' ' && c[i + 1] == 'N')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 12;
                        g_translatedText.SelectionColor = Color.Brown;
                    }
                    else if (c[i - 1] == '-' && c[i] == ' ' && c[i + 7] == 'V')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 18;
                        g_translatedText.SelectionColor = Color.Brown;
                    }
                    else if (c[i - 1] == '-' && c[i] == ' ' && c[i + 7] == 'H')
                    {
                        g_translatedText.SelectionStart = i - 3;
                        g_translatedText.SelectionLength = 17;
                        g_translatedText.SelectionColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error! Please contact us to improve this issue!");
            }
        }

        // member variables
        private OleDbConnection m_oleDbConnection;
        private OleDbDataReader m_oleDbDataReader;
        private OleDbCommand m_oleDbCommand;
        private OleDbCommand m_oleDbDeleter;
        private DataSet m_dataSet;
        private OleDbDataAdapter m_oleDbDataAdapter;
        private bool m_searchFunctionflag = true;
        private bool m_minanoFunctionFlag = false;
        private bool m_minanoSearchFunctionFlag = true;
        private string m_searchString;
        private DateTime m_lastKeyPressTime;
    }
}