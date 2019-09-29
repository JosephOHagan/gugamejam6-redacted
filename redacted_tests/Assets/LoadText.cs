using TMPro;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadText : MonoBehaviour
{ 
    void Awake()
    {
		string path = "text_test";

        TextAsset test = Resources.Load<TextAsset>(path);

        GameObject text = GameObject.Find("TMP_Text");
		text.GetComponent<TextMeshProUGUI>().text = test.text;

	}
}