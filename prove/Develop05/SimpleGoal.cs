using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
public class SimpleGoal : Goal
{
    [JsonPropertyName("_isComplete")]
    public bool IsComplete { get; set; }
    public SimpleGoal()
    {
    }

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        IsComplete = false;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetDisplay()
    {
        return $"[{(IsComplete ? "X" : " ")}] {base.GetDisplay()}";
    }
}