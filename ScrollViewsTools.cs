/******************************************************************************
 * Spine Runtimes License Agreement
 * Last updated January 1, 2020. Replaces all prior versions.
 *
 * Copyright (c) 2013-2020
 *
 * Integration of the Spine Runtimes into software or otherwise creating
 * derivative works of the Spine Runtimes is permitted under the terms and
 * conditions of Section 2 of the Spine Editor License Agreement:
 *
 * THE SPINE RUNTIMES ARE PROVIDED BY ESOTERIC SOFTWARE LLC "AS IS" AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL ESOTERIC SOFTWARE LLC BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES,
 * BUSINESS INTERRUPTION, OR LOSS OF USE, DATA, OR PROFITS) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THE SPINE RUNTIMES, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *****************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
[SLua.CustomLuaClass]
public class ScrollViewsTools : UIBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IScrollHandler//, ICanvasElement, ILayoutElement, ILayoutGroup
{
    private Transform temTransform;
    private GameObject obj;
    void Start()
    {
        Init();
    }
    public void Init()
    {
        temTransform = this.transform.parent;
        for(;temTransform.parent!=null;)
        {
            temTransform = temTransform.parent;
            if (temTransform.GetComponent<Scrollbar>() != null) ;
            {
                obj = temTransform.gameObject;
                break;
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (obj != null)
        {
            ExecuteEvents.ExecuteHierarchy(obj, eventData, ExecuteEvents.beginDragHandler);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (obj != null)
        {
            ExecuteEvents.ExecuteHierarchy(obj, eventData, ExecuteEvents.dragHandler);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (obj != null)
        {
            ExecuteEvents.ExecuteHierarchy(obj, eventData, ExecuteEvents.endDragHandler);
        }
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (obj != null)
        {
            ExecuteEvents.ExecuteHierarchy(obj, eventData, ExecuteEvents.initializePotentialDrag);
        }
    }

    public void OnScroll(PointerEventData eventData)
    {
        if (obj != null)
        {
            ExecuteEvents.ExecuteHierarchy(obj, eventData, ExecuteEvents.scrollHandler);
        }
    }

    
    
   
}
