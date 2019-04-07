using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using System;
using System.Threading;

public class GhostScript : MonoBehaviour {

    public GameObject target;
    public NavMeshAgent agent;
    private AudioSource source;

    public GameObject Losetext;
    public AudioClip fail;


	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        Losetext.SetActive(false);
		agent= GetComponent<NavMeshAgent>();
        if (target==null)
            target = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.transform.position;
	}

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
           // Losetext.SetActive(true);
            //source.PlayOneShot(fail); 
            //touched();
            //StartCoroutine(waits());
            SceneManager.LoadScene("Lose");
        }
    }

    /*
    IEnumerator waits()
    {
        yield return new WaitForSeconds(30.0f);       
    }
*/
	void touched()
	{
		Losetext.SetActive(true);
        source.PlayOneShot(fail);
	}
}
