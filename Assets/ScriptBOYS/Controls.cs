using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public Rigidbody bullet;
    public Transform spawnPoint;
    private Vector3 target;
    [SerializeField] private GameObject DieText;
    [SerializeField] private GameObject hpOBJ;
    private int HP = 3;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        PrintHP();
    }

    // Update is called once per frame
    float nextFire = 0f;
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            Debug.Log("Fire");
            Fire();
            nextFire = Time.time + .2f;
        }
        //Move to mouse
        Vector3 mPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 80);
        target = Camera.main.ScreenToWorldPoint(mPos);
        if(Input.mousePosition.x > 75)
        {
            mPos = new Vector3(75, Input.mousePosition.y, 80);
        }
        else if(Input.mousePosition.x < -75)
        {
            mPos = new Vector3(-75, Input.mousePosition.y, 80);
        }
        //Debug.Log(target);
        transform.position = Vector3.MoveTowards(transform.position, target, 100 * Time.fixedDeltaTime * Time.timeScale);
        
    }

    void Fire()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Rigidbody bulletInstance;
        bulletInstance = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as Rigidbody; // This is where I don't understand why?!?!
        bulletInstance.AddForce(spawnPoint.forward * 7500f);
    }

    void OnTriggerEnter(Collider col)
    {
        Debug.Log("You got hit SON");
        if (col.CompareTag("EnemyBullet"))
        {
            HP--;
            PrintHP();
        }
        if (HP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
        Time.timeScale = 0;
        DieText.SetActive(true);
        //Visa Gameover screen
        //Explosioneffekt
    }

    void PrintHP()
    {
        hpOBJ.GetComponent<TextMesh>().text = ("");
        for (int i = 0; i < HP; i++)
        {
            hpOBJ.GetComponent<TextMesh>().text += ("*");
        }
    }
}
