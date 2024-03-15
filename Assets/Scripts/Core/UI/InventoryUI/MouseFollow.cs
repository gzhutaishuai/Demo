using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    List<Item> items = new List<Item>();
    private void Awake()
    {
        canvas=transform.root.GetComponent<Canvas>();
    }

    private void Update()
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, Input.mousePosition, Camera.main, out pos);
        transform.position = canvas.transform.TransformPoint(pos);
        //items.IndexOf();
    }
}
