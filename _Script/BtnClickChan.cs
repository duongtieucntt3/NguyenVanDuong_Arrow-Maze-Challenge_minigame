using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnClickChan : BaseButton
{
    public BtnCtrl btnCtrlUp;
    public BtnCtrl btnCtrlDown;
    public BtnCtrl btnCtrlLeft;
    public BtnCtrl btnCtrlRight;
    public GridLayoutGroup gridLayoutGroup;

    private Vector2Int cellPosition;
    public int row, column;
    public int VTChan;
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

 
        cellPosition = new Vector2Int(column, row);
    }
    public override void OnClick()
    {

       // Debug.Log("click mouse: " + gameObject.name);
        int ItemCount = gridLayoutGroup.constraintCount;
        int countchill = gridLayoutGroup.transform.childCount;

        int dem1 = (row - 1) * ItemCount + column;
        int dem2 = (row + 1) * ItemCount + column;
        int dem3 = row * ItemCount + column - 1;
        int dem4 = row * ItemCount + column + 1;
         VTChan = row * ItemCount + column;

        if (column == 0) { dem3 += 1;  }
        if ((countchill / ItemCount) - 1 == row) dem2 -= ItemCount;
        if (row == 0) dem1 += ItemCount;
        if (column + 1 == ItemCount) dem4 -= 1;

        Transform childUp = gridLayoutGroup.transform.GetChild(dem1);
        btnCtrlUp = childUp?.GetComponentInChildren<BtnCtrl>();
        btnCtrlUp?.BtnClick.Toggle();
        


        Transform childDown = gridLayoutGroup.transform.GetChild(dem2);
      btnCtrlDown = childDown?.GetComponentInChildren<BtnCtrl>();
        btnCtrlDown?.BtnClick.Toggle();


        Transform childLeft = gridLayoutGroup.transform.GetChild(dem3);
        btnCtrlLeft = childLeft?.GetComponentInChildren<BtnCtrl>();
        btnCtrlLeft?.BtnClick.Toggle();


        Transform childRight = gridLayoutGroup.transform.GetChild(dem4);
         btnCtrlRight = childRight?.GetComponentInChildren<BtnCtrl>();
        btnCtrlRight?.BtnClick.Toggle();

    }

}
