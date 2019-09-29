using TMPro;
using UnityEngine;
using UnityEditor;
using System.IO;

public class LoadInaccuracyText : MonoBehaviour
{
    public TextAsset inaccuracyTextFile;

    void Awake()
    {        
        GameObject text = GameObject.Find("InaccuracyText");
        text.GetComponent<TextMeshProUGUI>().text = inaccuracyTextFile.text;
    }

}