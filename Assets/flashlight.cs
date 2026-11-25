using UnityEngine;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public GameObject ON;
    public GameObject OFF;
    private bool isON;

    // start is called before the first frame update
    void start()
    {
        ON.SetActive(false);
        OFF.SetActive(true);
        isON = false;

    }

    // update is called once per frame 
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (isON)
            {
                ON.SetActive(false);
                OFF.SetActive(true);

            }

            if (!isON)
            {
                ON.SetActive(true);
                OFF.SetActive(false);

            }

            isON = !isON;

        }

    }

}