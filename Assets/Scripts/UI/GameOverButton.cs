using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GameOverButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Text txt;
    Color baseColor;
    Button btn;
    bool interactableDelay;

    void Start()
    {
        txt = GetComponentInChildren<Text>();
        baseColor = txt.color;
        btn = gameObject.GetComponent<Button>();
        interactableDelay = btn.interactable;
    }

    void Update()
    {
        if (btn.interactable != interactableDelay)
        {
            if (btn.interactable)
            {
                txt.color = baseColor * btn.colors.normalColor * btn.colors.colorMultiplier;
            }
            else
            {
                txt.color = baseColor * btn.colors.disabledColor * btn.colors.colorMultiplier;
            }
        }
        interactableDelay = btn.interactable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = Color.black;
            btn.image.fillCenter = true;
        }
        else
        {
            txt.color = baseColor;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = Color.black;
            btn.image.fillCenter = true;
        }
        else
        {
            txt.color = baseColor;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = Color.white;
            btn.image.fillCenter = false;
        }
        else
        {
            txt.color = baseColor;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (btn.interactable)
        {
            txt.color = Color.white;
            btn.image.fillCenter = false;
        }
        else
        {
            txt.color = baseColor;
        }
    }
}
