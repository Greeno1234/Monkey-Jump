using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public GameManager gameManager;
    public float velocity = 1;
    private Rigidbody2D rb;
    private int totalJumps;

    // Start is called before the first frame update
    void Start()
    {
        totalJumps = PlayerPrefs.GetInt("Total Jumps");
        rb = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            SoundManagerScript.PlaySound("Oo");
            rb.velocity = Vector2.up * velocity;
            totalJumps++;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.GameOver();
        PlayerPrefs.SetInt("Total Jumps", totalJumps);
    }

}
