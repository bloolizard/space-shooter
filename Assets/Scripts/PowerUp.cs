using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    // 0 = Triple Shot, 1 = Speed, 2 = Shields
    [SerializeField]
    private int powerUpId;

    void Update()
    {
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);

            if (transform.position.y < -5.3f)
            {
                Destroy(gameObject);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                switch (powerUpId)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        Debug.Log("Collected Shields");
                        break;
                    default:
                        break;
                }
            }
            
            Destroy(gameObject);
        }

    }
}
