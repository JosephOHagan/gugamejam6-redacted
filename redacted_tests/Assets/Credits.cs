using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public void GoToIntroduction()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void GoToCredits()
	{
		SceneManager.LoadScene("Credits");
	}

	public void GoToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
	
	public void GoToAbout()
	{
		SceneManager.LoadScene("About");
	}


}
