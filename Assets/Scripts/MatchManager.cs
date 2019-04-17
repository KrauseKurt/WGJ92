using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchManager : MonoBehaviour
{

    private int p1points = 0;
    private int p2points = 0;

    public int time = 60;

    public Text timerTxt;
    public Text p1pointsTxt;
    public Text p2pointsTxt;


    public void Start()
    {
        Time.timeScale = 1;
        StartMatch();
    }

    void Update()
    {
        timerTxt.text = time.ToString();
    }

    private void StartMatch()
    {
        StartCoroutine(Countdown());
        UpdateScores();
    }

    private IEnumerator Countdown()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
    }

    private void UpdateScores()
    {
        p1pointsTxt.text = " Points: " + p1points;
        p2pointsTxt.text = "Points: " + p2points + " ";
    }


}
