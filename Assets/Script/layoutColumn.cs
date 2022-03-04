using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class layoutColumn : MonoBehaviour
{
    public column columnPrefab;

    public List<column> columnList;

    public GameObject blockInput;

    public Button scrollBtn;

    public Sprite[] button;

    private bool scrolling = false;

    private float countDown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        createColumn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(scrolling)
        {
            for (int i = 0; i < 5; i++)
            {
                columnList[i].randomResult();
                columnList[i].scroll();
            }    
            scrolling = false;
        }    

        if(countDown > 0)
        {
            countDown -= Time.deltaTime;
            scrollBtn.image.sprite = button[1];
            blockInput.SetActive(true);
        }
        else
        {
            scrollBtn.image.sprite = button[0];
            blockInput.SetActive(false);
        }
    }

    public int ActualResolutionWidth(float orthoSize)
    {
        return (int)(orthoSize * 2.0 * (Screen.width * 1.0) / Screen.height * 100);
    }
    private void createColumn()
    {
        float scrollTime = 2.2f;
        float positionX = -ActualResolutionWidth(Camera.main.orthographicSize) / 200 + 1.5f;
        for (int i = 0; i < 5; i++)
        {
            positionX += ActualResolutionWidth(Camera.main.orthographicSize) / 820f;
            columnList.Add(Instantiate(columnPrefab, new Vector3(positionX, this.transform.position.y, 0), Quaternion.identity));
            columnList[i].transform.SetParent(this.transform);
            columnList[i].setIndex(i);
            columnList[i].setScrollTime(scrollTime);
            scrollTime += 0.4f;
        }
    }

    public void scroll()
    {
        countDown = 3f;
        scrolling = true;
    }    

}
