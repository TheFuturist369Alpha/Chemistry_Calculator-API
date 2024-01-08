namespace Models
{
    public class Element
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int AtomicNumber { get; set; }
        public double AtomicMass { get; set; }
        public int ElectroValency { get; set; }

    }
}