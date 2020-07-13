using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int health = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Sphere")
        {
            if (health > 1)
            {
                Instantiate(GameManager.instance.blockColors[health - 2], transform.parent.position, transform.parent.rotation);
                Destroy(transform.parent.gameObject);
            }
            if (--health == 0)
            {
                Instantiate(GameManager.instance.explosion, transform.parent.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);

            }
        }
    }
}
