using System.Collections;
using System.Collections.Generic;
using Level;
using UnityEngine;

public class EdgeCollisionHandler : MonoBehaviour
{
    public GameObject playerBall;

    public GameObject LevelHandler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerBall.GetComponent<CircleCollider2D>()) {
            Debug.Log("hit a wall :(");
            LevelHandler.GetComponent<LevelHandler>().SelectResetButton();
        }
    }
}
