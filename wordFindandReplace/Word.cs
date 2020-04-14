using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spire.Doc;

namespace MertTestUygulama
{
    public partial class Word : Form
    {
        private FileInfo[] Files;
        List<TextBox> textboxs = new List<TextBox>();
        Document document = new Document();
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();
        Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
        private static Microsoft.Office.Interop.Word.Document aDoc;
        private string selectedFilePath = "";
        private string selectedSavePath = "";
        public Word()
        {
            InitializeComponent();
        }

      

        

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(lst_docs.SelectedItem.ToString());
            selectedFilePath = filesDictionary[lst_docs.SelectedItem.ToString()];
            createDirectory();
        }
        private void getDocxDocuments()
        {
            /*Set default save folder*/
            selectedSavePath = Directory.GetCurrentDirectory();

            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            try
            {
                Files = directoryInfo.GetFiles("*.docx");
                if (Files.Length >= 1)
                {
                    foreach (FileInfo file in Files)
                    {
                        lst_docs.Items.Add(file.Name);
                        filesDictionary.Add(file.Name,file.FullName);
                    }
                }
                else
                {
                    lst_docs.Items.Add("Not found.");
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("There was a problem getting the files: " + exception);
            }
        }
        private void createDirectory()
        {

            Regex regex = new Regex("<[^>]*>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            document.LoadFromFile(selectedFilePath);
            MatchCollection matches = regex.Matches(document.GetText());
            foreach (var match in matches)
            {
                if (!dictionary.ContainsKey(match.ToString()))
                    dictionary.Add(match.ToString(), "Adjust the allowance.");
            }
            int xindextext = 280;
            int xindexlabel = 185;
            int y = 0;
            for (int i = 0; i < dictionary.Count; i++)
            {
                if (i%10 == 0)
                {
                    xindexlabel += 97;
                    xindextext += 97;
                    y = 0;
                }

                TextBox newTextBox = new TextBox();
                newTextBox.Location = new Point(xindextext, 22 + (25 * y));
                newTextBox.Size = new Size(240, 30);
                newTextBox.Text = dictionary.ElementAt(i).Value;
                this.Controls.Add(newTextBox);
                textboxs.Add(newTextBox);

                List<Label> labels = new List<Label>();
                Label newLabel = new Label();
                newLabel.Location = new Point(xindexlabel, 22 + (25 * y));
                newLabel.Text = dictionary.ElementAt(i).Key;
                this.Controls.Add(newLabel);
                labels.Add(newLabel);
                y++;
            }
        }

        private void replaceandSave()
        {
            string filePath = selectedFilePath;
            string fileName = filesDictionary.FirstOrDefault(x => x.Value == selectedFilePath).Key;
            aDoc = wordApp.Documents.OpenNoRepairDialog(filePath);

            foreach (var theVariable in dictionary)
            {
                FindAndReplace(wordApp, theVariable.Key, theVariable.Value);
            }
            aDoc.SaveAs(selectedSavePath+"\\"+"new_"+fileName);
            aDoc.Close(true);
        }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            selectedSavePath = folderBrowserDialog.SelectedPath;
            txt_path.Text = selectedSavePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (check_accept.Checked)
            {
                for (int i = 0; i < textboxs.Count; i++)
                {
                    TextBox text = textboxs[i];
                    dictionary[dictionary.ElementAt(i).Key] = text.Text;
                }

                replaceandSave();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (check_accept.Checked)
                btn_write.Enabled = true;
            else
                btn_write.Enabled = false;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Word_Load(object sender, EventArgs e)
        {
            getDocxDocuments();
            txt_path.Text = selectedSavePath;
        }
    }
}
