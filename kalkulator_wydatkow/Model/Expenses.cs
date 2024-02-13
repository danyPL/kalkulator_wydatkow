namespace kalkulator_wydatkow.Model
{
    class Expenses
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
