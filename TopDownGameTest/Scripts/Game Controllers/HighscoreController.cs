using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {
	[SerializeField]
	private Text scoreText,coinText, difficultyLevelText ;
	// Use this for initialization
	void Start () {
		SetScoreBoardOnDifficulty ();

		if(GamePreferences.GetEasyDifficultyState() == 1)
		{
			difficultyLevelText.text = "Easy Mode";
		}
		if(GamePreferences.GetMediumDifficultyState() == 1)
		{
			difficultyLevelText.text = "Medium Mode";
		}
		if(GamePreferences.GetHardDifficultyState() == 1)
		{
			difficultyLevelText.text = "Hard Mode";
		}
	}

	void SetScore(int score, int coinScore)
	{
		scoreText.text = score.ToString ();
		coinText.text = coinScore.ToString ();
	}


	void SetScoreBoardOnDifficulty()
	{
		if (GamePreferences.GetEasyDifficultyState() ==1 ) {
			SetScore (GamePreferences.GetEasyDifficultyHighScore(),GamePreferences.GetEasyDifficultyCoinScore());
		}
		if (GamePreferences.GetMediumDifficultyState() ==1 ) {
			SetScore (GamePreferences.GetMediumDifficultyHighScore(),GamePreferences.GetMediumDifficultyCoinScore());
		}
		if (GamePreferences.GetHardDifficultyState() ==1 ) {
			SetScore (GamePreferences.GetHardDifficultyHighScore(),GamePreferences.GetHardDifficultyCoinScore());
		}
	}
	public void GoBackToMainMenu()
	{
		
		SceneFader.instance.LoadLevel ("MainMenuScene");
	}
	// Update is called once per frame

}
