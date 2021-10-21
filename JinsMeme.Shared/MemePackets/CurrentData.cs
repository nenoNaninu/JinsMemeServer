namespace JinsMeme.Shard.MemePackets;

public class CurrentData
{
    public float EyeMoveUp { get; set; }
    public float EyeMoveDown { get; set; }
    public float EyeMoveLeft { get; set; }
    public float EyeMoveRight { get; set; }
    public float BlinkSpeed { get; set; }
    public float BlinkStrength { get; set; }
    public bool Walking { get; set; }
    public float Roll { get; set; }
    public float Pitch { get; set; }
    public float Yaw { get; set; }
    public float AccX { get; set; }
    public float AccY { get; set; }
    public float AccZ { get; set; }
    public bool NoiseStatus { get; set; }
    public float FitError { get; set; }
    public float PowerLeft { get; set; }
    public float SequenceNumber { get; set; }
}