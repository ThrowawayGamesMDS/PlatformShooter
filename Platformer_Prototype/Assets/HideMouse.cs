using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour {

    CursorLockMode wantedMode;

    // Apply requested cursor state
    void SetCursorState()
    {
        Cursor.lockState = wantedMode;
        // Hide cursor when locking
        Cursor.visible = (CursorLockMode.Locked != wantedMode);
    }
    void Start()
    {
        wantedMode = CursorLockMode.Locked;
    }
    void OnGUI()
    {
        GUILayout.BeginVertical();
        // Release cursor on escape keypress
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = wantedMode = CursorLockMode.None;

        if(wantedMode == CursorLockMode.None)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Cursor.lockState = wantedMode = CursorLockMode.Locked;
            }
        }

        GUILayout.EndVertical();

        SetCursorState();
    }
}
