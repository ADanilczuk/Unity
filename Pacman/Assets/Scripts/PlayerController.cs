using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerController : MonoBehaviour 
{
	
	private float xStep, zStep;
    private AudioSource source;
    private bool touch;

    public AudioClip success;
	public float speed;
    public float step;
   
    public TMP_Text countText;
	public GameObject winText;

    private int count;
	
	void Start()
	{
		source = GetComponent<AudioSource>();
        count = 0;
		 winText.SetActive(false);
         touch = false;
        //countText = GetComponent<TMP_Text>();
		SetCountText();
	}


    void MovePacman()
    {
        Vector3 currentPos = transform.position;
        currentPos.x += xStep;
        currentPos.z += zStep;
        transform.position = currentPos;
    }

    void CheckDirection()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zStep = -step;
            xStep = 0;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            zStep = step;
            xStep = 0;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            xStep = -step;
            zStep = 0;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            xStep = step;
            zStep = 0;
        }
    }

    void Update()
    {
        if (!touch)
        {
            MovePacman();
            CheckDirection();
            //debugLog.(countText.GetComponent<TextMeshPro>().text);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            other.gameObject.SetActive(false);
            count++;
            Debug.Log(count);
            
			SetCountText();
		}
    }

     public void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag == "Wall")
        {
            xStep = 0;
            zStep = 0;
            MovePacman();
        }
	}
	
	void SetCountText()
    {
        countText.SetText("Points: {0}", count);
        if (count >= 68)
        {
            //touch = true;
			//winText.SetActive(true);
			//source.PlayOneShot(success);
			//System.Threading.Thread.Sleep(5000);
            //StartCoroutine(waits());
            SceneManager.LoadScene("Win");
        }
    }

    IEnumerator waits()
    {
        yield return new WaitForSeconds(360);
    }

   
}

