using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
	private CameraScript cameraScript;
	public static GamePlayController instance;

	[SerializeField]
	private Text scoreText, coinText, lifeText, gameoverScoreText,gameoverCoinText;

	[SerializeField]
	private GameObject pausePanel, gameOverPanel;

	[SerializeField]
	private Button readyButton;

	void Awake ()
	{cameraScript = Camera.main.GetComponent<CameraScript> ();

		MakeInstance ();
		pausePanel.GetComponent<CanvasGroup> ().alpha = 0;
		pausePanel.GetComponent<CanvasGroup>().interactable=false;
		pausePanel.GetComponent<CanvasGroup>().blocksRaycasts=false;

	}
	void Start()
	{
		Time.timeScale = 0f;
	}

	void MakeInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}
	public void SetScore(int score)
	{
		scoreText.text = "x" + score;
	}
	public void SetCoinScore(int coinScore)
	{
		coinText.text = "x" + coinScore;
	}
	public void SetLifeScore(int lifeScore)
	{
		
		lifeText.text = "x" + lifeScore;
	}


	public void  GameOverShowPanel(int finalScore, int finalCoinScore)
	{
		gameOverPanel.GetComponent<CanvasGroup> ().alpha = 1;
		gameOverPanel.GetComponent<CanvasGroup>().interactable=true;
		gameOverPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
		gameoverScoreText.text = finalScore.ToString ();
		gameoverCoinText.text = finalCoinScore.ToString ();
	
		StartCoroutine (GameoverLoadMainMenu());

	}
	IEnumerator GameoverLoadMainMenu()
	{
		yield return new WaitForSeconds (3f);
		SceneFader.instance.LoadLevel ("MainMenuScene");
	}

	public void PlayerDieRestartTheGame()
	{
		StartCoroutine (PlayerDieRestart ());
	}
	IEnumerator PlayerDieRestart()
	{
		yield return new WaitForSeconds (1f);
		SceneFader.instance.LoadLevel ("GameScene");
	}

	public void PauseTheGame()
	{
		Time.timeScale = 0f;
		pausePanel.GetComponent<CanvasGroup> ().alpha = 1;
		pausePanel.GetComponent<CanvasGroup>().interactable=true;
		pausePanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
	}
	public void ResumeTheGame()
	{
		Time.timeScale = 1f;
		pausePanel.GetComponent<CanvasGroup> ().alpha = 0;
		pausePanel.GetComponent<CanvasGroup>().interactable=false;
		pausePanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
	}

	public void StartTheGame()
	{
		Time.timeScale = 1f;
		readyButton.gameObject.SetActive (false);
	}
	public void QuitGame()
	{
		cameraScript.moveCamera = false;
		Time.timeScale = 1f;

	
		SceneFader.instance.LoadLevel ("MainMenuScene");
	}

}
