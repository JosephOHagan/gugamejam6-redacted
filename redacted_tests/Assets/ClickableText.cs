using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public class ClickableText : MonoBehaviour, IPointerClickHandler
{
    public string textName;
    private GameObject text;

    public int correctCount = 0;
    public int incorrectCount = 0;

    // The list of keywords to look for in this text instance
    public string[] keywords;

    private void Start()
    {
        text = GameObject.Find(textName);
    }

    public void OnPointerClick(PointerEventData eventData)
    {               
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            // Debug.Log("Left click");

            var text_var = text.GetComponent<TextMeshProUGUI>();           

            int linkIndex = TMP_TextUtilities.FindIntersectingLink(text_var, Input.mousePosition, null);

            if (linkIndex > -1)
            {
                var linkInfo = text_var.textInfo.linkInfo[linkIndex];
                var linkId = linkInfo.GetLinkID();

                string linkStr = "<link=" + linkId.ToString() + "><color=white>";
                string replaceStr = "<link=" + linkId.ToString() + "><color=black>";

                string endStr = "</";
                string clickedString = getBetween(text.GetComponent<TextMeshProUGUI>().text, linkStr, endStr);

                text.GetComponent<TextMeshProUGUI>().text = text.GetComponent<TextMeshProUGUI>().text.Replace(linkStr, replaceStr);

                if (keywords.Any(clickedString.Contains))
                {
                    correctCount += 1;
                }
                else
                {
                    incorrectCount += 1;
                }
            }            

        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            // Debug.Log("Middle click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click");
        }           
    }

    string getBetween(string strSource, string strStart, string strEnd)
    {
        int Start, End;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            return strSource.Substring(Start, End - Start);
        }
        else
        {
            return "111111";
        }
    }

}