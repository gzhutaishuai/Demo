using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ABManager : MonoSingleton<ABManager>
{
    //AB包管理器是为了让外部更加方便地进行资源的加载和卸载

    //AB包不能重复加载

    private AssetBundle mainAB=null;//主包

    private AssetBundleManifest mainABFest=null;//主包的配置文件

    //字典类，用字典来存储加载过的AB包
    private Dictionary<string,AssetBundle> abDic= new Dictionary<string,AssetBundle>(); 

    /// <summary>
    /// 资源加载路径
    /// </summary>
    private string PathUrl
    {
        get
        {
            return Application.streamingAssetsPath + "/";
        }
    }
    /// <summary>
    /// 要加载的平台
    /// </summary>
    private string DesktopName
    {
        get
        {
#if UNITY_IOS
    return "IOS";
#elif UNITY_ANDROID
    return "Android";
#else
    return "PC";
#endif
          
        }
    }

    public void LoadAB(string abName)
    {
        //加载AB包
        if (mainAB == null)
        {
            mainAB = AssetBundle.LoadFromFile(PathUrl + DesktopName);
            mainABFest = mainAB.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        }

        //获取依赖包的相关信息
        AssetBundle ab = null;

        string[] strs = mainABFest.GetAllDependencies(abName);//获取所有需要的依赖包
        for (int i = 0; i < strs.Length; i++)
        {
            //判断包是否加载过
            if (!abDic.ContainsKey(strs[i]))
            {
                ab = AssetBundle.LoadFromFile(PathUrl + strs[i]);
                abDic.Add(strs[i], ab);
            }
        }

        //加载主体资源包
        if (!abDic.ContainsKey(abName))
        {
            ab = AssetBundle.LoadFromFile(PathUrl + abName);
            abDic.Add(abName, ab);
        }
    }

    #region 同步加载
    /// <summary>
    /// 同步加载,不指定类型
    /// </summary>
    /// <param name="abName">AB包的名字</param>
    /// <param name="resName">资源的名字</param>
    public Object LoadRes(string abName,string resName)
    {
        LoadAB(abName);

        //加载资源
        Object obj= abDic[abName].LoadAsset(resName);

        return obj;
    }
    /// <summary>
    /// 同步加载，根据type指定类型
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="type">指定类型</param>
    /// <returns></returns>
    public Object LoadRes(string abName,string resName,System.Type type)
    {
        LoadAB(abName);

        //加载资源
        Object obj = abDic[abName].LoadAsset(resName,type);
        if(obj is GameObject)
        {
            return Instantiate(obj);
        }
        return obj;
    }
    /// <summary>
    /// 同步加载，泛型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <returns></returns>
    public T LoadRes<T>(string abName,string resName) where T : Object
    {
        LoadAB(abName);

        //加载资源
        T obj = abDic[abName].LoadAsset<T>(resName);

        return obj;
    }
    #endregion

    #region 异步加载
    /// <summary>
    /// 异步加载,不指定类型
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="callBack">回调函数</param>
    public void LoadResAsync(string abName,string resName,UnityAction<Object> callBack)
    {
        StartCoroutine(RealLoadAssetAsync(abName,resName,callBack));
    }
    private IEnumerator RealLoadAssetAsync(string abName,string resName,UnityAction<Object> callBack)
    {
        LoadAB(abName);

        //异步加载资源
        AssetBundleRequest abAsync = abDic[abName].LoadAssetAsync(resName);
        yield return abAsync;

        //异步加载结束后，通过委托来传递给外部调用
        callBack(abAsync.asset);
    }
    /// <summary>
    /// 根据指定类型异步加载
    /// </summary>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="type">指定类型</param>
    /// <param name="callBack"></param>
    public void LoadResAsync(string abName, string resName,System.Type type, UnityAction<Object> callBack)
    {
        StartCoroutine(RealLoadAssetAsync(abName, resName,type, callBack));
    }
    private IEnumerator RealLoadAssetAsync(string abName, string resName,System.Type type, UnityAction<Object> callBack)
    {
        LoadAB(abName);

        //异步加载资源
        AssetBundleRequest abAsync = abDic[abName].LoadAssetAsync(resName,type);
        yield return abAsync;

        //异步加载结束后，通过委托来传递给外部调用
        callBack(abAsync.asset);
    }
    /// <summary>
    /// 根据泛型异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="abName"></param>
    /// <param name="resName"></param>
    /// <param name="callBack"></param>
    public void LoadResAsync<T>(string abName, string resName, UnityAction<T> callBack) where T : Object
    {
        StartCoroutine(RealLoadAssetAsync<T>(abName, resName, callBack));
    }
    private IEnumerator RealLoadAssetAsync<T>(string abName, string resName, UnityAction<T> callBack) where T:Object
    {
        LoadAB(abName);

        //异步加载资源
        AssetBundleRequest abAsync = abDic[abName].LoadAssetAsync<T>(resName);
        yield return abAsync;

        //异步加载结束后，通过委托来传递给外部调用
        callBack(abAsync.asset as T);
    }
    #endregion
    /// <summary>
    /// 单个包的卸载
    /// </summary>
    /// <param name="abName"></param>
    public void UnLoad(string abName) 
    { 
       if(abDic.ContainsKey(abName))
        {
            abDic[abName].Unload(false);
            abDic.Remove(abName);
        }
    }
    /// <summary>
    /// 所有包的卸载
    /// </summary>
    /// <param name="abName"></param>
    public void ClearAB(string abName)
    {
        AssetBundle.UnloadAllAssetBundles(false);
        abDic.Clear();
        mainAB = null;
        mainABFest = null;
    }

}
