using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saves
{
    private string filePath;

    public Saves()
    {
        filePath = Application.persistentDataPath + "/levels.save";
        if (!File.Exists(filePath))
        {
            File.Create(filePath).Dispose();
        }
    }

    public void SetComplete(int level)
    {
        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine($"level{level}");
        }
    }

    public List<string> ReturnCompleted()
    {
        List<string> completedLevels = new List<string>();
        foreach (string line in File.ReadLines(filePath))
        {
            completedLevels.Add(line);
        }
        return completedLevels;
    }

    public bool CheckIfCompleted(int level)
    {
        List<string> completedLevels = ReturnCompleted();
        if (completedLevels.Contains($"level{level}"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
