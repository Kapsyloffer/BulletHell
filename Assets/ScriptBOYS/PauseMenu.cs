using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PauseItem;
    void Start()
    {
        Time.timeScale = 1;
        PauseItem.SetActive(false);
        Debug.Log("Started");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
            PauseItem.SetActive(true);
            Debug.Log("Paused");
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
            PauseItem.SetActive(false);
            Debug.Log("Unpaused");
        }
    }
}
