using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClick : BaseButton
{

    protected bool isOpen = false;
    [SerializeField] protected BtnCtrl btnCtrl;
    public BtnCtrl BtnCtrl { get => btnCtrl; }

    public BtnClickChan btnClickChan;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnCtrl();
    }
    protected virtual void LoadBtnCtrl()
    {
        if (this.btnCtrl != null) return;
        this.btnCtrl =  transform.parent.GetComponent<BtnCtrl>();
      //  Debug.Log(transform.name + ": LoadBtnCtrl", gameObject);
    }
    protected override void Start()
    {
        base.Start();
        this.button.gameObject.SetActive(false);
    }
    public override void OnClick()
    {
        Debug.Log("click mouse: " + gameObject.name);
        Transform child = btnCtrl.gridLayoutGroup.transform.GetChild(btnCtrl.VT);
        Transform child1 = btnClickChan.gridLayoutGroup.transform.GetChild(btnClickChan.VTChan);
        btnClickChan.OnClick();
        SwapItems(child, child1);

    }
    public void SwapItems(Transform item1, Transform item2)
    {
        int index1 = item1.GetSiblingIndex();
        int index2 = item2.GetSiblingIndex();

        item1.SetSiblingIndex(index2);
        item2.SetSiblingIndex(index1);
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }
    public virtual void Close()
    {
        this.button.gameObject.SetActive(false);
        this.isOpen = false;
    }
    public virtual void Open()
    {
        this.button.gameObject.SetActive(true);
        this.isOpen = true;
    }
}
