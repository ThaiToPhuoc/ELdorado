using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layoutColumn : MonoBehaviour
{
    public column columnPrefab;

    public List<column> columnList;

    private bool scrolling = false;
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
                columnList[i].scroll();
            }
        }
    }

    public int ActualResolutionWidth(float orthoSize)
    {
        return (int)(orthoSize * 2.0 * (Screen.width * 1.0) / Screen.height * 100);
    }
    private void createColumn()
    {
        float positionX = -ActualResolutionWidth(Camera.main.orthographicSize) / 200 + 1.5f;
        for (int i = 0; i < 5; i++)
        {
            positionX += ActualResolutionWidth(Camera.main.orthographicSize) / 820f;
            columnList.Add(Instantiate(columnPrefab, new Vector3(positionX, this.transform.position.y, 0), Quaternion.identity));
            columnList[i].transform.SetParent(this.transform);
        }
    }

    public void scroll()
    {
        scrolling = true;
    }    
}
