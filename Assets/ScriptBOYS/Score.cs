using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int totalscore = 0;
    [SerializeField] GameObject textOBJ;
    void Start()
    {
        textOBJ.GetComponent<TextMesh>().text = ("Score: " + 0);
    }

    void FixedUpdate()
    {
        textOBJ.GetComponent<TextMesh>().text = ("Score: " + totalscore);
        if (Input.GetKey(KeyCode.E))
        {
            addScore(10);
        }
    }

    public void addScore(int i)
    {
        totalscore += i;
        Debug.Log(totalscore);
    }
}
