using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampRectTrans : MonoBehaviour
{
    private float padding = 10.0f;
    private float elementSize = 140.0f;
    private float viewSize = 100.0f;

    private RectTransform rt;
    private int amountElements;
    private float contentSize;


    // Start is called before the first frame update
    private void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    private void Update()
    {
        //clamp the rect transform
        amountElements = rt.childCount;
        contentSize = ((amountElements * (elementSize + padding)) - viewSize) * rt.localScale.x;

        if (rt.localPosition.x > padding)
        {
            rt.localPosition = new Vector2(padding, rt.localPosition.y);
        }
        else if (rt.localPosition.x < -contentSize)
        {
            rt.localPosition = new Vector2(-contentSize, rt.localPosition.y);
        }
    }
}
