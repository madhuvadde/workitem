using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;

namespace WorkItemAllChangedHistory
{
    public partial class WorkItemHistory : Form
    {
        private TfsTeamProjectCollection projectCollection;
        private WorkItemStore workItemStore;
        private WorkItemStore service;
        WorkItem workItem = null;

        public WorkItemHistory()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectToTFS();
        }
        private void ConnectToTFS()
        {
            try
            {
                projectCollection =
                TfsTeamProjectCollectionFactory.GetTeamProjectCollection(
                    new Uri(txtTFSURL.Text));
                service = projectCollection.GetService<WorkItemStore>();
                if (service != null)
                {
                    btnWorkItemId.Enabled = true;
                    workItemStore = projectCollection.GetService<WorkItemStore>();
                    MessageBox.Show("TFS connected successfully");
                }
               
            }
            catch (Exception Ex)
            {
                btnWorkItemId.Enabled = false;
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }

        private void btnWorkItemId_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtWorkItemId.Text != "")
                {
                    workItem = workItemStore.GetWorkItem(Convert.ToInt32(txtWorkItemId.Text.Trim()));
                    GetAllChanges();
                    btnExportToExcel.Enabled = true;
                }
            }
            catch (Exception Ex)
            {
                txtWorkItemId.Text = "";
                MessageBox.Show("Error in fetching entered Workitem Id:" + Ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void GetAllChanges()
        {
            if (workItem != null)
            {
                string strOldValue, strNewValue;
                gvAllChanges.Rows.Clear();

                List<int> LinkedWorkItems = new List<int>();
                List<Hyperlink> hyperLinkColl = new List<Hyperlink>();
                List<ExternalLink> externalLinkColl = new List<ExternalLink>();

                if (workItem.HyperLinkCount > 0)
                {
                    foreach (Link link in workItem.Links)
                    {
                        if (link.BaseType.ToString() == "Hyperlink")
                        {
                            hyperLinkColl.Add((Hyperlink)link);

                        }
                    }
                }
                if (workItem.ExternalLinkCount > 0)
                {
                    foreach (Link link in workItem.Links)
                    {
                        if (link.BaseType.ToString() == "ExternalLink")
                            externalLinkColl.Add((ExternalLink)link);
                    }
                }

                for (int i = 1; i < workItem.Revisions.Count; i++)
                {
                    
                    foreach (Field field in workItem.Revisions[i].Fields)
                    {
                        if (field.Name != "Rev" && field.Name != "Changed By" && field.Name != "Revised Date" && field.Name != "Watermark" && field.Name != "Changed Date" &&
                            field.Name != "Hyperlink Count" && field.Name != "Related Link Count" && field.Name != "Attached File Count" && field.Name != "External Link Count" &&
                             field.Name != "Authorized As" && field.Name != "Authorized Date") //Skip some Obvious fields) 
                        {
                            if (field.Name == "History")
                            {
                                if (field.Value.ToString().Trim() != "")
                                gvAllChanges.Rows.Add(workItem.Revisions[i].Fields["Changed By"].Value.ToString(), Convert.ToDateTime(workItem.Revisions[i].Fields["Changed Date"].Value), field.Name, "", "", field.Value.ToString());
                            }
                            else
                            {
                                strOldValue = (workItem.Revisions[i - 1].Fields[field.Name].Value ?? "").ToString();
                                strNewValue = (field.Value ?? "").ToString();
                                if (strOldValue != strNewValue)
                                {
                                    gvAllChanges.Rows.Add(workItem.Revisions[i].Fields["Changed By"].Value.ToString(), Convert.ToDateTime(workItem.Revisions[i].Fields["Changed Date"].Value), field.Name, strOldValue, strNewValue, "");
                                }
                            }
                        }
                    }
                
                    //Attachments
                    int prevCount = Convert.ToInt32(workItem.Revisions[i - 1].Fields["Attached File Count"].Value);
                    int currCount = Convert.ToInt32(workItem.Revisions[i].Fields["Attached File Count"].Value);
                    if (currCount > prevCount)
                    {
                        AttachmentCollection attachementColl = workItem.Attachments;

                        for (int j = prevCount; j < (attachementColl.Count - (attachementColl.Count - currCount)); j++)
                        {
                            string attch = attachementColl[j].Name;
                            attch =  attch.Replace("Trinidad","Test");
                            gvAllChanges.Rows.Add(workItem.Revisions[i].Fields["Changed By"].Value.ToString(), Convert.ToDateTime(attachementColl[j].AttachedTime), "Attachment", "", attachementColl[j].Name, attachementColl[j].Comment);
                            
                        }

                    }
                    //Hyperlinks
                    if (workItem.HyperLinkCount > 0)
                    {

                        //Hyperlinks
                        prevCount = Convert.ToInt32(workItem.Revisions[i - 1].Fields["Hyperlink Count"].Value);
                        currCount = Convert.ToInt32(workItem.Revisions[i].Fields["Hyperlink Count"].Value);

                        if (currCount > prevCount)
                        {


                            for (int j = prevCount; j < (hyperLinkColl.Count - (hyperLinkColl.Count - currCount)); j++)
                            {
                                gvAllChanges.Rows.Add(workItem.Revisions[i].Fields["Changed By"].Value.ToString(), Convert.ToDateTime(workItem.Revisions[i].Fields["Changed Date"].Value), "Hyperlink", "", hyperLinkColl[j].Location, hyperLinkColl[j].Comment);
                            }

                        }
                    }

                    //External Links

                    if (workItem.ExternalLinkCount > 0)
                    {

                        //Hyperlinks
                        prevCount = Convert.ToInt32(workItem.Revisions[i - 1].Fields["External Link Count"].Value);
                        currCount = Convert.ToInt32(workItem.Revisions[i].Fields["External Link Count"].Value);

                        if (currCount > prevCount)
                        {
                            for (int j = prevCount; j < (externalLinkColl.Count - (externalLinkColl.Count - currCount)); j++)
                            {
                               gvAllChanges.Rows.Add(workItem.Revisions[i].Fields["Changed By"].Value.ToString(), Convert.ToDateTime(workItem.Revisions[i].Fields["Changed Date"].Value), "External Link", "", externalLinkColl[j].ArtifactLinkType.Name + ":" + externalLinkColl[j].LinkedArtifactUri, externalLinkColl[j].Comment);
                               
                            }

                        }
                    }

                }


                //Links
                foreach (WorkItemLink link in workItem.WorkItemLinkHistory)
                {
                    //Added Links
                    gvAllChanges.Rows.Add(link.AddedBy, Convert.ToDateTime(link.AddedDate), "WorkItem Link Added", "", "WorkItem " + link.TargetId + " (" + link.LinkTypeEnd.Name + ")", link.Comment);
                    //Deleted Links
                    if (link.RemovedBy != "" && link.RemovedBy != "TFS Everyone")
                        gvAllChanges.Rows.Add(link.RemovedBy, Convert.ToDateTime(link.RemovedDate), "WorkItem Link Deleted", "", "WorkItem " + link.TargetId + " (" + link.LinkTypeEnd.Name + ")", link.Comment);
                    
                }
            }

            
           

            gvAllChanges.Sort(this.gvAllChanges.Columns["ChangedDateAllChanges"], ListSortDirection.Descending);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application

                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);

                // creating new Excelsheet in workbook
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

                // get the reference of first sheet. By default its name is Sheet1.
                // store its reference to worksheet

                //Linked WorkItem
                worksheet = workbook.Sheets["Sheet1"];

                worksheet = workbook.ActiveSheet;
                //Formatting
                worksheet.Rows.RowHeight = 12;
                worksheet.Rows[1].RowHeight = 14;

                worksheet.Name = "All Changes";

                //worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, 20]].Merge();
                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[100, 2]].EntireColumn.ColumnWidth = 20;
                worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[100, 2]].EntireColumn.WrapText = true;
                worksheet.Range[worksheet.Cells[1, 2], worksheet.Cells[100, 3]].EntireColumn.ColumnWidth = 20;
                worksheet.Range[worksheet.Cells[1, 2], worksheet.Cells[100, 3]].EntireColumn.WrapText = true;
                worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[100, 4]].EntireColumn.ColumnWidth = 20;
                worksheet.Range[worksheet.Cells[1, 3], worksheet.Cells[100, 4]].EntireColumn.WrapText = true;
                worksheet.Range[worksheet.Cells[1, 4], worksheet.Cells[100, 5]].EntireColumn.ColumnWidth = 45;
                worksheet.Range[worksheet.Cells[1, 4], worksheet.Cells[100, 5]].EntireColumn.WrapText = true;
                worksheet.Range[worksheet.Cells[1, 5], worksheet.Cells[100, 6]].EntireColumn.ColumnWidth = 45;
                worksheet.Range[worksheet.Cells[1, 5], worksheet.Cells[100, 6]].EntireColumn.WrapText = true;
                worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[100, 7]].EntireColumn.ColumnWidth = 45;
                worksheet.Range[worksheet.Cells[1, 6], worksheet.Cells[100, 7]].EntireColumn.WrapText = true;
                worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[3, 6]].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
                Microsoft.Office.Interop.Excel.Borders borders = worksheet.Range[worksheet.Cells[3, 1], worksheet.Cells[gvAllChanges.RowCount + 2, 6]].Borders;
                borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders.Weight = 2d;
                WriteToExcelSheet(worksheet, gvAllChanges);

                string path = @"D:\WorkItemHistory";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                workbook.SaveAs(path + "\\" + workItem.Id + "_WorkItemHistory_" + DateTime.Now.ToString("MMddyyyy"), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing);

                app.Visible = true;

            }
            catch (Exception Ex)
            {
                 MessageBox.Show("Error occured in exporting:" + Ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void WriteToExcelSheet(Microsoft.Office.Interop.Excel._Worksheet worksheet, DataGridView gridView)
        {
            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();
            // storing header part in Excel
            for (int i = 1; i < gridView.Columns.Count + 1; i++)
            {
                worksheet.Cells[3, i] = gridView.Columns[i - 1].HeaderText;
                worksheet.Cells[3, i].Font.Bold = true;
            }
            // storing Each row and column value to excel sheet
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                for (int j = 0; j < gridView.Columns.Count; j++)
                {
                    worksheet.Cells[i + 4, j + 1] = gridView.Rows[i].Cells[j].Value;

                }
            }
        }

       

    }
}
