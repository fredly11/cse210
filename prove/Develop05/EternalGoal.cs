using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


[Serializable]
public class EternalGoal : Goal
{

    public EternalGoal()
    {
    }

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override string GetDisplay()
    {
        return $"[ ] {base.GetDisplay()} - Eternal";
    }
}