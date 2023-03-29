using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAnim : MonoBehaviour
{
private Animator anim;
    
public float angleMouse = 0;
    // Start is called before the first frame update
    void Start()
    {
anim = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        // normalize the mouse position
        Vector2 normalizedMousePos = new Vector2(((mousePos.x / Screen.width)-0.5f), (mousePos.y / Screen.height)-0.5f);
        angleMouse = Mathf.Atan2(normalizedMousePos.y, normalizedMousePos.x) * Mathf.Rad2Deg;

        anim.SetFloat("Cos", Mathf.Cos((angleMouse * Mathf.PI)/180));
        anim.SetFloat("Sin", Mathf.Sin((angleMouse * Mathf.PI)/180));
        
    }
}
