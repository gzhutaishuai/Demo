using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

        
public class UIManager : MonoBehaviour
{
   void Start()
   {
        xLuaMgr.Instance.Init();
        xLuaMgr.Instance.DoLuaFile("Main");
        
   }
}
