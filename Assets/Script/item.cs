using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public List<Sprite> ItemList, blurItem;
    public SpriteRenderer ItemRenderer;
    private int ItemIndex;
    // Start is called before the first frame update
    void Start()
    {
        idle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setItemIndex(int index)
    {
        this.ItemIndex = index;
    }

    public void blur()
    {
        ItemRenderer.sprite = blurItem[ItemIndex];
    }    

    public void idle()
    {
        ItemRenderer.sprite = ItemList[ItemIndex];
    }
}
