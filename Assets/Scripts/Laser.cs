using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    void Update()
    {
        Vector3 direction = new Vector3(0, 1, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.y > 8f)
        {
            if (gameObject.transform.parent)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            Destroy(gameObject, 5f);
        }
    }
}
