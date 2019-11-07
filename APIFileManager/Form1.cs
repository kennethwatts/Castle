﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace APIFileMerger
{

    public partial
    class FormMain : Form
    {

        List<string> oldUnModfiles = new List<string>();
        List<string> oldModfiles = new List<string>();
        List<string> newUnModfiles = new List<string>();

        List<string> oldUnModCsfiles = new List<string>();
        List<string> oldModCsfiles = new List<string>();


        // string nameOfFile;
        public FormMain()
        {
            InitializeComponent();
        }

        public static string GetFileAsString(string strFilename)
        {
            string strFileContents;

            // create reader & open file
            TextReader tr = new StreamReader(strFilename);
            // read a line of text
            strFileContents = tr.ReadToEnd();
            // close the stream
            tr.Close();

            return strFileContents;
        }

        // this writes the string into the file
        public static void WriteStringToFile(string strFilename, string strData)
        {
            if (File.Exists(strFilename))
            {
                File.Delete(strFilename);
            }
            StreamWriter SW;
            SW = File.CreateText(strFilename);
            SW.Write(strData);
            SW.Close();
        }

        // for when the browse button for old un modified file is clicked
        private void buttonBrowseOldUnModFile_Click(object sender, EventArgs e)
        {
            if (ofdAPIFileMerger.ShowDialog(this) == DialogResult.OK)
            {
                textBoxOldUnModFile.Text = ofdAPIFileMerger.SelectedPath;
                //this gets all the .csproj files even from sub directories
                foreach (string file in Directory.EnumerateFiles(ofdAPIFileMerger.SelectedPath,
                        "*.csproj",
                        SearchOption.AllDirectories))
                {
                    if (file.Contains("Ellucian.Colleague.Api.Client.csproj") || file.Contains("Ellucian.Colleague.Api.csproj") ||
                      file.Contains("Ellucian.Colleague.Coordination.Student.csproj") || file.Contains("Ellucian.Colleague.Api.csproj") ||
                      file.Contains("Ellucian.Colleague.Data.Student.csproj") || file.Contains("Ellucian.Colleague.Domain.Student.csproj") ||
                      file.Contains("Ellucian.Colleague.Dtos.Student.csproj"))
                    {
                        //this adds the file name to the list of file names
                        oldUnModfiles.Add(file);
                    }

                }

            }
        }

        // for when the browse button for old modified file is clicked
        private void buttonBrowseOldModFile_Click(object sender, EventArgs e)
        {
            if (ofdAPIFileMerger.ShowDialog(this) == DialogResult.OK)

                textBoxOldModFile.Text = ofdAPIFileMerger.SelectedPath;
            //this gets all the .csproj files even from sub directories
            foreach (string file in Directory.EnumerateFiles(ofdAPIFileMerger.SelectedPath,
                    "*.csproj",
                    SearchOption.AllDirectories))
            {
                if (file.Contains("Ellucian.Colleague.Api.Client.csproj") || file.Contains("Ellucian.Colleague.Api.csproj") ||
                     file.Contains("Ellucian.Colleague.Coordination.Student.csproj") || file.Contains("Ellucian.Colleague.Api.csproj") ||
                     file.Contains("Ellucian.Colleague.Data.Student.csproj") || file.Contains("Ellucian.Colleague.Domain.Student.csproj") ||
                     file.Contains("Ellucian.Colleague.Dtos.Student.csproj"))
                {
                    //this adds the file name to the list of file names
                    oldModfiles.Add(file);
                }
            }


        }

        // for when the browse button for New un modified file is clicked
        private void buttonBrowseNewUnModFile_Click(object sender, EventArgs e)
        {
            if (ofdAPIFileMerger.ShowDialog(this) == DialogResult.OK)

                textBoxNewUnModFile.Text = ofdAPIFileMerger.SelectedPath;
            //this gets all the .csproj files even from sub directories
            foreach (string file in Directory.EnumerateFiles(ofdAPIFileMerger.SelectedPath,
                    "*.csproj",
                    SearchOption.AllDirectories))
            {

                if (file.Contains("Ellucian.Colleague.Api.Client.csproj") || file.Contains("Ellucian.Colleague.Api.csproj") ||
                        file.Contains("Ellucian.Colleague.Coordination.Student.csproj") || file.Contains("Ellucian.Colleague.Api.csproj") ||
                        file.Contains("Ellucian.Colleague.Data.Student.csproj") || file.Contains("Ellucian.Colleague.Domain.Student.csproj") ||
                        file.Contains("Ellucian.Colleague.Dtos.Student.csproj"))
                {

                    newUnModfiles.Add(file);
                }
            }


        }


        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Disable UI...
            this.Enabled = false;


            //this loop runs till the end of the old un mod file
            for (int i = 0; i < oldUnModfiles.Count; i++)
            {
                string nameOfFile = oldModfiles[i];//for the name of the new mod file
                //to get the file name from each update folder
                string strOldUnModFile = GetFileAsString(oldUnModfiles[i]);
                string strOldModFile = GetFileAsString(oldModfiles[i]);
                string strNewUnModFile = GetFileAsString(newUnModfiles[i]);
                string textOutPutPath = newUnModfiles[i];

                string strOldModFileParsed = strOldModFile.Substring(strOldModFile.IndexOf("<PropertyGroup>"));
                string strOldUnModFileParsed = strOldUnModFile.Substring(strOldUnModFile.IndexOf("<PropertyGroup>"));
                string newNewModFile = strNewUnModFile.Substring(0, strNewUnModFile.IndexOf("2003\">") + 7);

                string strNewUnModFileParsed = strNewUnModFile.Substring(strNewUnModFile.IndexOf("<PropertyGroup>"));

                // this loop runs till the end of the old modified file ends
                while (strOldModFileParsed.Contains(">"))
                {

                    strOldModFileParsed = strOldModFileParsed.Substring(0);
                    strOldUnModFileParsed = strOldUnModFileParsed.Substring(0);
                    strNewUnModFileParsed = strNewUnModFileParsed.Substring(0);

                    string elementPropertiesValue = strOldModFileParsed.Substring(0, strOldModFileParsed.IndexOf(">") + 1);
                    string elementPropertiesValue2 = strOldUnModFileParsed.Substring(0,
                            strOldUnModFileParsed.IndexOf(">") + 1);
                    string elementPropertiesValue3 = strNewUnModFileParsed.Substring(0,
                            strNewUnModFileParsed.IndexOf(">") + 1);

                    //special case because the local host of the updated will be taken from the updated API file
                    if (elementPropertiesValue2.Contains("http://localhost:"))
                    {
                        strOldUnModFileParsed = strOldUnModFileParsed.Substring(strOldUnModFileParsed.IndexOf(">") + 1);
                        strNewUnModFileParsed = strNewUnModFileParsed.Substring(strNewUnModFileParsed.IndexOf(">") + 1);

                    }

                    // if the tag is present in the old modified but not in old unmodified add it to
                    // the new file
                    if (!elementPropertiesValue.Equals(elementPropertiesValue2))
                    {

                        if (!elementPropertiesValue.Contains("http://localhost:"))
                        {

                            newNewModFile = newNewModFile  + elementPropertiesValue;
                        }
                        strOldModFileParsed = strOldModFileParsed.Substring(strOldModFileParsed.IndexOf(">") + 1);

                    }
                    // incase it is present in both we dont need to add it to the new file
                    if (elementPropertiesValue.Equals(elementPropertiesValue2))
                    {
                        newNewModFile = newNewModFile  + elementPropertiesValue3;
                        strOldModFileParsed = strOldModFileParsed.Substring(strOldModFileParsed.IndexOf(">") + 1);
                        strOldUnModFileParsed = strOldUnModFileParsed.Substring(strOldUnModFileParsed.IndexOf(">") + 1);
                        strNewUnModFileParsed = strNewUnModFileParsed.Substring(strNewUnModFileParsed.IndexOf(">") + 1);

                    }

                }

                // GENERATING OUTPUT FILE
                // to allow any remaining tags to be added from the new un modified file
                newNewModFile = newNewModFile  + strNewUnModFileParsed;
                WriteStringToFile(textOutPutPath, newNewModFile);

                //GENERATING NECESSARY CS FILES
                //this adds all the necessary cs files from the old modified into the new modified
                string nameModOfFolder = oldModfiles[i].Substring(0, oldModfiles[i].LastIndexOf("\\Ellucian"));
                string nameUnModOfFolder = oldUnModfiles[i].Substring(0, oldUnModfiles[i].LastIndexOf("\\Ellucian"));

                //this searches all the files from the old  modified version
                foreach (string file in Directory.EnumerateFiles(nameModOfFolder,
                   "*.cs",
                   SearchOption.AllDirectories))
                {

                    string nameFile = file.Substring(file.LastIndexOf("Ellucian"));
                    Boolean isPresent = false;
                    //this compares each file from the files in the old un modified version
                    foreach (string files in Directory.EnumerateFiles(nameUnModOfFolder,
                    "*.cs",
                    SearchOption.AllDirectories))
                    {

                        string nameFile2 = files.Substring(files.LastIndexOf("Ellucian"));
                        //case where it is already present
                        if (nameFile.Equals(nameFile2))
                        {
                            isPresent = true;
                            break;
                        }
                    }
                    //case where it is not present and has been added hence has to be added to the new version
                    if (isPresent == false)
                    {
                        string nameFinal = nameFile.Substring(nameFile.IndexOf("\\"));
                        string nameOfAddedCsFile = nameModOfFolder + "\\" + nameFinal;

                        //this gets the version and if modified or not
                        string getName = nameModOfFolder.Substring(nameModOfFolder.IndexOf("_"));
                        string updateNumber = getName.Substring(0, getName.IndexOf("\\"));
                        string getNameNew = newUnModfiles[i].Substring(newUnModfiles[i].IndexOf("_"));
                        string updateNumberNew = getNameNew.Substring(0, getNameNew.IndexOf("\\"));

                        //this generates the cs file and stores in correct location
                        string strAddedCsFile = GetFileAsString(file);
                        string addedCsFilePath = file.Replace(updateNumber, updateNumberNew);
                        WriteStringToFile(addedCsFilePath, strAddedCsFile);

                    }
                }
                //  return;

            }
            // Re-enable the UI...
            this.Enabled = true;

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }


        private void textBoxOldUnModFile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}