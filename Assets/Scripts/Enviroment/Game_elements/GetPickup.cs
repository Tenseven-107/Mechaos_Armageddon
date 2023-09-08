using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPickup : MonoBehaviour
{
    public GameObject pickup;
    private Renderer r;
    private AudioSource source;
    public ParticleSystem ps;
    private KeepScore scoreScript;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        source = GetComponent<AudioSource>();
        ps.Stop();
        scoreScript = FindObjectOfType<KeepScore>();
        //ps = GetComponentInChildren<ParticleSystem>();
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            r.enabled = false;
            GameObject.Destroy(gameObject, 0.6f);
            Instantiate(pickup,transform.position, Quaternion.identity);
            source.Play();
            ps.Play();
            scoreScript.AddScore(5);
            //ps.Stop();

            Debug.Log("test");

        }
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
