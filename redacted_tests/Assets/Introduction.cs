using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Introduction : MonoBehaviour
{
    private int clickCount = 0;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject text;

    public void NextClick()
    {
        clickCount += 1;

        if (clickCount == 1)
        {
            TextAsset t1= Resources.Load<TextAsset>("IntroText/intro_t_1");
            GameObject.Find("TMP_Text").GetComponent<TextMeshProUGUI>().text = t1.text;

            panel1.SetActive(true);
            panel2.SetActive(true);
            text.SetActive(true);
        }
        if (clickCount == 2)
        {
            TextAsset t2 = Resources.Load<TextAsset>("IntroText/intro_t_2");
            GameObject.Find("TMP_Text").GetComponent<TextMeshProUGUI>().text = t2.text;

            GameObject.Find("NextButtonText").GetComponent<TextMeshProUGUI>().text = "Start";

            text.GetComponent<TextMeshProUGUI>().text = "Today's Inaccuracy:";
        }
        if (clickCount == 3)
        {
            SceneManager.LoadScene("Day1");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().StopAudio("MainMenuTheme");
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayAudio("Whistle");

        }
    }
}
