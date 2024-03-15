using UnityEngine.Events;


public class LifeCycle : MonoSingleton<LifeCycle>
{
    public enum E_lifeFun_Type
    {
        Start,
        Update,
        FixedUpdate,
        LateUpdate,
        OnEnable,
        OnDisable,
        OnDestory
    }

    //private UnityAction awake;
    private UnityAction start;
    private UnityAction update;
    private UnityAction fixedupdate;
    private UnityAction lateupdate;
    private UnityAction onenable;
    private UnityAction ondisable;
    private UnityAction ondestory;

    private void Start()
    {
        if (start != null)
            start();
    }
    private void Update()
    {
        if (update != null)
            update();
    }
    private void FixedUpdate()
    {
        if (fixedupdate != null)
            fixedupdate();
    }
    private void LateUpdate()
    {
        if (lateupdate != null)
            lateupdate();
    }
    private void OnEnable()
    {
        if (onenable != null)
            onenable();
    }
    private void OnDisable()
    {
        if (ondisable != null)
            ondisable();
    }
    protected override void OnDestroy()
    {
        if (ondestory != null)
            ondestory();
        start = null;
        update = null;
        fixedupdate = null;
        onenable = null;
        ondisable = null;
        ondestory = null;
    }

    public void AddOrRemoveListener(UnityAction fun, E_lifeFun_Type type, bool isAdd = true)
    {
        switch (type)
        {
            case E_lifeFun_Type.Start:
                if (isAdd)
                {
                    start += fun;
                }
                else
                    start -= fun;
                break;
            case E_lifeFun_Type.Update:
                if (isAdd)
                {
                    update += fun;
                }
                else
                    update -= fun;
                break;
            case E_lifeFun_Type.FixedUpdate:
                if (isAdd)
                {
                    fixedupdate += fun;
                }
                else
                    fixedupdate -= fun;
                break;
            case E_lifeFun_Type.LateUpdate:
                if (isAdd)
                {
                    lateupdate += fun;
                }
                else
                    lateupdate -= fun;
                break;
            case E_lifeFun_Type.OnEnable:
                if (isAdd)
                {
                    onenable += fun;
                }
                else
                    onenable -= fun;
                break;
            case E_lifeFun_Type.OnDisable:
                if (isAdd)
                {
                    ondisable += fun;
                }
                else
                    ondisable -= fun;
                break;
            case E_lifeFun_Type.OnDestory:
                if (isAdd)
                {
                    ondestory += fun;
                }
                else
                    ondestory -= fun;
                break;
        }
    }

}
