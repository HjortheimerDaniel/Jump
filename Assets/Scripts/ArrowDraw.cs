using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField] private Image arrowImage;
    public Vector3 clickPosition;
    public Vector3 dragVector;

    // Start is called before the first frame update
    void Start()
    {
        arrowImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DrawArrow();
    }

    void DrawArrow()
    {
        if(Input.GetMouseButtonDown(0)) //when we press left mouseclick
        {
            arrowImage.gameObject.SetActive(true);
            //float r = Random.Range(0, 1f);
            //float g = Random.Range(0, 1f);
            //float b = Random.Range(0, 1f);
            //arrowImage.color = new Color(r, g, b);
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            clickPosition = Input.mousePosition; //take the position where we clicked
            arrowImage.rectTransform.position = clickPosition; // rectTransform = gets the screen position

        }
        if (Input.GetMouseButton(0)) //when pressing left mouseclick
        {

            dragVector = clickPosition - Input.mousePosition; //calculate distance between where we clicked and released

            float size = dragVector.magnitude /2; //get the length of the vector, because we want to change the size of the arrow accordingly
            Color color = new Color(1, 1, 1);
            float factor = Mathf.Clamp01(1 - size / 1000); // calculate the factor to decrease green and blue. This clamps the value between 1 and 0
            color.g = factor;
            color.b = factor;
           // Debug.Log($"Color: {color}");
            arrowImage.color = color;

            //float angleRad = Mathf.Atan2(dragVector.y, dragVector.x); //get the angle

            //arrowImage.rectTransform.position = clickPosition; //move the mouse to the position we clicked

            arrowImage.rectTransform.right = dragVector; //make the arrow point in the way we are dragging, and 'right' is because the sprite is facing 'right'

            arrowImage.rectTransform.sizeDelta = Vector2.one * size;

            //arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);

            //arrowImage.rectTransform.sizeDelta = new Vector2 (size, size);  
        }
        else if (Input.GetMouseButtonUp(0)) 
        {
            arrowImage.gameObject.SetActive(false);
        }
    }
}
