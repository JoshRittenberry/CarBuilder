public class Order
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public DateTime? DateCompleted { get; set; }
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; }
    public int WheelId { get; set; }
    public Wheel Wheel { get; set; }
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; }
    public int PaintId { get; set; }
    public PaintColor Paint { get; set; }
    public int InteriorId { get; set; }
    public Interior Interior { get; set; }
    public decimal TotalCost
    {
        get
        {
            decimal totalCost = 0;
            if (Wheel != null) totalCost += Wheel.Price;
            if (Technology != null) totalCost += Technology.Price;
            if (Paint != null) totalCost += Paint.Price;
            if (Interior != null) totalCost += Interior.Price;
            return totalCost;
        }
    }
}