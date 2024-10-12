using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PointHandler : MonoBehaviour
{
    public int points;
    private string filePath;

    // sets a max array value of 5, because thats how much scores we can hold.
    private string[] topPlayerNames = new string[5];
    private int[] topScores = new int[5];

    void Start()
    {
        filePath = Path.Combine(Application.dataPath, "Save", "pointsdata.txt");
        loadScores();
    }

    // take this from the text field
    public void savePoints(string playerName)
    {
        // save points only greater than 0
        if (points > 0) 
        {
            // once that conditions met, calculate who should be written to the file 
            addScore(playerName, points);
            // and write it now that we have our list
            writeScores(); 
        }
    }

    private void addScore(string playerName, int newScore)
    {      
        // if this remains -1, it indicates no lowest score is found.
        // if this gets replaced at any point, we found an index for our score and may proceed
        int lowestIndex = -1;
        
        // iterate through scores
        for (int i = 0; i < topScores.Length; i++)
        {
            // if the lowest score isnt found or the current score is lower compared to the lowest score found
            if (lowestIndex == -1 || topScores[i] < topScores[lowestIndex])
            {
                // get the index of that score
                lowestIndex = i; 
            }
        }

        // if the new score is greater than the lowest score found
        if (lowestIndex != -1 && newScore > topScores[lowestIndex])
        {
            // replace them with the new score
            topScores[lowestIndex] = newScore;
            // update the player name too that associated with the new score
            topPlayerNames[lowestIndex] = playerName; 
        }
    }

    private void writeScores()
    {
        using (StreamWriter writer = new StreamWriter(filePath, false)) // overwrite teh file --- true for appending mode
        {
            // iterate through the top scores we stored
            for (int i = 0; i < topScores.Length; i++)
            {
                if (topScores[i] > 0) // Write only if score is greater than 0
                {
                    // this formats it like ---> "PlayerName: Score"
                    writer.WriteLine($"{topPlayerNames[i]}: {topScores[i]}"); 
                }
            }
        }
    }


    private void loadScores()
    {
        // if the file exists 
        if (File.Exists(filePath))
        {
            // store all the lines in this string array
            string[] lines = File.ReadAllLines(filePath);

            // iterate through each line
            for (int i = 0; i < lines.Length; i++) 
            {
                // on every iteration, split the parts after the ":" delimiter
                // for example, if we had tim and he had 50 points 
                // string[0] = "Tim"
                // string[1] = " 50"
                // this way we can edit the scores, and leave the names.          
                string[] parts = lines[i].Split(':');

                // checks in case the user improperly formatted it
                // (e.g., "Tim: : 50" would be 3 parts)
                if (parts.Length == 2)
                {
                    // remove any extra whitespace and store them into strings
                    // now we effectively have split them
                    string playerName = parts[0].Trim();
                    string scoreStr = parts[1].Trim();

                    // convert to int from the string
                    int score = int.Parse(scoreStr);

                    // pass in the scores now
                    addScore(playerName, score); 

                    // this'll now loop for all the scores.
                }
            }
        }
    }

    // testing only
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
