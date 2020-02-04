using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float _speed = 4f;
    private Player _player;

    private Animator _enemyAnim;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();

        _enemyAnim = GetComponent<Animator>();
        if (_enemyAnim == null)
        {
            Debug.Log("WARNING: the Enemy Animator is NULL.");
        }
    }


    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5.3f)
        {
            float randomX = Random.Range(-11.3f, 11.3f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }

            TriggerDeathAnim();

        }

        else if (other.tag == "Laser")
        {
            Destroy(other.gameObject);

            TriggerDeathAnim();

            if (_player != null)
            {
                _player.AddScore(10);
            }
        }
    }

    private void TriggerDeathAnim()
    {
        _enemyAnim.SetTrigger("OnEnemyDeath");
        _speed = 0;
        Destroy(gameObject, 2.5f);
    }
}
