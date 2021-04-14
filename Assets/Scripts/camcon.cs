using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcon : MonoBehaviour
{
    public GuiExample gui;

    void LateUpdate() {
        if(gui.boxes.Count > 1) {
            this.transform.LookAt(gui.boxes[gui.boxes.Count - 1].transform);
        }
        
    }
}
