using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movinghair : MonoBehaviour
{

    private float speed = 2.5f;
    private float HardSpeed = 5f;
    public double incriment;
    public GameObject background;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainMenu.hard == true)
        {
            transform.position += Vector3.left * HardSpeed * Time.deltaTime;       
        }
        else
        {
            incriment = Score.score * 0.05;
            //incriment = 2 ** (-0.1 * Score.score);
            transform.position += Vector3.left * (speed + (float)incriment) * Time.deltaTime;
        }        
    }
}
