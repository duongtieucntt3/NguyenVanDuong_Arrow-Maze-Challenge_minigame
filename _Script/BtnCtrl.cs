
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : DuongMonoBehaviour
{
    [SerializeField] protected BtnClick btnClick;
    public BtnClick BtnClick { get => btnClick; }


    public GridLayoutGroup gridLayoutGroup;
    private Vector2Int cellPosition;
    public int row, column;
    public int VT = 0;

    protected void FixedUpdate()
    {
        UpdateCellPosition();
    }


    private void UpdateCellPosition()
    {
        Transform parentTransform = gridLayoutGroup.transform;
        int index = transform.GetSiblingIndex();
        int columnCount = gridLayoutGroup.constraintCount;

        row = index / columnCount;
        column = index % columnCount;

        VT = row * columnCount + column;
        cellPosition = new Vector2Int(column, row);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnClick();
    }

    protected virtual void LoadBtnClick()
    {
        if (this.btnClick != null) return;
        this.btnClick = transform.GetComponentInChildren<BtnClick>();
     //   Debug.Log(transform.name + ": LoadBtnClick", gameObject);
    }
}
