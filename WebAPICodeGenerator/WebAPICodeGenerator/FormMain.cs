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

namespace WebAPICodeGenerator
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

        private void buttonBrowseDataContract_Click(object sender, EventArgs e)
        {
            if (ofdDataContract.ShowDialog(this) == DialogResult.OK)
                textBoxDataContract.Text = ofdDataContract.FileName;
        }

        private void buttonBrowseOutputPath_Click(object sender, EventArgs e)
        {
            if (fbdOutput.ShowDialog(this) == DialogResult.OK)
                textBoxOutputPath.Text = fbdOutput.SelectedPath;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            // Disable UI...
            this.Enabled = false;
            //MOMAL
            //Counter to check if it is a get or set file
            int getCounter = 0;
            int updateCounter = 0;

            // Open data contract file for reading...
            string strDataContract = GetFileAsString(textBoxDataContract.Text);
            // Determine the transaction name based on the filename...
            string strTransactionName = Path.GetFileNameWithoutExtension(textBoxDataContract.Text);
            // Generate "Record" file...

            string strRecordFileName = strTransactionName + "Record";
            // Load transaction record template...
            string strTransactionRecordTemplate = GetFileAsString(".\\templates\\TransactionRecord.txt");
            // Parse the data contract...
            string strTransactionRecordOutput = strTransactionRecordTemplate.Replace("{Transaction}", strTransactionName);
            // Scan the data contract and extract the properties...
            string strTransactionPropertiesParsed = strDataContract.Substring(strDataContract.IndexOf("[SctrqDataMember("));


            strTransactionPropertiesParsed = strTransactionPropertiesParsed.Substring(strTransactionPropertiesParsed.IndexOf("]") + 1);
            string strTransactionProperties = strTransactionPropertiesParsed.Substring(0, strTransactionPropertiesParsed.IndexOf("}") + 1);

            StringBuilder strData = new StringBuilder();
            string comment = "\n         /// <summary>\n         /// Data \n        /// </summary> \n ";
            strData.Append(comment);
            strData.Append(strTransactionProperties);

            //strMethods = strReqPropertiesParsed.Substring(strReqPropertiesParsed.IndexOf("]") + 1, strReqPropertiesParsed.IndexOf("}") + 1);
            //Console.WriteLine(strMethods);
       
            while (strTransactionPropertiesParsed.Contains("[SctrqDataMember("))
            {
                strTransactionPropertiesParsed = strTransactionPropertiesParsed.Substring(strTransactionPropertiesParsed.IndexOf("[SctrqDataMember("));
                strTransactionPropertiesParsed = strTransactionPropertiesParsed.Substring(strTransactionPropertiesParsed.IndexOf("]") + 1);
                strData.Append(comment);
                strData.Append(strTransactionPropertiesParsed.Substring(0, strTransactionPropertiesParsed.IndexOf("}") + 1));
                strTransactionProperties += strTransactionPropertiesParsed.Substring(0, strTransactionPropertiesParsed.IndexOf("}") + 1);
            }
            // Generate output...
            strTransactionRecordOutput = strTransactionRecordOutput.Replace("AUTO-PROPERTIES", strTransactionProperties);

            //Get file for DTO
            //Generate strDto file
            string strDtofileName = strTransactionName + "Dto";
            //Load transaction adapter template
            string strTransactionDtoTemplate = GetFileAsString(".\\templates\\TransactionDto.txt");
            // Parse the data contract...
            string strTransactionDtoOutput = strTransactionDtoTemplate.Replace("{Transaction}", strTransactionName);
            strTransactionDtoOutput = strTransactionDtoOutput.Replace("{DATA}", strData.ToString());



            // TODO: Generate files for repository, DTO, adapter, and controller.  Also modify "RouteConfig" and "ColleagueApiClient".




            //Transaction Adapter

            //Generate strAdapter file
            string strAdapterFileName = strTransactionName + "Adapter";
            //Load transaction adapter template
            string strTransactionAdapterTemplate = GetFileAsString(".\\templates\\TransactionAdapter.txt");
            // Parse the data contract...
            string strTransactionAdapterOutput = strTransactionAdapterTemplate.Replace("{Transaction}", strTransactionName);

           

           //Generate repository interface
            string strInterfaceRepositoryFileName = "I" + strTransactionName + "Repository";
            //Load transaction interface repository template
            string strTransactionGetRepositoryInterfaceTemplate = GetFileAsString(".\\templates\\TransactionIRepository.txt");
            string strTransactionUpdateRepositoryInterfaceTemplate = GetFileAsString(".\\templates\\UpdateTransactionIRepository.txt");

            

            // Parse the data contract...
            string strTransactionInterfaceReposOutput = strTransactionGetRepositoryInterfaceTemplate.Replace("{Transaction}", strTransactionName);
            // Parse the data contract...
            string strUpdateTransactionInterfaceReposOutput = strTransactionUpdateRepositoryInterfaceTemplate.Replace("{Transaction}", strTransactionName);

          


            //Generate repository file
            string strRepositoryFileName = strTransactionName + "Repository";
            //Load transaction  template
            string strTransactionRepositoryTemplate = GetFileAsString(".\\templates\\TransactionRepository.txt");
            string strUpdateTransactionRepositoryTemplate = GetFileAsString(".\\templates\\TransactionUpdateRepository.txt");


            // Parse the data contract... For Repository
            string strGetTransactionReposOutput = strTransactionRepositoryTemplate.Replace("{Transaction}", strTransactionName);
            string strUpdateTransactionReposOutput = strUpdateTransactionRepositoryTemplate.Replace("{Transaction}", strTransactionName);
            string response = "response";
            string updateRecordObject = "inUpdateXphaStudentRecord";
            strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("{RESPONSE}", response);
            strUpdateTransactionReposOutput = strUpdateTransactionReposOutput.Replace("{updateRecordObject}", updateRecordObject);

            //Parsing request for properties
            // Scan the data contract and extract the properties...
            //string strMethods = null;
            string strReqPropertiesParsed = null;
            string strReqUpdatePropertiesParsed = null;
            string strRequestProperties = "";
            string strRequestFields = "";
            if (strDataContract.Contains("InBoundData = true)"))
            {
                strReqPropertiesParsed = strDataContract.Substring(strDataContract.IndexOf("InBoundData = true)"));
               
                
                strReqPropertiesParsed = strReqPropertiesParsed.Substring(strReqPropertiesParsed.IndexOf("c") + 1);
                 strRequestProperties = strReqPropertiesParsed.Substring(0, strReqPropertiesParsed.IndexOf("{") - 1);
                 
                 strRequestFields = strRequestProperties.Trim().Split(' ')[1];
                 strReqUpdatePropertiesParsed = "            request." + strRequestProperties.Trim().Split(' ')[1] + " = " + "inUpdateXphaStudentRecord." + strRequestProperties.Trim().Split(' ')[1] + ";" + "\r\n";
                string strRequestSetProperties = "            request." + strRequestProperties.Trim().Split(' ')[1] + " = " + strRequestProperties.Trim().Split(' ')[1] + ";" + "\r\n";
                string strRequestRecordSetProperties = "            returnRec." + strRequestProperties.Trim().Split(' ')[1] + " = " + strRequestProperties.Trim().Split(' ')[1] + ";" + "\r\n";

              

                while (strReqPropertiesParsed.Contains("InBoundData = true)"))
                {
                    strReqPropertiesParsed = strReqPropertiesParsed.Substring(strReqPropertiesParsed.IndexOf("InBoundData = true)"));
                    strReqPropertiesParsed = strReqPropertiesParsed.Substring(strReqPropertiesParsed.IndexOf("c") + 1);
                    string strNextProp = strReqPropertiesParsed.Substring(0, strReqPropertiesParsed.IndexOf("{") - 1);
                 
                    strRequestProperties += "," + strNextProp;
                    strNextProp = strNextProp.Trim().Split(' ')[1];
                    strRequestFields += "," + strNextProp;
                    strReqUpdatePropertiesParsed += "            request." + strNextProp + " = " + "inUpdateXphaStudentRecord." + strNextProp + ";" + "\r\n";
                    strRequestSetProperties += "            request." + strNextProp + " = " + strNextProp + ";" + "\r\n";
                    strRequestRecordSetProperties += "            returnRec." + strNextProp + " = " + strNextProp + ";" + "\r\n";

                    updateCounter++;
                }

          

                strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("{REQUEST-FIELDS}", strRequestProperties);
                strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("REQUEST-PROPERTIES", strRequestSetProperties);
                strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("REQ-RECORD PROPERTIES", strRequestRecordSetProperties);
                strUpdateTransactionReposOutput = strUpdateTransactionReposOutput.Replace("SET-REQUEST-PROPERTIES", strReqUpdatePropertiesParsed);

            }
            else {
                strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("{REQUEST-FIELDS}", strRequestProperties);
                strUpdateTransactionReposOutput = strUpdateTransactionReposOutput.Replace("SET-REQUEST-PROPERTIES", "");
                strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("REQUEST-PROPERTIES", "");
                strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("REQ-RECORD PROPERTIES","");
            
            }

            string strRecordPropertiesParsed = strDataContract.Substring(strDataContract.IndexOf("OutBoundData = true)]"));
            strRecordPropertiesParsed = strRecordPropertiesParsed.Substring(strRecordPropertiesParsed.IndexOf("c") + 1);
            string strRecordReqProperties = strRecordPropertiesParsed.Substring(0, strRecordPropertiesParsed.IndexOf("{") - 1);
            string strRecordSetProperties = "            returnRec." + strRecordReqProperties.Trim().Split(' ')[1] + " = response." + strRecordReqProperties.Trim().Split(' ')[1] + ";" + "\r\n";


            while (strRecordPropertiesParsed.Contains("OutBoundData = true)]"))
            {
                strRecordPropertiesParsed = strRecordPropertiesParsed.Substring(strRecordPropertiesParsed.IndexOf("OutBoundData = true)]"));
                strRecordPropertiesParsed = strRecordPropertiesParsed.Substring(strRecordPropertiesParsed.IndexOf("c") + 1);
                string strRecordNextProp = strRecordPropertiesParsed.Substring(0, strRecordPropertiesParsed.IndexOf("{") - 1);

                strRecordNextProp = strRecordNextProp.Trim().Split(' ')[1];
                strRecordSetProperties += "            returnRec." + strRecordNextProp + " = response." + strRecordNextProp + ";" + "\r\n";

                getCounter++;
            }

            strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("SET-PROPERTIES", strRecordSetProperties);
            string transactionName = strTransactionName.Substring(strTransactionName.IndexOf("x") + 1);
            strGetTransactionReposOutput = strGetTransactionReposOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);
            strUpdateTransactionReposOutput = strUpdateTransactionReposOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);
            //for update repository interface
            strUpdateTransactionInterfaceReposOutput = strUpdateTransactionInterfaceReposOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);
         

            //Generate Controller file
            string strControllerFileName = strTransactionName + "Controller";
            //Load transaction  template
            string strGetTransactionControllerTemplate = GetFileAsString(".\\templates\\TransactionController.txt");
             string strUpdateTransactionControllerTemplate = GetFileAsString(".\\templates\\TransactionUpdateController.txt");

           



            // Parse the data contract...
            string strTransactionControllerOutput = strGetTransactionControllerTemplate.Replace("{Transaction}", strTransactionName);
            string strUpdateTransactionControllerOutput = strUpdateTransactionControllerTemplate.Replace("{Transaction}", strTransactionName);

            if (strDataContract.Contains("InBoundData = true)"))
            {

                strTransactionControllerOutput = strTransactionControllerOutput.Replace("{REQUEST-FIELDS}", strRequestProperties);
            }
            else {
                strTransactionControllerOutput = strTransactionControllerOutput.Replace("{REQUEST-FIELDS}", "");
            }

            //set the method name according to transaction name
            strTransactionControllerOutput = strTransactionControllerOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);

            strUpdateTransactionControllerOutput = strUpdateTransactionControllerOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);

            strTransactionControllerOutput = strTransactionControllerOutput.Replace("{FIELDS}", strRequestFields);


            //Set the colleague Id as get or set {ColleagueId} 
            string strColleagueIdParsed = strDataContract.Substring(strDataContract.IndexOf("ColleagueId = "));
            strColleagueIdParsed = strColleagueIdParsed.Substring(strColleagueIdParsed.IndexOf("=") + 1);
            string strColleagueId = strColleagueIdParsed.Substring(1, strColleagueIdParsed.IndexOf(",") - 1);

            //Determine if it is get file or set file
            string getOrSet = strColleagueIdParsed.Substring(strColleagueIdParsed.IndexOf("X.") + 2);
            getOrSet = getOrSet.Substring(0, getOrSet.IndexOf("T") + 1);


            strTransactionControllerOutput = strTransactionControllerOutput.Replace("{Get/Update}", getOrSet);
            strTransactionControllerOutput = strTransactionControllerOutput.Replace("{ColleagueId}", strColleagueId);

            strUpdateTransactionControllerOutput = strUpdateTransactionControllerOutput.Replace("{ColleagueId}", strColleagueId);

          


            //Generate ColleagueClientApiGet

            //NOT SURE ABOUT THE FILE NAME
            //Generate Controller file
            string strColleagueApiClientFileName = "ColleagueApiClient.MHC";
            //Load transaction  template
            string strColleagueApiClientTemplate = GetFileAsString(".\\templates\\TransactionGetColleagueApiClient.txt");



            // Parse the data contract...
            string strColleagueApiClientOutput = strColleagueApiClientTemplate.Replace("{Transaction}", strTransactionName);

            if (strDataContract.Contains("InBoundData = true)"))
            {

                strColleagueApiClientOutput = strColleagueApiClientOutput.Replace("{REQUEST-FIELDS}", strRequestProperties);
            }
            else
            {
                strColleagueApiClientOutput = strColleagueApiClientOutput.Replace("{REQUEST-FIELDS}", "");
            }

            //set the method name according to transaction name
            strColleagueApiClientOutput = strColleagueApiClientOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);

            string lowerCaseTransactionName = transactionName.ToLower();

             //set the method name according to transaction name
            strColleagueApiClientOutput = strColleagueApiClientOutput.Replace("{lower-case-get/update-transaction}", lowerCaseTransactionName);

  
            //Load transaction  template
            string strColleagueApiClientTemplateUpdate = GetFileAsString(".\\templates\\TransactionUpdateColleagueApiClient.txt");


            string strColleagueApiClientOutputUpdate = strColleagueApiClientTemplateUpdate.Replace("{Transaction}", strTransactionName);


            //set the method name according to transaction name
            strColleagueApiClientOutputUpdate = strColleagueApiClientOutputUpdate.Replace("{GET/UPDATE_TRANSACTION}", transactionName);


            //set the method name according to transaction name
            strColleagueApiClientOutputUpdate = strColleagueApiClientOutputUpdate.Replace("{lower-case-get/update-transaction}", lowerCaseTransactionName);
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///route config for get
            string strGetRouteConfigFileName = "GetRouteConfig";
            //Load transaction  template
            string strGetRouteConfigTemplate = GetFileAsString(".\\templates\\GetRouteConfig.txt");
            // Parse the data contract...
            string strGetRouteConfigOutput = strGetRouteConfigTemplate.Replace("{Transaction}", strTransactionName);
            //set the method name according to transaction name
            strGetRouteConfigOutput = strGetRouteConfigOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);
            //set the method name according to transaction name
            strGetRouteConfigOutput = strGetRouteConfigOutput.Replace("{lower-case-get/update-transaction}", lowerCaseTransactionName);
            strGetRouteConfigOutput = strGetRouteConfigOutput.Replace("{CAPS-Get/Update}", getOrSet.ToUpper());




            ///route config for update
            string strUpdateRouteConfigFileName = "UpdateRouteConfig";
            //Load transaction  template
            string strUpdateRouteConfigTemplate = GetFileAsString(".\\templates\\updateRouteConfig.txt");
            // Parse the data contract...
            string strUpdateRouteConfigOutput = strUpdateRouteConfigTemplate.Replace("{Transaction}", strTransactionName);
            //set the method name according to transaction name
            strUpdateRouteConfigOutput = strUpdateRouteConfigOutput.Replace("{GET/UPDATE_TRANSACTION}", transactionName);
            //set the method name according to transaction name
            strUpdateRouteConfigOutput = strUpdateRouteConfigOutput.Replace("{lower-case-get/update-transaction}", lowerCaseTransactionName);
            strUpdateRouteConfigOutput = strUpdateRouteConfigOutput.Replace("{CAPS-Get/Update}", "POST");









            //it's a get file
            if (getCounter >= updateCounter)
            {
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strRecordFileName + ".cs", strTransactionRecordOutput);
                //Generate Controller output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strControllerFileName + ".cs", strTransactionControllerOutput);
                //Generate Adapter output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strRepositoryFileName + ".cs", strGetTransactionReposOutput);
                //Generate Respository interface output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strInterfaceRepositoryFileName + ".cs", strTransactionInterfaceReposOutput);
                //Generate Adapter output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strAdapterFileName + ".cs", strTransactionAdapterOutput);
                //Generate DTO output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strDtofileName + ".cs", strTransactionDtoOutput);
                //Generate Colleague Api Client
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strColleagueApiClientFileName + "GetMethod.cs", strColleagueApiClientOutput);

                //Generate Route Config Get 
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strGetRouteConfigFileName + ".cs", strGetRouteConfigOutput);

            }
            else { 
                //update record file
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strRecordFileName + ".cs", strTransactionRecordOutput);
                  //Generate Respository interface output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strInterfaceRepositoryFileName + ".cs", strUpdateTransactionInterfaceReposOutput);
                //update repos
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strRepositoryFileName + ".cs", strUpdateTransactionReposOutput );
                //Generate Controller output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strControllerFileName + ".cs", strUpdateTransactionControllerOutput);

                //Generate Adapter output
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strAdapterFileName + ".cs", strTransactionAdapterOutput);
                //Generate Colleague Api Client
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strColleagueApiClientFileName + "UpdateMethod.cs", strColleagueApiClientOutputUpdate);

                //Generate Route Config update
                WriteStringToFile(textBoxOutputPath.Text + "\\" + strUpdateRouteConfigFileName + ".cs", strUpdateRouteConfigOutput);
            }
         
        

            //Re-enable the UI...
            this.Enabled = true;
        }
    }
}
