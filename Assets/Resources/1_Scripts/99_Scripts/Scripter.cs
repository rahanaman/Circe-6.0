using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Text 크기에 맞출 오브젝트 컴포넌트에 넣어두기 - 첫번째 자식 컴포넌트가 text 여야 함
public class Scripter : MonoBehaviour    
{
    /// <summary>
    /// 텍스트 UI 상위에 Recttransform을 가진 부모오브젝트에 넣어두기
    /// 하위 textUI는 RectTransform+contentsizefitter, Pivot은 0.5, 1으로 설정
    /// </summary>
    private RectTransform _parentRect;
    private RectTransform _rect;
    private Text _text;
    private float _yDelta;

    private void Awake()
    {
        _parentRect = GetComponent<RectTransform>();
        _rect = gameObject.transform.GetChild(0).GetComponent<RectTransform>();
        _text = gameObject.transform.GetChild(0).GetComponent<Text>();
        _yDelta = Math.Abs(gameObject.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y);
    }

    //스크립트 String을 받아와 content 크기에 맞게 조정하는 메소드
    public void Script(string script) 
    {

        _text.text = script;
        UpdateScript();
        
    }

    private void UpdateScript()
    {

        //LayoutRebuilder.ForceRebuildLayoutImmediate(content);
        LayoutRebuilder.ForceRebuildLayoutImmediate(_rect);
        _parentRect.sizeDelta = new Vector2(_parentRect.rect.width, _rect.rect.height + 2 * _yDelta); //
        LayoutRebuilder.ForceRebuildLayoutImmediate(_parentRect);
    }
}
