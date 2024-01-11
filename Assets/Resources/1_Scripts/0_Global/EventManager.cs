using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager:MonoBehaviour
{
    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
            {
                throw new System.Exception("EventManager가 Scene에 없습니다.");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public delegate void CardEvent(CardController card);
    public delegate void VoidEvent();



    public CardEvent CardMouseOver;
    public VoidEvent CardMouseExit;
    public CardEvent ExecuteCard;
    public CardEvent SelectCard;



    public void CallOnCardMouseOver(CardController card)
    {
        CardMouseOver?.Invoke(card);
    }

    public void CallOnCardMouseExit()
    {
        CardMouseExit?.Invoke();
    }

    public void CallOnExecuteCard(CardController card)
    {
        ExecuteCard?.Invoke(card);
    }

    public void CallOnSelectCard(CardController card)
    {
        SelectCard?.Invoke(card);
    }


}
