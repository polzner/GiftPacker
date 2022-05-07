using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Rect leftPart = new Rect(0, 0, Screen.width / 2, Screen.height);
    private Rect rightPart = new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height);

    public Action LeftSideClicked;
    public Action RightSideClicked;

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (leftPart.Contains(Input.mousePosition))
                LeftSideClicked?.Invoke();

            if (rightPart.Contains(Input.mousePosition))
                RightSideClicked?.Invoke();
        }
    }
}