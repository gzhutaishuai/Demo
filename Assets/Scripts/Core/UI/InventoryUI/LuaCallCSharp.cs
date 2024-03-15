using System;
using System.Collections.Generic;
using UnityEngine.Events;
using XLua;

namespace Core.UI.InventoryUI
{
    public static class LuaCallCSharp
    {
        [CSharpCallLua]
        public static List<Type> Types = new List<Type>()
        {
            typeof(UnityAction<Item>),
            typeof(Action<bool>),
        };
    }
}
