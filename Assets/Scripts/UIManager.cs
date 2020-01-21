using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //handle to Text
    [SerializeField]
    private Text _scoreText;

    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null)
        {
            Debug.Log("WARNING: the Player is NULL");
        }
        //assign text component to the handle
        _scoreText.text = "Score: " + _player.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
       _scoreText.text = "Score: " + _player.GetScore(); 
    }
}
