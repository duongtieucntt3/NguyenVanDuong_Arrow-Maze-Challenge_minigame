using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickHandler : DuongMonoBehaviour, IPointerClickHandler
{
    [SerializeField] protected Transform image;

    [SerializeField] protected Dich dich;

    [SerializeField] protected bool isRight = false;
    [SerializeField] protected bool isLeft = false;
    [SerializeField] protected bool isUp = false;
    [SerializeField] protected bool isDown = false;

    public GridItemSwapper gridItemSwapper;
    private Vector2Int cellPosition;
    int row, column;

    protected void FixedUpdate()
    {
        UpdateCellPosition();
        
    }


    private void UpdateCellPosition()
    {
        Transform parentTransform = gridItemSwapper.gridLayoutGroup.transform;
        int index = transform.GetSiblingIndex();
        int columnCount = gridItemSwapper.gridLayoutGroup.constraintCount;

        row = index / columnCount;
        column = index % columnCount;


        cellPosition = new Vector2Int(column, row);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
      //  Debug.Log("click mouse: " + gameObject.name);
        if (this.isRight)
        {
            this.SwapHorizontal_Right(row, column);

        }
        else if (this.isLeft)
        {
            this.SwapHorizontal_Left(row, column);
        }
        else if(this.isDown) 
        {
            this.SwapVertical_Down(row, column);
        }
        else if(this.isUp)
        {
            this.SwapVertical_Up(row, column);
        }
    }
    public void SwapItems(Transform item1, Transform item2)
    {
        int index1 = item1.GetSiblingIndex();
        int index2 = item2.GetSiblingIndex();

        item1.SetSiblingIndex(index2);
        item2.SetSiblingIndex(index1);
    }


    public void SwapHorizontal_Right(int row, int column)
    {
        int ItemCount = gridItemSwapper.gridLayoutGroup.constraintCount;
        int dem = column + row * ItemCount;
        for (int i = dem; i < (row + 1) * ItemCount - 1; i++)
        {
            Transform child = gridItemSwapper.gridLayoutGroup.transform.GetChild(i);
            Transform child1 = gridItemSwapper.gridLayoutGroup.transform.GetChild(i + 1);

            if (child.tag == "Chan" || child1.tag == "Chan")
            {
                continue;
            }
            this.checkTag(child1);
            SwapItems(child, child1);

        }

    }
    public void SwapHorizontal_Left(int row, int column)
    {
        int ItemCount = gridItemSwapper.gridLayoutGroup.constraintCount;
        int dem = column + row * ItemCount;
        for (int i = dem; i > (row * ItemCount); i--)
        {
            Transform child = gridItemSwapper.gridLayoutGroup.transform.GetChild(i);
            Transform child1 = gridItemSwapper.gridLayoutGroup.transform.GetChild(i - 1);
            if (child.tag == "Chan" || child1.tag == "Chan")
            {
                continue;
            }          
            this.checkTag(child1);
            SwapItems(child, child1);

        }

    }

    public void SwapVertical_Down(int row, int column)
    {
        int ItemCount = gridItemSwapper.gridLayoutGroup.constraintCount;
        int countchill = gridItemSwapper.gridLayoutGroup.transform.childCount;
        for (int i = row; i < ((countchill / ItemCount)-1); i++)
        {
            Transform child = gridItemSwapper.gridLayoutGroup.transform.GetChild(i * ItemCount + column);
            Transform child1 = gridItemSwapper.gridLayoutGroup.transform.GetChild((i + 1) * ItemCount + column);
            if (child.tag == "Chan" || child1.tag == "Chan")
            {
                continue;
            }
            this.checkTag(child1);
            SwapItems(child, child1);
        }
    }
    public void SwapVertical_Up(int row, int column)
    {
        int ItemCount = gridItemSwapper.gridLayoutGroup.constraintCount;
        int countchill = gridItemSwapper.gridLayoutGroup.transform.childCount;
        for (int i = row; i > 0; i--)
        {
            Transform child = gridItemSwapper.gridLayoutGroup.transform.GetChild(i * ItemCount + column);
            Transform child1 = gridItemSwapper.gridLayoutGroup.transform.GetChild((i - 1) * ItemCount + column);
            if (child.tag == "Chan" || child1.tag == "Chan")
            {
                continue;
            }

            this.checkTag(child1);
            SwapItems(child, child1);
        }
    }
    protected virtual void checkTag(Transform child1)
    {

        if ( child1.tag == "dich")
        {
            //victory
            Debug.Log("chuc mung ban da ve dich");
            this.image.gameObject.SetActive(true);
            this.dich.ImageDich.gameObject.SetActive(false);
            InvokeRepeating("Win", 1,10);

        }
        if (child1.tag == "Left")
        {
            this.isLeft = true;
            this.isRight = false;
            this.isUp = false;
            this.isDown = false;
        }
        if (child1.tag == "Right")
        {
            this.isLeft = false;
            this.isRight = true;
            this.isUp = false;
            this.isDown = false;
        }
        if (child1.tag == "Up")
        {
            this.isLeft = false;
            this.isRight = false;
            this.isUp = true;
            this.isDown = false;
        }
        if (child1.tag == "Down")
        {
            this.isLeft = false;
            this.isRight = false;
            this.isUp = false;
            this.isDown = true;
        }
    }
    protected virtual void Win()
    {
        UIGameCtrl.Instance.Win.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }


}
