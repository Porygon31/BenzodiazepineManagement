namespace BenzodiazepineManagement.Models
{
    /// <summary>
    /// Représente une valeur numérique qui peut être unique ou une plage.
    /// </summary>
    public class ValueRange
    {
        public bool IsRange { get; set; }
        public double Value { get; set; }
        public double? MaxValue { get; set; }
    }
}
