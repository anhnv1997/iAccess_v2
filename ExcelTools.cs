using DocumentFormat.OpenXml.Spreadsheet;
using iAccess;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolReport
{
    public class ExcelTools
    {
        public static SLStyle CreateAlignCenterStyle(SLDocument sl)
        {
            SLStyle textCenterStyle = sl.CreateStyle();
            textCenterStyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
            textCenterStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            return textCenterStyle;
        }
        public static SLStyle CreateTableHeaderStyle(SLDocument sl)
        {
            SLStyle tableHeaderStyle = sl.CreateStyle();
            tableHeaderStyle.Font.Bold = true;
            tableHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            tableHeaderStyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
            return tableHeaderStyle;
        }
        public static SLStyle CreateAllBorderStyle(SLDocument sl)
        {
            SLStyle allBorderStyle = sl.CreateStyle();
            allBorderStyle.Border.BottomBorder.BorderStyle = BorderStyleValues.Thin;
            allBorderStyle.Border.RightBorder.BorderStyle = BorderStyleValues.Thin;
            allBorderStyle.Border.LeftBorder.BorderStyle = BorderStyleValues.Thin;
            allBorderStyle.Border.TopBorder.BorderStyle = BorderStyleValues.Thin;
            return allBorderStyle;
        }
        public static SLStyle CreateHeader2Style(SLDocument sl)
        {
            SLStyle header2Type = sl.CreateStyle();
            header2Type.SetFontBold(true);
            header2Type.Font.FontSize = 16;
            header2Type.Font.FontName = "Calibri";
            return header2Type;
        }

        public static SLStyle CreateHeader1Style(SLDocument sl)
        {
            SLStyle header1Type = sl.CreateStyle();


            header1Type.SetFontBold(true);
            header1Type.Font.FontSize = 24;
            header1Type.Font.FontName = "Calibri";
            header1Type.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            header1Type.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);

            return header1Type;
        }
        public static SLStyle SetColorStyle(SLDocument sl, System.Drawing.Color color)
        {
            SLStyle style = sl.CreateStyle();
            style.Fill.SetPattern(PatternValues.Solid, color, color);
            return style;
        }

        #region:Excel_Export
        public static void CreatReportFile(DataGridView dgvCard, string tittle)
        {
            SLDocument sl = new SLDocument();
            //Create
            CreateTableHeader(sl, dgvCard, tittle);
            SetCardTableCOntent(sl, dgvCard);
            //Save
            SaveReportFile(sl);
        }
        public static void CreateReportTittle(SLDocument sl, string tittle, string startCell, string endCell)
        {
            sl.MergeWorksheetCells(startCell, endCell);
            sl.SetCellValue(startCell, tittle);
            sl.SetCellStyle(startCell, ExcelTools.CreateHeader1Style(sl));
        }
        public static void CreateTableHeader(SLDocument sl, DataGridView dgvCard, string tittle)
        {
            char currentChar = 'A';
            string columnHeader = dgvCard.SelectedCells[0].OwningColumn.HeaderText;
            int collumnIndex = 1;

            foreach (DataGridViewColumn column in dgvCard.Columns)
            {
                string excelCollumnName = currentChar.ToString() + "2";
                if (column.HeaderText.Trim() != "ID" && column.HeaderText.Trim() != "" && column.HeaderText.Trim() != "Code")
                {
                    sl.SetCellValue(excelCollumnName, column.HeaderText);
                    sl.AutoFitColumn(collumnIndex);
                    currentChar = Staticpool.incrementCharacter(currentChar);
                    collumnIndex++;
                }
            }
            SLStyle wrapStyle = sl.CreateStyle();
            wrapStyle.Font.FontSize = 9;
            wrapStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            wrapStyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);

            wrapStyle.SetWrapText(true);

            sl.SetCellStyle("A2", (char)(currentChar - 1) + "2", ExcelTools.CreateTableHeaderStyle(sl));
            sl.SetCellStyle("A2", (char)(currentChar - 1) + "2", ExcelTools.CreateAllBorderStyle(sl));
            sl.SetCellStyle("A2", (char)(currentChar - 1) + "2", wrapStyle);

            CreateReportTittle(sl, tittle, "A1", (char)(currentChar - 1) + "1");
        }
        public static void SetCardTableCOntent(SLDocument sl, DataGridView dgvCard)
        {
            int currentExcellCollumRow = 3;
            char startChar = 'A';
            char currentChar = 'A';
            foreach (DataGridViewRow row in dgvCard.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string cellHeaderText = cell.OwningColumn.HeaderText.Trim();
                    if (cellHeaderText != "ID" && cellHeaderText != "" && cellHeaderText != "Code")
                    {
                        string cellName = currentChar.ToString() + currentExcellCollumRow;
                        sl.SetCellValue(cellName, cell.Value.ToString());
                        currentChar = (char)(currentChar + 1);
                    }
                }
                if (dgvCard.Rows.IndexOf(row) < dgvCard.Rows.Count - 1)
                {
                    currentChar = startChar;
                    currentExcellCollumRow++;
                }
            }
            string lastCellName = ((char)(currentChar - 1)).ToString() + (currentExcellCollumRow) + "";

            SLStyle centerAlignStyle = sl.CreateStyle();
            centerAlignStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center);
            centerAlignStyle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center);
            sl.SetCellStyle("A" + 3, lastCellName, ExcelTools.CreateAllBorderStyle(sl));
            sl.SetCellStyle("A" + 3, lastCellName, centerAlignStyle);

        }
        public static void SaveReportFile(SLDocument sl)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Data Files (*.xlsx)|*.xlsx";
                saveFile.DefaultExt = "xlsx";
                saveFile.AddExtension = true;
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    sl.SaveAs(saveFile.FileName);
                }
            }
            catch
            {
            }
        }
        #endregion:End Excel_Export

    }
}
