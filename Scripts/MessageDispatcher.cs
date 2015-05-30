using System.Collections.Generic;
using UnityEngine;

class MessageDispatcher : MonoBehaviour
{
    private static MessageDispatcher m_Instance = null;
    public static MessageDispatcher Instance { get { return m_Instance; } }

    private IList<Telegram> m_messageList;

    private void Discharge(YEntity entity, Telegram telegram)
    {

    }

    public void DispatchMessage(float delay, int sender, int receiver, TeleMessage msgType, object extraInfo)
    {
        YEntity enReceiver = EntityManager.Instance.GetEntityFromID(receiver);
        Telegram tele = new Telegram(sender, receiver, msgType, extraInfo);
        if(delay <= 0)
        {
            Discharge(enReceiver, tele);
        }
        else
        {
            tele.DispatchTime = Time.realtimeSinceStartup + delay;
            m_messageList.Add(tele);
        }
    }

    public void DispatchDelayedMessage()
    {
        if (m_messageList.Count == 0)
            return;

        float time = Time.realtimeSinceStartup;
        for(int i = 0,count = m_messageList.Count; i < count;)
        {
            if(m_messageList[i].DispatchTime < time && m_messageList[i].DispatchTime > 0)
            {
                Telegram telegram = m_messageList[i];
                YEntity enReceiver = EntityManager.Instance.GetEntityFromID(telegram.Receiver);
                Discharge(enReceiver, telegram);
                m_messageList.RemoveAt(i);
                count--;
            }
            else
            {
                i++;
            }
        }
    }

    void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
            m_messageList = new List<Telegram>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        DispatchDelayedMessage();
    }

}
