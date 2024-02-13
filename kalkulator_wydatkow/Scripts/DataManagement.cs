using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using kalkulator_wydatkow.Model;

namespace kalkulator_wydatkow.Scripts
{
    class DataManagement
    {
        public List<Expenses> expenses = new List<Expenses>();
        private string path = Path.Combine(FileSystem.Current.AppDataDirectory, "expenses.json");        
        public DataManagement() {
            if (!File.Exists(path)) {
                File.Create(path).Close();
            }
            RefreshData();
        }
        
        public bool RefreshData() {
            try {
                if (File.Exists(path)) {
                    expenses = JsonSerializer.Deserialize<List<Expenses>>(File.ReadAllText(path));
                    return true;
                }
                else
                    return false;
            } catch (Exception ex) {
                
                return false;
            }
        }
        public bool PushExpense(string name, double price, DateTime date, string category)
        {
            try
            {
                int id = expenses.Count > 0 ? expenses[expenses.Count -1 ].ID + 1 : 1;
                expenses.Add(new Expenses
                {
                    ID = id,
                    Name = name,
                    Price = price,
                    Date = date,
                    Category = category
                });
                return SaveData();
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool SaveData()
        {
            try
            {
                string data = JsonSerializer.Serialize(expenses);
                File.WriteAllText(path, data);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
