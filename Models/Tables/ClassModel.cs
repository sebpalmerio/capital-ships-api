namespace CapitalShipsAPI.Models.Tables
{
    public class ClassModel
    {
        public string ClassName { get; set; } // primary key
        public string Type { get; set; }
        public string Country { get; set; }
        public int NumGun { get; set; }
        public int Bore { get; set; }
        public int Displacement { get; set; }
    }
}