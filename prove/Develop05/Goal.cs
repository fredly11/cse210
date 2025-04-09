using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

[Serializable]
[JsonDerivedType(typeof(SimpleGoal), typeDiscriminator: "simple")]
[JsonDerivedType(typeof(EternalGoal), typeDiscriminator: "eternal")]
[JsonDerivedType(typeof(ChecklistGoal), typeDiscriminator: "checklist")]
public abstract class Goal
{
    [JsonPropertyName("_name")]
    public string Name { get; set; }

    [JsonPropertyName("_description")]
    public string Description { get; set; }

    [JsonPropertyName("_points")]
    public int Points { get; set; }

    protected Goal()
    {
    }

    public Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
    }

    public virtual int RecordEvent()
    {
        return Points;
    }

    public virtual string GetDisplay()
    {
        return $"{Name} ({Description})";
    }
}