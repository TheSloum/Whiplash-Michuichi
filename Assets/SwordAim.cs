using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAim : MonoBehaviour
{
    public Transform plane;
    public float rotationSpeed = 5f;
public float angleMouse =0;
    public Vector3 mouseDelta = Vector3.zero;
   public float slashTolerance = 40;
    private Vector3 lastMousePosition = Vector3.zero;
    public float speedMouse = 0;
    public bool isRendererEnabled = false;


    void SlashDetect(Vector2 cursorPosition){
mouseDelta = Input.mousePosition - lastMousePosition;
 Vector2 mousePos = Input.mousePosition;
speedMouse = Mathf.Sqrt((mouseDelta.x)*(mouseDelta.x)+(mouseDelta.y)*(mouseDelta.y));
if ((speedMouse >= 80) && (cursorPosition.x <= slashTolerance) && (cursorPosition.x >= -slashTolerance) && (cursorPosition.y >= -slashTolerance) && (cursorPosition.y <= slashTolerance)){
    print("SLASH");
}

 lastMousePosition = Input.mousePosition;


    }





    void Update()
    {
        // get mouse position in screen coordinates
        Vector2 mousePos = Input.mousePosition;
        // normalize the mouse position
        Vector2 normalizedMousePos = new Vector2(((mousePos.x / Screen.width)-0.5f), (mousePos.y / Screen.height)-0.5f);
        
        SlashDetect(normalizedMousePos);
        angleMouse = Mathf.Atan2(normalizedMousePos.y, normalizedMousePos.x) * Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, (angleMouse-90f));
        }
}
