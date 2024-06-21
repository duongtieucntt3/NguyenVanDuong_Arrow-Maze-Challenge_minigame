using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GridItemSwapper : DuongMonoBehaviour
{
    public GridLayoutGroup gridLayoutGroup;
    [SerializeField] protected Image image;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponentInChildren<Image>();
     //   Debug.Log(transform.name + ": LoadImage", gameObject);
    }

}
