using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel; 


namespace ISIS_laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.pTableAdapter.Fill(this.baseDataDataSet.P);
            this.stateTableAdapter.Fill(this.baseDataDataSet.State);
            this.buyerTableAdapter.Fill(this.baseDataDataSet.Buyer);
            this.avtoTableAdapter.Fill(this.baseDataDataSet.Avto);
            this.proizvoditelTableAdapter.Fill(this.baseDataDataSet.Proizvoditel);

        }



        private void proizvoditelBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.proizvoditelBindingSource.EndEdit();
            this.pBindingSource.EndEdit();
            this.avtoBindingSource.EndEdit();
            this.buyerBindingSource.EndEdit();
            this.stateBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.baseDataDataSet);
      
        }


        private void таблПроизводительToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = new Excel.Worksheet();
            Microsoft.Office.Interop.Excel.Range xlSheetRange;
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                Info inf = new Info();
                inf.ShowDialog();
                string n = inf.getText;
                xlSheet.Name = n;

                
                //Выгрузка данных
                DataTable dt = baseDataDataSet.Proizvoditel;

                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data; 
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //Отсоединяемся от Excel
                //releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }*/
        }

        private void таблАвтомашинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = new Excel.Worksheet();
            Microsoft.Office.Interop.Excel.Range xlSheetRange;
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                Info inf = new Info();
                inf.ShowDialog();
                string n = inf.getText;
                xlSheet.Name = n;


                //Выгрузка данных
                DataTable dt = baseDataDataSet.Avto;

                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //Отсоединяемся от Excel
                //releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }*/
        }

        private void таблГосударствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = new Excel.Worksheet();
            Microsoft.Office.Interop.Excel.Range xlSheetRange;
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                Info inf = new Info();
                inf.ShowDialog();
                string n = inf.getText;
                xlSheet.Name = n;


                //Выгрузка данных
                DataTable dt = baseDataDataSet.State;

                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //Отсоединяемся от Excel
                //releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }*/
        }

        private void таблПокупательToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = new Excel.Worksheet();
            Microsoft.Office.Interop.Excel.Range xlSheetRange;
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                Info inf = new Info();
                inf.ShowDialog();
                string n = inf.getText;
                xlSheet.Name = n;


                //Выгрузка данных
                DataTable dt = baseDataDataSet.Buyer;

                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //Отсоединяемся от Excel
                //releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }*/
        }

        private void таблПокупкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
           /* Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = new Excel.Worksheet();
            Microsoft.Office.Interop.Excel.Range xlSheetRange;
            try
            {
                //добавляем книгу
                xlApp.Workbooks.Add(Type.Missing);

                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;

                //выбираем лист на котором будем работать (Лист 1)
                xlSheet = (Excel.Worksheet)xlApp.Sheets[1];
                //Название листа
                Info inf = new Info();
                inf.ShowDialog();
                string n = inf.getText;
                xlSheet.Name = n;


                //Выгрузка данных
                DataTable dt = baseDataDataSet.P;

                int collInd = 0;
                int rowInd = 0;
                string data = "";

                //называем колонки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    data = dt.Columns[i].ColumnName.ToString();
                    xlSheet.Cells[1, i + 1] = data;

                    //выделяем первую строку
                    xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                    //делаем полужирный текст и перенос слов
                    xlSheetRange.WrapText = true;
                    xlSheetRange.Font.Bold = true;
                }

                //заполняем строки
                for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                {
                    for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                    {
                        data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                        xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                    }
                }

                //выбираем всю область данных
                xlSheetRange = xlSheet.UsedRange;

                //выравниваем строки и колонки по их содержимому
                xlSheetRange.Columns.AutoFit();
                xlSheetRange.Rows.AutoFit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

                //Отсоединяемся от Excel
                //releaseObject(xlSheetRange);
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }*/
        }

        private void сохранитьВсеТаблицыToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = new Excel.Worksheet();
            Microsoft.Office.Interop.Excel.Range xlSheetRange;
            xlApp.Workbooks.Add();

            try
            {
                //делаем временно неактивным документ
                xlApp.Interactive = false;
                xlApp.EnableEvents = false;
                DataTableCollection CollectionBD = ((DataSet)baseDataDataSet).Tables;
               
                int t = 0;
                foreach (DataTable db in CollectionBD)
                {
                    t = t + 1;
                    //выбираем лист на котором будем работать
                    xlSheet = (Excel.Worksheet)xlApp.Sheets.Add();
                    //Выгрузка данных
                    DataTable dt = db;
                    //Название листа
                    xlSheet.Name = dt.TableName;

                    int collInd = 0;
                    int rowInd = 0;
                    string data = "";

                    //называем колонки
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        data = dt.Columns[i].ColumnName.ToString();
                        xlSheet.Cells[1, i + 1] = data;

                        //выделяем первую строку
                        xlSheetRange = xlSheet.get_Range("A1:Z1", Type.Missing);

                        //делаем полужирный текст и перенос слов
                        xlSheetRange.WrapText = true;
                        xlSheetRange.Font.Bold = true;
                    }

                    //заполняем строки
                    for (rowInd = 0; rowInd < dt.Rows.Count; rowInd++)
                    {
                        for (collInd = 0; collInd < dt.Columns.Count; collInd++)
                        {
                            data = dt.Rows[rowInd].ItemArray[collInd].ToString();
                            xlSheet.Cells[rowInd + 2, collInd + 1] = data;
                        }
                    }

                    //выбираем всю область данных
                    xlSheetRange = xlSheet.UsedRange;

                    //выравниваем строки и колонки по их содержимому
                    xlSheetRange.Columns.AutoFit();
                    xlSheetRange.Rows.AutoFit();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
  //Показываем ексель
                xlApp.Visible = true;

                xlApp.Interactive = true;
                xlApp.ScreenUpdating = true;
                xlApp.UserControl = true;

    //Отсоединяемся от Excel
                releaseObject(xlSheet);
                releaseObject(xlApp);
            }
        
        }

    }
}
