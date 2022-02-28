using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class column : MonoBehaviour
{
    public item itemPrefab;

    public List<item> itemList;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        createItem();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int ActualResolutionHeight(float orthoSize)
    {
        return (int)(orthoSize * 2.0 * 100);
    }

    public void createItem()
    {
        float positionY = -ActualResolutionHeight(Camera.main.orthographicSize)/200 - 1f;
        for(int i = 0; i < 5; i ++)
        {
            positionY += ActualResolutionHeight(Camera.main.orthographicSize) / 500;
            itemList.Add(Instantiate(itemPrefab, new Vector3(this.transform.position.x, positionY, 0), Quaternion.identity));
            itemList[i].transform.SetParent(this.transform);
            itemList[i].setItemIndex(Random.Range(0,14));
        }
    }

    public void scroll()
    {
        for(int i = 0; i < 5; i++)
        {
            itemList[i].blur();
            itemList[i].transform.position += speed * Time.deltaTime * Vector3.down;
            if (itemList[i].transform.position.y < -ActualResolutionHeight(Camera.main.orthographicSize) / 200 - 1f)
            {
                itemList[i].transform.position = new Vector3(this.transform.position.x, ActualResolutionHeight(Camera.main.orthographicSize) / 200 - 1f);
                itemList[i].setItemIndex(Random.Range(0, 14));
            }
        }    
    }    
}
