using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class RingsConfiguration
{
    public List<List<int>> Configuration = new List<List<int>>();


    public List<int> Debug = new List<int>();

    public RingsConfiguration(List<List<int>> configuration)
    {
        Configuration = configuration;
        Debug = Configuration.SelectMany(x => x).ToList();  
    }

    public bool IsValid()
    {
        foreach (var peg in Configuration)
        {
            for (int i = 1; i < peg.Count; i++)
            {
                if (peg[i] >= peg[i - 1])
                    return false; // Кольца должны быть упорядочены по убыванию
            }
        }
        return true;
    }
}
