using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Text ũ�⿡ ���� ������Ʈ ������Ʈ�� �־�α� - ù��° �ڽ� ������Ʈ�� text ���� ��
public class Scripter : MonoBehaviour    
{
    /// <summary>
    /// �ؽ�Ʈ UI ������ Recttransform�� ���� �θ������Ʈ�� �־�α�
    /// ���� textUI�� RectTransform+contentsizefitter, Pivot�� 0.5, 1���� ����
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

    //��ũ��Ʈ String�� �޾ƿ� content ũ�⿡ �°� �����ϴ� �޼ҵ�
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
