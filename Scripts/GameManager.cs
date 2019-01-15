using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject player;
	public GameObject backGround;
	public Text scoreText;
	public Text waveText;
	public Slider health;
	public GameObject gameOver;
	public GameObject enemyE;
	public GameObject enemyH;
	public Button button;
	public Text btnText;
	public Text message;
	public int waves = 0;
	public int score;
	public bool nextWaveClick;
	public bool noEnem;
	public bool isGameOver;

	private Movement playerScript;
	private Object[,] enemies;
	private int totalEnemiesE;
	private int totalEnemiesH;
	private static int highScore;

	void Awake() {
		if (instance == null) {
			instance = this; 
		} else if (instance != null) {
			Destroy(gameObject);
		}
		gameOver.SetActive (false);
		playerScript = player.GetComponent<Movement> ();
	}

	// Use this for initialization
	void Start () {
		player.transform.position = new Vector3 (-37.0f, 18.0f, 37.0f);

		scoreText.text = ("0");
		waveText.text = ("0");

		message.text = ("HighScore: " + PlayerPrefs.GetInt("HighScore"));

		score = 0;
		nextWaveClick = false;
		noEnem = false;
		isGameOver = false;

		enemies = new Object[4,2];
	}
	
	// Update is called once per frame
	void Update () {

		scoreText.text = (score.ToString());
		waveText.text = (waves.ToString ());

		health.value = playerScript.health;

		if (health.value == 0.0f) {
			gameOver.SetActive (true);
			isGameOver = true;
			StartCoroutine (RestartGame());
		} else if (playerScript.health <= 0.3f) {
			backGround.GetComponent<Image> ().color = Color.red;
		} else if (playerScript.health <= 0.5f) {
			backGround.GetComponent<Image> ().color = Color.yellow;
		}
	
		if (totalEnemiesE > 0) {
			if (enemies [0,0] == null && totalEnemiesE > 0) {
				enemies [0,0] = Instantiate (enemyE, new Vector3 (30, 20, 0), new Quaternion (0, 0, 0, 0));
				totalEnemiesE--;
			}
			if (enemies [1,0] == null && totalEnemiesE > 0) {
				enemies [1,0] = Instantiate (enemyE, new Vector3 (10, 20, 0), new Quaternion (0, 0, 0, 0));
				totalEnemiesE--;
			}
			if (enemies [2,0] == null && totalEnemiesE > 0) {
				enemies [2,0] = Instantiate (enemyE, new Vector3 (-10, 20, 0), new Quaternion (0, 0, 0, 0));
				totalEnemiesE--;
			}
			if (enemies [3,0] == null && totalEnemiesE > 0) {
				enemies [3,0] = Instantiate (enemyE, new Vector3 (-30, 20, 0), new Quaternion (0, 0, 0, 0));
				totalEnemiesE--;
			}
		}

		if (totalEnemiesH > 0) {
			if (enemies [0,1] == null && totalEnemiesH > 0) {
				enemies [0,1] = Instantiate (enemyH, new Vector3 (30, 40, 25), new Quaternion (0, 0, 0, 0));
				totalEnemiesH--;
			} 
			if (enemies [1,1] == null && totalEnemiesH > 0) {
				enemies [1,1] = Instantiate (enemyH, new Vector3 (10, 40, 25), new Quaternion (0, 0, 0, 0));
				totalEnemiesH--;
			}
			if (enemies [2,1] == null && totalEnemiesH > 0) {
				enemies [2,1] = Instantiate (enemyH, new Vector3 (-10, 40, 25), new Quaternion (0, 0, 0, 0));
				totalEnemiesH--;
			}
			if (enemies [3,1] == null && totalEnemiesH > 0) {
				enemies [3,1] = Instantiate (enemyH, new Vector3 (-30, 40, 25), new Quaternion (0, 0, 0, 0));
				totalEnemiesH--;
			}
		}

		if (totalEnemiesE <= 0 && totalEnemiesH <= 0 && enemies [0,0] == null && 
				enemies [1,0] == null && 
				enemies [2,0] == null && 
				enemies [3,0] == null &&
				enemies [0,1] == null && 
				enemies [1,1] == null && 
				enemies [2,1] == null && 
				enemies [3,1] == null) {

			noEnem = true;
		
			if (waves == 0) {
				btnText.text = ("Start");
			} else {
				btnText.text = ("Play Next Wave");
			}

			if (nextWaveClick) {
				waves += 1;
				totalEnemiesE = (int)(1.55 * waves + 4);
				totalEnemiesH = (int) (1.3 * waves - 2);
				nextWaveClick = false;
				noEnem = false;
				player.GetComponent<Movement>().health = 1f;
				message.text = ("HighScore: " + PlayerPrefs.GetInt("HighScore"));
				btnText.text = ("");
				backGround.GetComponent<Image> ().color = Color.green;
			}
				
		}

		if (score > highScore) {
			highScore = score;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}


	}

	public void IncrementScore(int value) {
		score += value;
	}

	private IEnumerator RestartGame() {
		waves = 0;
		waveText.text = ("0");
		btnText.text = ("Start");
		health.value = 1f;
		player.GetComponent<Movement>().health = 1f;
		scoreText.text = ("");
		score = 0;
		totalEnemiesE = 0;
		totalEnemiesH = 0;
		message.text = ("HighScore: " + PlayerPrefs.GetInt("HighScore"));
		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 4; j++) {
				enemies [j, i] = null;
			}
		}
		noEnem = false;
		nextWaveClick = false;
		yield return new WaitForSeconds (3);
		gameOver.SetActive (false);
		isGameOver = false;
		backGround.GetComponent<Image> ().color = Color.green;
	}

}


//("Please connect a bluetooth PS4 controller to your device. There is a tutorial at ___ for the game.");
