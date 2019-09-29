using TMPro;
using UnityEngine;
using System.Collections;

public class EndScene : MonoBehaviour
{
    public float delay;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delay);
        GameObject.Find("UpperText").GetComponent<TextMeshProUGUI>().text = "<REDACTED>";
        GameObject.Find("LowerText").GetComponent<TextMeshProUGUI>().enabled = true;
    }

}