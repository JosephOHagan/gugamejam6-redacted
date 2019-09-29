using TMPro;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfDay : MonoBehaviour
{
    public string nextScene;

    public TextAsset textAsset;
    private string outputStr;

    // This is the total number of redactions so far so for day 1 it is day 1
    // for day 2 it is day 1 + day 2, etc.
    public double totalNumberOfRedactions;

    private void Awake()
    {
        GameObject textObject = GameObject.Find("DocumentText");
        outputStr = textAsset.text + "";

        if (GameObject.Find("AudioManager").GetComponent<AudioManager>().dayCount != 3)
        {
            int incorrect = GameObject.Find("AudioManager").GetComponent<AudioManager>().incorrectCount;

            double percent = GameObject.Find("AudioManager").GetComponent<AudioManager>().correctCount / totalNumberOfRedactions * 100.0;
            percent = Math.Round(percent, 2);

            outputStr = outputStr.Replace("NNN", percent.ToString());
            outputStr = outputStr.Replace("MMM", incorrect.ToString());
        }               

        textObject.GetComponent<TextMeshProUGUI>().text = outputStr;
    }

    public void NextDay()
    {
        if (GameObject.Find("AudioManager").GetComponent<AudioManager>().dayCount == 3)
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopAudio("Day3");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio("End");
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopAudio("EndOfDay");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio("Whistle");
        }
                                 
        SceneManager.LoadScene(nextScene);
    }
}
