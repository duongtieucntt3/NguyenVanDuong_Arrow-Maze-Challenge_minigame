
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : DuongMonoBehaviour
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected override void Start()
    {
        base.Start();
        this.OnClickButton();


    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }
    protected virtual void LoadButton()
    {
        if (this.button != null) return;
        this.button = GetComponentInChildren<Button>();
      //  Debug.LogWarning(transform.name + ": LoadButton", gameObject);
    }
    protected virtual void OnClickButton()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    public abstract void OnClick();


}
