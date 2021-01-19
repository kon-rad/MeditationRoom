using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public bool isRunning = false;
    
    public void toggleButton()
    {
        isRunning = !isRunning;
    }
}
