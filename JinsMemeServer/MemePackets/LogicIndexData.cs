namespace JinsMemeServer.MemePackets;

public class LogicIndexData
{
    public DateTime Date { get; set; }
    public int StepCount { get; set; }
    public int BlinkCountRaw { get; set; }
    public int EyeMoveUpCount { get; set; }
    public int EyeMoveDownCount { get; set; }
    public int EyeMoveRightCount { get; set; }
    public int EyeMoveLeftCount { get; set; }
    public bool IsStill { get; set; }
    public float XMean { get; set; }
    public float XSD { get; set; }
    public float YMean { get; set; }
    public float YSD { get; set; }
    public int PitchOnewayCount { get; set; }
    public int PitchRoundCount { get; set; }
    public int YawOnewayCount { get; set; }
    public int YawRoundCount { get; set; }
    public float XRightStepAmplitude { get; set; }
    public float XLeftStepAmplitude { get; set; }
    public float YRightStepAmplitude { get; set; }
    public float YLeftStepAmplitude { get; set; }
    public float ZRightStepAmplitude { get; set; }
    public float ZLeftStepAmplitude { get; set; }
    public float ZRightStepAmplitudeCal { get; set; }
    public float ZLeftStepAmplitudeCal { get; set; }
    public float MaxRightStepAcceleration { get; set; }
    public float NaxLeftStepAcceleration { get; set; }
    public float StepCadence { get; set; }
    public float BlinkIntervalMean { get; set; }
    public float BlinkStrengthMean { get; set; }
    public float BlinkStrengthSD { get; set; }
    public float BlinkWidthMean { get; set; }
    public float NptMean { get; set; }
    public float NptSD { get; set; }
    public int BlinkCount { get; set; }
    public int BlinkIntervalCount { get; set; }
    public float BlinkIntervalTotal { get; set; }
    public float BlinkStrengthTotal { get; set; }
    public float BlinkStrengthMax { get; set; }
    public float NptMedian { get; set; }
    public float NoiseTime { get; set; }
    public bool IsValid { get; set; }
    public float SleepScore { get; set; }
    public float FocusScore { get; set; }
    public float TensionScore { get; set; }
    public float CalmScore { get; set; }
    public float SleepScoreStandard { get; set; }
}