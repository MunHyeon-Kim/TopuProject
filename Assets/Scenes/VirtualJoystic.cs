using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 키보드, 마우스, 터치를 이벤트로 오브젝트에 보낼 수 있는 기능을 지원

public class VirtualJoystic : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public CharacterController ct;

    


    [SerializeField]
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)] 
    private float leverRange;

    
    public static Vector2 inputVector;
    [SerializeField]
    public static bool isInput;


    private void Awake() 
    { 
        rectTransform = GetComponent<RectTransform>(); 
    }


    public void OnPointerDown(PointerEventData eventData)
    {

        ControlJoystickLever(eventData);
        isInput = true;

    }


    public void OnDrag(PointerEventData eventData)
    {

        ControlJoystickLever(eventData);
        

    }

    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition;
        var clampedDir = inputDir.magnitude < leverRange ? inputDir
            : inputDir.normalized * leverRange; 
        lever.anchoredPosition = clampedDir; 
        inputVector = clampedDir / leverRange;

    }


    public void OnPointerUp(PointerEventData eventData) 
    {
        //Debug.Log("End");

        lever.anchoredPosition = Vector2.zero;
        isInput = false;
    }

    void Update()
    {
        
    }

   

}
