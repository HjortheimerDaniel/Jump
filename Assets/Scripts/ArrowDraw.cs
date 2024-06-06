using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField] private Image arrowImage;
    private Vector3 clickPosition;

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
            arrowImage.rectTransform.sizeDelta = Vector2.zero;
            clickPosition = Input.mousePosition; //take the position where we clicked
            arrowImage.rectTransform.position = clickPosition; // rectTransform = gets the screen position

        }
        if (Input.GetMouseButton(0)) //when pressing left mouseclick
        {

            Vector3 dragVector = clickPosition - Input.mousePosition; //calculate distance between where we clicked and released

            float size = dragVector.magnitude; //get the length of the vector, because we want to change the size of the arrow accordingly
            
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
