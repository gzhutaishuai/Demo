using UnityEngine;
using XLua;
using System.IO;

public class xLuaMgr:MonoSingleton<xLuaMgr> 
{ 
    
    private LuaEnv luaEnv;

    /// <summary>
    /// 初始化解析器 
    /// </summary>
    public void Init()
    {
        if (luaEnv != null)
            return;
        luaEnv = new LuaEnv();
        luaEnv.AddLoader(MyCustomLoader);
        luaEnv.AddLoader(MyCustomABLoader);//执行加载AB包中的lua文件
    }
    /// <summary>
    /// 自动执行
    /// </summary>
    /// <param name="filePath">lua脚本的文件名</param>
    /// <returns></returns>
    private byte[] MyCustomLoader(ref string filePath)
    {
        //拼接一个Lua文件所在的路径
        string path = Application.dataPath + "/Lua/" + filePath + ".lua";
        if (File.Exists(path))
        {
            return File.ReadAllBytes(path);
        }
        else
        {
            Debug.Log("MyCustomLoader重新定向失败,文件名是:" + path);
        }
        return null;
    }
    private byte[] MyCustomABLoader(ref string filePath)
    {
        //从AB包中加载lua文件
        Debug.Log("在AB包中加载lua脚本");
        ////加载AB包
        //string path = Application.streamingAssetsPath + "/lua";
        //AssetBundle ab=AssetBundle.LoadFromFile(path);
        ////加载lua文件 然后返回 
        //TextAsset tx=ab.LoadAsset<TextAsset>(filePath+".lua");

        TextAsset lua = ABManager.Instance.LoadRes<TextAsset>("lua", filePath + ".lua");

        if (lua != null)
            return lua.bytes;
        else
        {
            Debug.LogError("重定向失败");
            return null; 
        }
    }

    public void DoLuaFile(string fileName)
    {
        string path = string.Format("require('{0}')", fileName);
        DoString(path);
    }
    /// <summary>
    /// 执行lua语言
    /// </summary>
    /// <param name="str"></param>
    private void DoString(string str)
    {
        if(luaEnv==null)
        {
            Debug.LogError("解析器未初始化");
        }
        luaEnv.DoString(str);
    }
    /// <summary>
    /// 清理lua垃圾
    /// </summary>
    public void Tick()
    {
        luaEnv.Tick();
    }
    /// <summary>
    /// 销毁解析器
    /// </summary>
    public void Dispose()
    {
        if (luaEnv == null)
        {
            Debug.LogError("解析器未初始化");
        }
        luaEnv.Dispose();
        luaEnv = null;
    }
    /// <summary>
    /// 得到Lua中的_G 
    /// </summary>
    public LuaTable Global
    {
        get
        {
            return luaEnv.Global;
        }
    }
}
