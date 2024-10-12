using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 


public class LeaderboardDisplay : MonoBehaviour
{
    public TextMeshProUGUI lbText; 
    // keep private, we have a few of these floating around
    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "Save", "pointsdata.txt");

        displayLeaderboard();
    }

    void displayLeaderboard()
    {
        if (File.Exists(filePath))
        {
            // set lb text to nothing, to fill in with content
            lbText.text = "";

            // store all lines in the file into a string array
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {            
                lbText.text += lines[i] + "\n";
            }
        }
        else
        {
            lbText.text = "No Scores Detected";
        }
    }
}
