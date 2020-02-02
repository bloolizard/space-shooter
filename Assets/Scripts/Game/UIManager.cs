using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to Text
    [SerializeField]
    private Text _scoreText;

    [SerializeField]
    private Text _restartText;

    [SerializeField]
    private Image _LivesImg;

    [SerializeField]
    private Sprite[] _livesSprites;

    [SerializeField]
    private GameObject _gameOver;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        //_livesSprites[CurrentPlayerLives = 3];
        _scoreText.text = "Score: " + 0;
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _livesSprites[currentLives];
    }

    public void GameOver()
    {
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {

        while (true)
        {
            float randomX = Random.Range(25f, 100f);
            float randomY = Random.Range(10f, 100f);

            Vector3 posToSpawn = new Vector3(_gameOver.transform.position.x + randomX, _gameOver.transform.position.y + randomY, 0);
            _gameOver.transform.position = posToSpawn;
            _gameOver.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }
}
