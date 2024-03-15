using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;

public class Item : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IDragHandler
    {
    public int itemIndex;
    public bool isTogBG;
    public event UnityAction<Item> OnItemClicked, OnItemDroppedOn, OnItemBeginDrag, OnItemEndDrag, OnItemMoseRightClick;
    public void OnPointerClick(PointerEventData eventData)
        {
        
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                OnItemMoseRightClick?.Invoke(this);
            }
            else
            {
                OnItemClicked?.Invoke(this);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            //if (empty) return;
            OnItemBeginDrag?.Invoke(this);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            OnItemEndDrag?.Invoke(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            OnItemDroppedOn?.Invoke(this);
        }
       
        public void OnDrag(PointerEventData eventData)
        {
           
        }


    }

