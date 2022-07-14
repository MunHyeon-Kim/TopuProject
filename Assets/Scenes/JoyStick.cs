using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class JoyStick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    RectTransform m_rectBack;
    RectTransform m_rectJoystick;

    [SerializeField]
    private bool isinput;

    Transform m_trCube;
    float m_fRadius;
    float m_fSpeed = 5.0f;
    float m_fSqr = 0f;

    Vector3 m_vecMove;

    Vector2 m_vecNormal;

    bool m_bTouch = false;


    void Start()
    {
       
    }

    void Update()
    {
      

    }

    public void OnBeginDrag(PointerEventData eventData)
    {

        isinput = true;

    }

    void OnTouch(Vector2 vecTouch)
    {
        Debug.Log("Touch");
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
       
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Down");
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Up");
       
    }
}
