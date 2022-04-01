namespace CapitalShipsAPI.Models.Tables
{
    public class OutcomeModel
    {
        public string ShipName { get; set; }   // { 
                                               // primary key
        public string BattleName { get; set; } // }
        public string Result { get; set; }
    }
}