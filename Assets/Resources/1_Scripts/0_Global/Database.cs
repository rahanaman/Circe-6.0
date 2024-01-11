using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Database;

public static class Database
{
    public enum CardID
    {
        타격,

    }

    public enum EffectID
    {

    }

    public enum CardStateID
    {
        전투,

    }

    public static CardBase[] CardBaseList;


    public static CardBase GetCardBase(CardID id)
    {
        switch (id)
        {
            case CardID.타격:
                return new 타격Card();

            default:
                throw new Exception("존재하지 않는 id 요청입니다");

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

public class 타격Card : CardBase
{
    public 타격Card()
    {
        Name = "타격";
        Desc = "피해를 {0} 줍니다. <color=olive>파도</color>: 피해가 1 증가합니다.";
        Data = new int[] { 5 };

        //Subs = new EffectID[] { EffectID.경감 };
    }
}
