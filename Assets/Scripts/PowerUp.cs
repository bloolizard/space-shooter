using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //move down at a speed of 3 (adjust in the inspector)
        // when we leave the screen, destroy this object
        {
            transform.Translate(Vector3.down * 3f * Time.deltaTime);

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
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
            }

            Destroy(gameObject);
        }

    }
}
