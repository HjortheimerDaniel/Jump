using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warning : MonoBehaviour
{
    private int timer;
    SpriteRenderer spriteRenderer;
    private int warnings = 0;
    Transform transform_;

   // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        FlashingWarning();
    }

    void FlashingWarning()
    {
        
        if(warnings < 2)
        {
            timer++;
            if (timer <= 40)
            {
                spriteRenderer.enabled = true;
            }

            else
            {
                spriteRenderer.enabled = false;
            }

            if (timer >= 80)
            {
                timer = 0;
                warnings++;
            }
        }
        
    }

    public int GetWarning() { return warnings; }

    public void SetWarning(int warning) {  warnings = warning; }

    public void MoveToRight()
    {
        transform_.position = new Vector3(44.0f,34.6f,0.0f);

    }

}
