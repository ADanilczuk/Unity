using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameMan : MonoBehaviour {

    public Sprite[] cardFront;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;
    public Button resume_button;

    private bool _init = false;
    private int _matches = 12;

	// Update is called once per frame
	void Update ()
    {
        if (!_init)
            initializeCards();

        if (Input.GetMouseButtonUp(0))
            checkCards();

        resume_button.onClick.AddListener(TaskOnClick2);
	}

    public void TaskOnClick2()
    {
        SceneManager.LoadScene("Menu");
    }

    void initializeCards()
    {
        for (int id=0; id <2; id++)
        {
            for (int i=1; i <13; i++)
            {
                bool test = false;
                int choice = 0;
                while(!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards [choice].GetComponent<Card>().initialized);
                }
                cards [choice].GetComponent<Card>().cardValue = i;
                cards [choice].GetComponent<Card>().initialized = true;
            }
        }
        foreach (GameObject c in cards)
             c.GetComponent<Card>().setupGraphics();

        if (!_init)
            _init = true;
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFront(int i)
    {
        return cardFront [i - 1];
    }

    void checkCards()
    {
        List<int> c = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 1)
                c.Add(i);
        }
        if (c.Count == 2)
            cardComparison(c);
    }

    void cardComparison(List<int> c)
    {
        Card.Do_NOT = true;

        int x=0;
        if (cards[ c[0]].GetComponent<Card>().cardValue == cards[ c[1]].GetComponent<Card>().cardValue)
        {
            x=2;
            _matches--;
            matchText.text = "Number of Matches left: " + _matches;
            if (_matches == 0) SceneManager.LoadScene ("Succes");
        }
        Debug.Log(c.Count);

        for (int i=0; i < c.Count; i++)
        {
            Debug.Log(c[i]);
            cards[ c[i]].GetComponent<Card>().state = x;
            cards[ c[i]].GetComponent<Card>().falseCheck();
        }

    }

        void Reverse_all()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state == 0)
            {
                cards[i].GetComponent<Card>().state = 3;
				
                cards[i].GetComponent<Card>().flipcard();
            }
        }
       StartCoroutine(waits());

        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().state != 2)
            {
                cards[i].GetComponent<Card>().state = 0;
                cards[i].GetComponent<Card>().flipcard();
                
            }
        }
    }

        IEnumerator waits()
        {   
            yield return new WaitForSeconds(8);

        }

}
