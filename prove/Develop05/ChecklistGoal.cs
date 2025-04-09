using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
public class ChecklistGoal : Goal
{
    [JsonPropertyName("_targetCount")]
    public int TargetCount { get; set; }

    [JsonPropertyName("_bonusPoints")]
    public int BonusPoints { get; set; }

    [JsonPropertyName("_currentCount")]
    public int CurrentCount { get; set; }

    public ChecklistGoal()
    {
    }

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override int RecordEvent()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                return Points + BonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetDisplay()
    {
        string status = CurrentCount >= TargetCount ? "[X]" : "[ ]";
        return $"{status} {base.GetDisplay()} - Completed {CurrentCount}/{TargetCount}";
    }
}