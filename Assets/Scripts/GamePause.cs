using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public void SetPause(bool isEnable)
    {
        Time.timeScale = isEnable ? 1 : 0;
    }

    //public bool IsPause { get; private set; }

    //public static GamePause instance;

    //private void Awake()
    //{
    //    if (instance == null) 
    //        Destroy(this);
    //    else
    //        instance = this;
    //}

    //private void OnDestroy()
    //{
    //    if(instance == this)
    //        instance = null; 
    //}

    //public void SetPause(bool isEnable)
    //{
    //    IsPause = isEnable;
    //}
}
