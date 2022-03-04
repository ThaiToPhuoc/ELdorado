using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class column : MonoBehaviour
{
    public item itemPrefab;

    public List<item> itemList;

    public float speed = 10f, height, scrollTime = 0f, time = 0f;

    public int[] result;

    private bool scrolling = false;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        result = new int[] {Random.Range(0,14), Random.Range(0, 14), Random.Range(0, 14) , Random.Range(0, 14), Random.Range(0, 14)};
        height = ActualResolutionHeight(Camera.main.orthographicSize) / 100;
        createItem();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(scrollTime > 0)
        {
            for (int i = 0; i < 5; i++)
            {
                itemList[i].transform.position += speed * Time.deltaTime * Vector3.down;
                if (itemList[i].transform.position.y < -height / 2 - 1f)
                {
                    itemList[i].transform.position = new Vector3(this.transform.position.x, height / 2 - 1f);
                    itemList[i].setItemIndex(Random.Range(0, 14));
                    itemList[i].blur();
                }
            }
            scrollTime -= Time.deltaTime;
        }

        else
        {
            stop();
        }
    }

    public int ActualResolutionHeight(float orthoSize)
    {
        return (int)(orthoSize * 2.0 * 100);
    }

    public void createItem()
    {
        float positionY = -height/2 - 1f;
        for(int i = 0; i < 5; i ++)
        {
            positionY += height/5;
            itemList.Add(Instantiate(itemPrefab, new Vector3(this.transform.position.x, positionY, 0), Quaternion.identity));
            itemList[i].transform.SetParent(this.transform);
            itemList[i].setItemIndex(Random.Range(0, 14));
        }
    }

    public void scroll()
    {
        scrollTime = time;
    }    

    public void stop()
    {
        if (itemList[0].transform.position.y > -height/2 + height/5 -1f)
        {
            for (int i = 0; i < 5; i++)
            {
                itemList[i].transform.position += speed * Time.deltaTime * Vector3.down;
                if (itemList[i].transform.position.y < -height / 2 - 1f)
                {
                    itemList[i].transform.position = new Vector3(this.transform.position.x, height / 2 - 1f);
                    itemList[i].setItemIndex(result[i]);
                    itemList[i].blur();
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            { 
                itemList[i].setItemIndex(result[i]);
                itemList[i].idle();
            }
        }
    }

    public void randomResult()
    {
        this.result = new int[] { Random.Range(0, 14), Random.Range(0, 14), Random.Range(0, 14), Random.Range(0, 14), Random.Range(0, 14) };
        for(int i = 0; i < 5; i++)
        {
            gameData.instance.result[index, i] = result[i];
        }
    }

    public void setScrollTime(float time)
    {
        this.time = time;
    }

    public void setIndex(int index)
    {
        this.index = index;
    }
}
