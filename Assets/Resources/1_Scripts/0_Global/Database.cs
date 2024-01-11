using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Database;

public static class Database
{
    public enum CardID
    {
        Ÿ��,

    }

    public enum EffectID
    {

    }

    public enum CardStateID
    {
        ����,

    }

    public static CardBase[] CardBaseList;


    public static CardBase GetCardBase(CardID id)
    {
        switch (id)
        {
            case CardID.Ÿ��:
                return new Ÿ��Card();

            default:
                throw new Exception("�������� �ʴ� id ��û�Դϴ�");

        }
    }

}

public class CardBase
{
    private string _name;
    public string Name { get => _name; set => _name = value; }

    private string _desc;
    public string Desc { get => _desc; set => _desc = value; }

    private int[] _data;
    public int[] Data { get=> _data; set => _data = value; }

    private EffectID[] _subs;
}

public class Ÿ��Card : CardBase
{
    public Ÿ��Card()
    {
        Name = "Ÿ��";
        Desc = "���ظ� {0} �ݴϴ�. <color=olive>�ĵ�</color>: ���ذ� 1 �����մϴ�.";
        Data = new int[] { 5 };

        //Subs = new EffectID[] { EffectID.�氨 };
    }
}
