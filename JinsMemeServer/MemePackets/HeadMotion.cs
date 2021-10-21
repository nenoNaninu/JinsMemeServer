namespace JinsMemeServer.MemePackets;


public class HeadMotion
{
    public DateTime Date { get; set; }
    public string Type { get; set; } = default!;
    public string SubType { get; set; } = default!;
    public float Value { get; set; }
}