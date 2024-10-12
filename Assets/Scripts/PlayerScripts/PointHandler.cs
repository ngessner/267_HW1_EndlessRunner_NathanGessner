using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PointHandler : MonoBehaviour
{
    public int points; 
    string filePath; 

    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "Save", "pointsdata.txt");

        //loadPoints();
    }

    public void savePoints()
    {
        if (File.Exists(filePath))
        {
            // true to use app mode
            using (StreamWriter writer = new StreamWriter(filePath, true)) 
            {
                // don't write 0 scores.
                if (points > 0)
                {
                    writer.WriteLine(points.ToString());
                }
            }
        }  
    }

    //public void loadPoints()
    //{
    //    // load pointsdata.txt 
    //    if (File.Exists(filePath))
    //    {

    //        string loadedPoints = File.ReadAllText(filePath);
    //        Debug.LogWarning(loadedPoints);
    //        points = int.Parse(loadedPoints);
    //        Debug.LogWarning(points);
    //    }
    //}
}
