using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody bullet;
    private Transform Player;
    private int pointValue = 100;
    private int hp = 3;
    public List<Transform> spawnPoint;
    [SerializeField] private Transform target;
    private float nextFire;
    [SerializeField] float speed = 10.5f; 
    AudioSource audioData;
    [SerializeField] bool isPattern = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Target").GetComponent<Transform>();
    }

    // Update is called once per frame
    int burstCounter = 0; 
    void FixedUpdate()
    {
        if(!isPattern)
        {
        //Lookat player
        transform.rotation = Quaternion.LookRotation(Player.position - transform.position) * Quaternion.Euler(0, -180, 0);
        }
        else
        {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * 3 * Time.deltaTime * Time.timeScale);
        }

        //Go towards target (not player)
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime * Time.timeScale);

        //Shoot ever ynow and then
        if (Time.time > nextFire)
        {
            if(burstCounter == 3)
            {
                nextFire = Time.time + 2f;
                burstCounter = 0;
            }
            else
            {
                nextFire = Time.time + .05f;
                burstCounter++;
            }
            Fire();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("PlayerBullets"))
        {
            Damage();
            Destroy(col.GetComponent<GameObject>());
        }
    }

    void Fire()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Rigidbody bulletInstance;
        foreach(Transform sp in spawnPoint)
        {
        bulletInstance = Instantiate(bullet, sp.position, sp.rotation) as Rigidbody; // This is where I don't understand why?!?!
        bulletInstance.AddForce(sp.forward * 5000f);
        }
    }

    //Die
    void Damage()
    { 
        hp--;
        if(hp > 0)
        {
            Player.GetComponent<Score>().addScore(pointValue / 10);
        }
        else
        {
            Player.GetComponent<Score>().addScore(pointValue);
            Destroy(this.gameObject);
        }
    }

    //If died by player, add score

    //Spawn like 20 of em
}
