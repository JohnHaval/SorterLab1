using System.Data;

namespace DataGridFiller
{
    /// <summary>
    /// Класс для связывания DataGrid с массивом данных
    /// </summary>
    public static class VisualArray
    {        
        /// <summary>
        /// Метод заполнения DataGrid значениями массива
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mas">Массив значений</param>
        /// <returns>res</returns>
        public static DataTable ToDataTable<T>(T[] mas)
        {            
            var res = new DataTable();
            for (int i = 0; i < mas.Length; i++)
            {
                res.Columns.Add("i" + i, typeof(T));
            }
            var row = res.NewRow();
            for (int i = 0; i < mas.Length; i++)
            {                
                row[i] = mas[i];                                
            }
            res.Rows.Add(row);
            return res;
        }
    }
}