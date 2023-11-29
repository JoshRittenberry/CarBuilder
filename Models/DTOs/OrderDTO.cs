public class OrderDTO
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int VehicleId { get; set; }
    public VehicleDTO Vehicle { get; set; }
    public int WheelId { get; set; }
    public WheelDTO Wheel { get; set; }
    public int TechnologyId { get; set; }
    public TechnologyDTO Technology { get; set; }
    public int PaintId { get; set; }
    public PaintColorDTO Paint { get; set; }
    public int InteriorId { get; set; }
    public InteriorDTO Interior { get; set; }
}