using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float yRange = -1;

    public AudioClip hit;
    private AudioSource hitSource;

    public int pointValue;
    private int lifeMinus = -1;
    public ParticleSystem clickedParticle;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce (RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(),ForceMode.Impulse );

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        transform.position = RandomSpawnPos();
        hitSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        hitSource.PlayOneShot(hit, 1.0f);
        Destroy(gameObject);
        gameManager.UpdateScore(pointValue);
        Instantiate(clickedParticle, transform.position, transform.rotation);
        if (gameObject.CompareTag("Bad"))
        {
            gameManager.LifeUpdate(lifeMinus);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            if (!gameObject.CompareTag("Bad"))
            {
                gameManager.LifeUpdate(lifeMinus);
            }
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), yRange);
    }
}
