namespace CapitalShipsAPI.Models.Tables
{
    public class ShipModel
    {
        public string Name { get; set; } // primary key
        public string Class { get; set; }
        public int Launched { get; set; }
    }
}