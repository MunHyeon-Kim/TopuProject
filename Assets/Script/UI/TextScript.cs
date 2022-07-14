using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{

    public Text t;
    [SerializeField]
    private int mode;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        switch (mode)
        {
            case 1:
                t.text = $"Score   {DataManager.Score}";
                break;
            case 2:
                t.text = $"Life   {DataManager.Life}";
                break;
            case 3:
                t.text = $"Spell   {DataManager.Spell}";
                break;
            case 4:
                t.text = $"Power   {DataManager.Power:F1}";
                break;
            default:
                break;
        }
    }
}
