using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using static Database;

public class CardController : MonoBehaviour
{
    [SerializeField] CardView _cardview;
    private ICardHandler _handler;
    private CardStateID _state;


    public void Init(CardStateID id)
    {
        _state = id;

    }

    public void Init(CardID id)
    {
        _cardview.Init(id);
    }


}



public interface ICardHandler
{
    void MouseEnter();
    void MouseDown();
    void MouseExit();
}

public abstract class CardHandler : ICardHandler
{
    protected CardController _cardController;
    public CardHandler(CardController cardController)
    {
        _cardController = cardController;
    }
    public abstract void MouseDown();

    public abstract void MouseEnter();


    public abstract void MouseExit();

    protected void CardClick()
    {
        EventManager.Instance.CallOnExecuteCard(_cardController);
    }
    protected void CardMouseOver()
    {
        EventManager.Instance.CallOnCardMouseOver(_cardController);
    }

    protected void CardMouseExit()
    {
        EventManager.Instance.CallOnCardMouseExit();
    }

    protected void CardSelect()
    {
        EventManager.Instance.CallOnSelectCard(_cardController);
    }
    protected void Set()
    {

    }


}

public class 테스트용CardHandler : CardHandler
{

    public 테스트용CardHandler(CardController cardController) : base(cardController)
    {
        _cardController.SetViewTransform(new Vector3(-1200, 0, 0), new Vector3(0, 0, 0));
    }

    private void WorkDone()
    {
        _isWorking = false;
    }

    public override void MouseEnter()
    {
        //cardcontroller battlePanel로 전달
        Debug.Log("마우스 들어옴");
        CardMouseOver();
    }
    public override void MouseDown()
    {
        Debug.Log("마우스 클릭");
        CardSelect();


    }

    public override void MouseExit()
    {

        Debug.Log("마우스 나감");
        CardMouseExit();

    }
}

public class 전투CardHandler : CardHandler
{
    public 전투CardHandler(CardController cardController) : base(cardController)
    {

    }

    public override void MouseEnter()
    {
        //cardcontroller battlePanel로 전달
    }
    public override void MouseDown()
    {

    }

    public override void MouseExit()
    {

    }
}

public class 보상CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
public class 패널CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}
public class 도감CardHandler : ICardHandler
{
    public void MouseEnter()
    {

    }
    public void MouseDown()
    {

    }

    public void MouseExit()
    {

    }
}

