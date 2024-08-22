using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestoryBlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GoldItem")
        {
            GoldItemPool.Instance.Release(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Ball")
        {
            BallPool.Instance.Release(collision.gameObject);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
