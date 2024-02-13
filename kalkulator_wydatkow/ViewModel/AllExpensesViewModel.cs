
using System;
using System.IO;
using System.Text.Json;
using System.Collections.ObjectModel;
using kalkulator_wydatkow.Model;
namespace kalkulator_wydatkow.ViewModel
{
    internal class AllExpensesViewModel
    {
        public ObservableCollection<Expenses> ExpensesList { get; set; }
        private string path = Path.Combine(FileSystem.Current.AppDataDirectory, "expenses.json");

        public AllExpensesViewModel()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            RefreshData();
        }
        public bool RefreshData()
        {
            try
            {
                if (File.Exists(path))
                {
                    ExpensesList = JsonSerializer.Deserialize<ObservableCollection<Expenses>>(File.ReadAllText(path));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
