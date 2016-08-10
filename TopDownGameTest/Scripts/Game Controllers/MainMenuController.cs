using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

	[SerializeField]
	private Toggle musicToggle;
	// Use this for initialization
	void Start () {
		CheckToPlayTheMusic ();

	}

	void CheckToPlayTheMusic()
	{
		if (GamePreferences.GetMusicState()==1) {
			MusicController.instance.PlayMusic (true);
			musicToggle.isOn =false;
		
		} else {
			MusicController.instance.PlayMusic (false );
			musicToggle.isOn =true;
		}
	}

	public void StartGame()
	{

		GameManager.instance.gameStartedFromMainMenu = false;
		GameManager.instance.gameRestartedAfterPlayerDied = false;
		GameManager.instance.gameStartedFromMainMenu = true;

		//SceneManager.LoadScene("GameScene");
		SceneFader.instance.LoadLevel ("GameScene");
	}
	public void HighscoreMenu()
	{
		

		SceneFader.instance.LoadLevel ("HiscoreScene");

	}

	public void OptionsMenu()
	{
		

		SceneFader.instance.LoadLevel ("OptionsScene");
	}
	public void QuitMenu()
	{
		Application.Quit ();
	}

	public void MusicToggle()
	{
		if(musicToggle.isOn == true)
		{
			GamePreferences.SetMusicState (0);
			MusicController.instance.PlayMusic (false);

		}
		else if (musicToggle.isOn == false )
		{
			GamePreferences.SetMusicState (1);
			MusicController.instance.PlayMusic (true);

		}
	}
}
