using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

[Serializable]
public class SaveData
{
    public int TotalPoints { get; set; }
    public List<Goal> Goals { get; set; }
}