using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

	[SerializeField]
	private Toggle easyToggle, mediumToggle, hardToggle;
	// Use this for initialization
	void Start ()
	{
		checkDefficultyAtStart ();
	}

	public  void setInitialDifficulty ()
	{
		
		if (easyToggle.isOn) {
			GamePreferences.SetEasyDifficultyState (1);
			GamePreferences.SetMediumDifficultyState (0);
			GamePreferences.SetHardDifficultyState (0);

		}
		if (mediumToggle.isOn) {
			GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetMediumDifficultyState (1);
			GamePreferences.SetHardDifficultyState (0);

		}
		if (hardToggle.isOn) {
			GamePreferences.SetEasyDifficultyState (0);
			GamePreferences.SetMediumDifficultyState (0);
			GamePreferences.SetHardDifficultyState (1);

		}
	}

	void checkDefficultyAtStart ()
	{
		if (GamePreferences.GetEasyDifficultyState () == 1 && GamePreferences.GetMediumDifficultyState () == 0 && GamePreferences.GetHardDifficultyState () == 0) {
			easyToggle.isOn = true;
			mediumToggle.isOn = false;
			hardToggle.isOn = false;
			setInitialDifficulty ();

		}
		if (GamePreferences.GetEasyDifficultyState () == 0 && GamePreferences.GetMediumDifficultyState () == 1 && GamePreferences.GetHardDifficultyState () == 0) {
			easyToggle.isOn = false;
			mediumToggle.isOn = true;
			hardToggle.isOn = false;
			setInitialDifficulty ();
		}
		if (GamePreferences.GetEasyDifficultyState () == 0 && GamePreferences.GetMediumDifficultyState () == 0 && GamePreferences.GetHardDifficultyState () == 1) {
			easyToggle.isOn = false;
			mediumToggle.isOn = false;
			hardToggle.isOn = true;
			setInitialDifficulty ();
		}
	}
	
	// Update is called once per frame
	public void GoBackToMainMenu ()
	{
		
		SceneFader.instance.LoadLevel ("MainMenuScene");

	}
}
