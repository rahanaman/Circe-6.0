using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static UnityEditor.PlayerSettings;

public class CardView : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private RectTransform _nameRect;
    [SerializeField] private Text _nameText;

    [SerializeField] private RectTransform _descRect;
    [SerializeField] private Scripter _descScripter;

    [SerializeField] private Transform _subCon;


    public Vector3 Pos { get; private set; }
    public Vector3 Rot { get; private set; }




    private CardBase[] CardList() //�ڵ� ���⵵ ���߱�  
    {
        return Database.CardBaseList;
    }


    //�����ͷ� ���� ��� �ű�� �� ���� ��

    public void Init(CardBase card)
    {
        SetName(card.Name);
    }

    public void Init(Database.CardID id)
    {
        //string Name, string Desc, KeyValuePair<����ġID, int>[] ����ġList, int Cost, List<EffectID> EffectList
        SetName(CardList()[(int)id].Name);

    }


    #region ī�� ����, ����, �̸� ���� �� ��ġ ����

    public void SetSub(bool isActive)
    {
        _subCon.gameObject.SetActive(isActive);
    }
    public void SetDesc(string str)
    {
        _descScripter.Script(str);
        SetNamePos();
    }

    private void SetName(string str)
    {
        _nameText.text = str;
    }
    public void SetNamePos()
    {
        var posY = _descRect.rect.height;
        _nameRect.anchoredPosition = new Vector2(_nameRect.anchoredPosition.x,posY);
    }

    #endregion ī�� ����, �̸� ���� �� ��ġ ����


    #region ī�� Tranform ���� (ũ�� ��ġ ȸ��)

    public void UpdateTransform()
    {
        MoveTransform(Pos, Rot);
        SetScale(1.0f);
    }


    public void SetTransform(Vector3 pos, Vector3 rot)
    {
        Pos = pos;
        Rot = rot;
        DOTween.Kill(transform);
        transform.localPosition = pos;
        transform.localRotation = Quaternion.Euler(rot);
    }
    public void MoveTransform(Vector3 pos, Vector3 rot)
    {
        transform.DOLocalMove(pos, 0.5f);
        transform.DOLocalRotate(rot, 0.2f);        
    }

    public void SetScale(float scale) => transform.localScale = new Vector3(scale, scale);


    #endregion ī�� Tranform ���� (ũ�� ��ġ ȸ��)
}

