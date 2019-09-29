using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadDayText : MonoBehaviour
{
    public TextAsset[] dayText;
    private int clickCount = 0;
    private GameObject text;

    public string nextScene;

    void Awake()
    {
        text = GameObject.Find("DocumentText");
        text.GetComponent<TextMeshProUGUI>().text = dayText[clickCount].text;
    }

    public void NextClick()
    {
        clickCount += 1;

        if (clickCount < dayText.Length)
        {
            text.GetComponent<TextMeshProUGUI>().text = dayText[clickCount].text;
        }
        else
        {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().dayCount += 1;                       

            GameObject.Find("AudioManager").GetComponent<AudioManager>().correctCount += GameObject.Find("Canvas").GetComponent<ClickableText>().correctCount;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().incorrectCount += GameObject.Find("Canvas").GetComponent<ClickableText>().incorrectCount;

            if (GameObject.Find("AudioManager").GetComponent<AudioManager>().dayCount == 3)
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopAudio("Whistle");
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio("Day3");
            }            
            else
            {
                GameObject.Find("AudioManager").GetComponent<AudioManager>().StopAudio("Whistle");
                GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio("EndOfDay");
            }
            
            SceneManager.LoadScene(nextScene);
        }
    }

}