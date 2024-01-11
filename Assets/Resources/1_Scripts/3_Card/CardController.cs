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

public class �׽�Ʈ��CardHandler : CardHandler
{

    public �׽�Ʈ��CardHandler(CardController cardController) : base(cardController)
    {
        _cardController.SetViewTransform(new Vector3(-1200, 0, 0), new Vector3(0, 0, 0));
    }

    private void WorkDone()
    {
        _isWorking = false;
    }

    public override void MouseEnter()
    {
        //cardcontroller battlePanel�� ����
        Debug.Log("���콺 ����");
        CardMouseOver();
    }
    public override void MouseDown()
    {
        Debug.Log("���콺 Ŭ��");
        CardSelect();


    }

    public override void MouseExit()
    {

        Debug.Log("���콺 ����");
        CardMouseExit();

    }
}

public class ����CardHandler : CardHandler
{
    public ����CardHandler(CardController cardController) : base(cardController)
    {

    }

    public override void MouseEnter()
    {
        //cardcontroller battlePanel�� ����
    }
    public override void MouseDown()
    {

    }

    public override void MouseExit()
    {

    }
}

public class ����CardHandler : ICardHandler
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
public class �г�CardHandler : ICardHandler
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
public class ����CardHandler : ICardHandler
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

