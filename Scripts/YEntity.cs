using System.Collections.Generic;
using UnityEngine;

public interface YEntity
{
    int ID { get; set; }

    bool HandleMessage(Telegram telegram);
}

public class EntityManager
{
    private static EntityManager m_Instance = null;
    public static EntityManager Instance { get { if (m_Instance == null) m_Instance = new EntityManager(); return m_Instance; } }

    private IDictionary<int, YEntity> m_EntityMap;
    private EntityManager()
    {
        m_EntityMap = new Dictionary<int, YEntity>();
    }

    public void RegisterEntity(YEntity entity)
    {
        if(!m_EntityMap.ContainsKey(entity.ID))
            m_EntityMap.Add(entity.ID, entity);
    }

    public YEntity GetEntityFromID(int ID)
    {
        if (m_EntityMap.ContainsKey(ID))
            return m_EntityMap[ID];
        return null;
    }

    public void RemoveEntity(int ID)
    {
        if (m_EntityMap.ContainsKey(ID))
            m_EntityMap.Remove(ID);
    }
}
