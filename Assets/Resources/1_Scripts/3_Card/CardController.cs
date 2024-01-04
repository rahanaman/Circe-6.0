using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using static Database;

public class CardController : MonoBehaviour
{
    [SerializeField] CardView _cardview;

    [SerializeField] private Transform _subCon;

    public void Init(CardID id)
    {
        _cardview.Init(id);
        InitSub();
    }




    private void InitSub()
    {
        
    }

    public void SetSub(bool isActive)
    {
        _cardview.SetSub(isActive);
    }


    // 사용자 입력 받아오기






}

