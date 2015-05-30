using UnityEngine;
using System.Collections;

public abstract class YAIEntity : MonoBehaviour,YEntity
{
    public int ID { set; get; }

    protected abstract void Update();

    public abstract bool HandleMessage(Telegram telegram);

    protected virtual void Awake()
    {
        ID = transform.GetInstanceID();
        EntityManager.Instance.RegisterEntity(this);
    }

    protected virtual void OnDestroy()
    {
        EntityManager.Instance.RemoveEntity(ID);
    }
}
