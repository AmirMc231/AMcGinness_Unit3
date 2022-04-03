using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 3;
    private PlayerController playerCtrl;
    private float leftBounds = -15.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCtrl.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }


        if(transform.position.x < leftBounds && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
            
    }
}
