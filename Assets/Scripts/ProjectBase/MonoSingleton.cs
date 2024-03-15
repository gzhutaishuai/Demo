using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T:MonoSingleton<T>
{
    protected MonoSingleton() { }

    private static T instance;

    private static bool isExisted;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance=FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject go = new GameObject(typeof(T).Name);
                    instance = go.AddComponent<T>();
                    isExisted = true;
                }
            }
            return instance;
        }
        
    }

    protected virtual void OnDestroy()
    {
        isExisted=false;
    }
}
