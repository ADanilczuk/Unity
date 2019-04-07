using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour {

	public static bool Do_NOT = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;

    private Sprite _cardBack;
    private Sprite _cardFront;

    private GameObject _manager;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void setupGraphics()
    {
        _cardBack = _manager.GetComponent<GameMan>().getCardBack();
        _cardFront = _manager.GetComponent<GameMan>().getCardFront(_cardValue);

        flipcard();
    }

    public void flipcard()
    {
        if (_state == 0)
            _state = 1;
        else if (_state ==1)
            _state = 0;

        if (_state == 0 &&!Do_NOT)
            GetComponent<Image>().sprite = _cardBack;
        else if (!Do_NOT && _state == 1)
			GetComponent<Image>().sprite = _cardFront;
		else if (!Do_NOT && _state == 3)
			GetComponent<Image>().sprite = _cardFront;
    }

    public int cardValue 
    {
        get {return _cardValue;}
        set {_cardValue = value;}
    }

    public int state
    {
        get {return _state;}
        set {_state = value;}
    }

    public bool initialized 
    {
        get {return _initialized; }
        set {_initialized = value;}
    }

    public void falseCheck()
    {
        StartCoroutine (pause ()); 
    }

    IEnumerator pause()
    {   
        if (_state != 3)
            yield return new WaitForSeconds (1);
        if (_state == 0)
            GetComponent<Image>().sprite= _cardBack;
        else if (_state == 1 || _state == 3)
            GetComponent<Image>().sprite = _cardFront;
        Do_NOT = false;
    }

    

}
