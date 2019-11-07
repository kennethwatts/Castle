using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteMapUpdater
{
    public partial class FormMain : Form
    {
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

        private void buttonBrowseSiteMapOld_Click(object sender, EventArgs e)
        {
            if (ofdSiteMapUpdater.ShowDialog(this) == DialogResult.OK)
                textBoxSiteMapOld.Text = ofdSiteMapUpdater.FileName;
        }

        private void buttonBrowseSiteMapNew_Click(object sender, EventArgs e)
        {
            if (ofdSiteMapUpdater.ShowDialog(this) == DialogResult.OK)
                textBoxSiteMapNew.Text = ofdSiteMapUpdater.FileName;
        }


        private void buttonBrowseOutputPath_Click(object sender, EventArgs e)
        {
            if (fbdOutput.ShowDialog(this) == DialogResult.OK)
                textBoxOutputPath.Text = fbdOutput.SelectedPath;
        }

        private void buttonBrowseOutputPathOld_Click(object sender, EventArgs e)
        {
            if (fbdOutput.ShowDialog(this) == DialogResult.OK)
                textBoxOutputPath.Text = fbdOutput.SelectedPath;
        }



        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Disable UI...
            this.Enabled = false;

         

           //OLD FILE
            string strOldSiteFile = GetFileAsString(textBoxSiteMapOld.Text);
            // Scan the data contract and extract the properties...
           
            string strPropertiesParsed = strOldSiteFile.Substring(strOldSiteFile.IndexOf("<page id="));
            string elementPropertiesValue = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("/") + 2)+"\n";
            strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf("=") + 2);
            string elementPropertiesKey1 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));

            SiteMapElement element = new SiteMapElement();
            element.text.Add(elementPropertiesKey1, elementPropertiesValue);

            while (strPropertiesParsed.Contains("<page id="))
            {
                strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf("<page id="));
                string elementPropertiesValue2 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("  <page id=") + 2);
                strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf("=") + 2);
                string elementPropertiesKey2 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));
                element.text.Add(elementPropertiesKey2, elementPropertiesValue2);
            }


            string elementPropertiesValue5 = " <page id=" + "\"" + strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("  </pages>") + 2);
            string elementPropertiesKey5 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));

            if (element.text.ContainsKey(elementPropertiesKey5))
            {
                element.text[elementPropertiesKey5] = elementPropertiesValue5;
            }

          

            //for sub menu
            SiteMapElement element2 = new SiteMapElement();
            while (strPropertiesParsed.Contains(" <submenu id="))
            {
                strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf(" <submenu id="));
                string elementPropertiesValue3 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("   <submenu id=") + 2);
                strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf("=") + 2);
                string elementPropertiesKey3 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));
                element2.text.Add(elementPropertiesKey3, elementPropertiesValue3);
            }

            string elementPropertiesValue6 = " <submenu id=" + "\"" + strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("  <menu id=") + 2);
            string elementPropertiesKey6 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));

            if (element2.text.ContainsKey(elementPropertiesKey6))
            {
                element2.text[elementPropertiesKey6] = elementPropertiesValue6;
            }
          

            //for menu
            SiteMapElement element3 = new SiteMapElement();
            while (strPropertiesParsed.Contains(" <menu id="))
            {
                strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf(" <menu id="));
                string elementPropertiesValue4 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("   <menu id=") + 2);
                strPropertiesParsed = strPropertiesParsed.Substring(strPropertiesParsed.IndexOf("=") + 2);
                string elementPropertiesKey4 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));
                element3.text.Add(elementPropertiesKey4, elementPropertiesValue4);
            }

            string elementPropertiesValue7 = " <menu id=" + "\"" + strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("  </menus>") + 2);
            string elementPropertiesKey7 = strPropertiesParsed.Substring(0, strPropertiesParsed.IndexOf("\""));
            Console.WriteLine(elementPropertiesKey7);
           
            if (element3.text.ContainsKey(elementPropertiesKey7))
           {
                 element3.text[elementPropertiesKey7] = elementPropertiesValue7;
            }


           //NEW FILE


            string strNewSiteFile = GetFileAsString(textBoxSiteMapNew.Text);
            // Scan the data contract and extract the properties...

            string strPropertiesParsedNew = strNewSiteFile.Substring(strNewSiteFile.IndexOf("<page id="));
            string elementNewPropertiesValue = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("/") + 2)+"\n";
            strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf("=") + 2);
            string elementNewPropertiesKey1 = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("\""));
           
            SiteMapElement elementNew = new SiteMapElement();
            elementNew.text.Add(elementNewPropertiesKey1, elementNewPropertiesValue);

            while (strPropertiesParsedNew.Contains("<page id="))
            {
                strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf("<page id="));
                string elementNewPropertiesValue2 = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("  <page id=") + 2);
                strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf("=") + 2);
                string elementNewPropertiesKey2 = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("\""));
                elementNew.text.Add(elementNewPropertiesKey2, elementNewPropertiesValue2);
            }


            //for sub menu
            SiteMapElement elementNew2 = new SiteMapElement();
            while (strPropertiesParsedNew.Contains(" <submenu id="))
            {
                strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf(" <submenu id="));
                string elementNewPropertiesValue3 = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("   <submenu id=") + 2);
                strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf("=") + 2);
                string elementNewPropertiesKey3 = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("\""));
                elementNew2.text.Add(elementNewPropertiesKey3, elementNewPropertiesValue3);
            }
           
            //for menu
            SiteMapElement elementNew3 = new SiteMapElement();
            while (strPropertiesParsedNew.Contains(" <menu id="))
            {
                strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf(" <menu id="));
                string elementNewPropertiesValue4 = strPropertiesParsedNew.Substring(0, strPropertiesParsedNew.IndexOf("   <menu id=") + 2);
                strPropertiesParsedNew = strPropertiesParsedNew.Substring(strPropertiesParsedNew.IndexOf("=") + 2);
                string elementNewPropertiesKey4 = strPropertiesParsedNew.Substring(0, strPropertiesParsed.IndexOf("\""));
                elementNew3.text.Add(elementNewPropertiesKey4, elementNewPropertiesValue4);
            }
           


           
            SiteMapElement elementFinal = new SiteMapElement();


            //adds all the keys in the old file to new created file
            foreach (KeyValuePair<string, string> pair in element.text)
            {
                elementFinal.text.Add(pair.Key, pair.Value);
            }

          

            //then we compare old to new first for page ID
            foreach (KeyValuePair<string, string> pair1 in elementNew.text)
            {
                Boolean newElement = false;
                foreach (KeyValuePair<string, string> pair2 in elementFinal.text)
                {
                    if (pair1.Key.Equals(pair2.Key))
                    {
                        newElement = true;
                    }
                 
                }
                if (newElement == false)
                { 
                    elementFinal.text.Add(pair1.Key, pair1.Value);
                }
            }


            

            //for sub menu
            SiteMapElement elementFinal2 = new SiteMapElement();

            foreach (KeyValuePair<string, string> pair in element2.text)
            {
                elementFinal2.text.Add(pair.Key, pair.Value);
            }

            foreach (KeyValuePair<string, string> pair1 in elementNew2.text)
            {
                Boolean newElement = false;
                foreach (KeyValuePair<string, string> pair2 in element2.text)
                {
                    if (pair1.Key.Equals(pair2.Key))
                    {

                        newElement = true;
                    }
                }
                if (newElement == false)
                {
                    elementFinal2.text.Add(pair1.Key, pair1.Value);
                }
            }



            //for menu
            SiteMapElement elementFinal3 = new SiteMapElement();

            foreach (KeyValuePair<string, string> pair in element3.text)
            {
                elementFinal3.text.Add(pair.Key, pair.Value);
            }


            foreach (KeyValuePair<string, string> pair1 in elementNew3.text)
            {
                Boolean newElement = false;
                foreach (KeyValuePair<string, string> pair2 in element3.text)
                {
                    if (pair1.Key.Equals(pair2.Key))
                    {

                        newElement = true;
                    }
                }
                if (newElement == false)
                {
                    elementFinal3.text.Add(pair1.Key, pair1.Value);
                }
            }

            //String for new file
            String newUpdatedFile = strOldSiteFile.Substring(0, strOldSiteFile.IndexOf(" <page id=") + 1);


            //to add to the string which will create the new updated version

            foreach (KeyValuePair<string, string> pair in elementFinal.text)
            {
                newUpdatedFile = newUpdatedFile + pair.Value;
            }

            newUpdatedFile = newUpdatedFile+"  </pages>\n  <submenus>\n";

            foreach (KeyValuePair<string, string> pair in elementFinal2.text)
            {
                newUpdatedFile = newUpdatedFile + pair.Value;
            }


            foreach (KeyValuePair<string, string> pair in elementFinal3.text)
            {
                newUpdatedFile = newUpdatedFile + pair.Value; 
            }




            newUpdatedFile = newUpdatedFile + "  </menus>\n  </site>";
            //GENERATING OUTPUT FILE
            string updateSiteMap = "UpdatedSiteMap";
            WriteStringToFile(textBoxOutputPath.Text + "\\" + updateSiteMap + ".config", newUpdatedFile);


            //Re-enable the UI...
            this.Enabled = true;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }

    public class SiteMapElement
    {
        public string pageID;
        public string Text;
        public bool bNewElement;
        public Dictionary<string, string> text = new Dictionary<string, string>();

    }
}
