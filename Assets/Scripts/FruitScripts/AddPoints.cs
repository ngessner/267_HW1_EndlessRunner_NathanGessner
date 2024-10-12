using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using TMPro;

public class AddPoints : MonoBehaviour
{
    private TextMeshProUGUI pointsGUI;
    // I reference the point handler here so im not creating between scripts a bunch of new
    // and random instances of points. Its nice to track one variable keeping an eye on the
    // points.
    private PointHandler pointState;

    private void Start()
    {
        componentGetter();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pointState.points += 10;

            pointsGUI.text = pointState.points.ToString();
            Destroy(this.gameObject);
        }
    }

    void componentGetter()
    {
        // dont like doing this but cant store as public when its a prefab
        GameObject scoreTextObject = GameObject.Find("PointNum");
        GameObject playerObj = GameObject.Find("BatPlayer");

        pointsGUI = scoreTextObject.GetComponent<TextMeshProUGUI>();
        pointState = playerObj.GetComponent<PointHandler>();
    }
}
