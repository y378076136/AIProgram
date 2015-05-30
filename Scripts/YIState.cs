using UnityEngine;
using System.Collections;

public interface IYState<T> where T : YAIEntity
{
    int StateID { get; set; }
    void Enter(T entity);
    void Execute(T entity);
    void Exit(T entity);
    bool OnMessage(T entity, Telegram telegram);
}

public class StateIDGenerator
{
    private static int m_sID = -1000000;
    public static int GenerateID()
    {
        return m_sID++;
    }
}

public class StateMachine<T> where T : YAIEntity
{
    private T m_Owner;
    private IYState<T> m_CurrentState;
    private IYState<T> m_PreviousState;
    private IYState<T> m_GlobalState;

    public StateMachine(T Owner)
    {
        m_Owner = Owner;
        m_CurrentState = null;
        m_PreviousState = null;
        m_GlobalState = null;
    }

    public IYState<T> CurrentState 
    {
        set { m_CurrentState = value; }
        get { return m_CurrentState; }
    }
    public IYState<T> PreviousState 
    { 
        set { m_PreviousState = value; }
        get { return m_PreviousState; }
    }
    public IYState<T> GlobalState 
    { 
        set { m_GlobalState = value; }
        get { return m_GlobalState; }
    }


    public void Update()
    {
        if (m_CurrentState != null) m_CurrentState.Execute(m_Owner);
        if (m_GlobalState != null) m_GlobalState.Execute(m_Owner);
    }

    public void ChangeState(IYState<T> newState)
    {
        if (newState == null)
            return;

        m_PreviousState = m_CurrentState;
        m_CurrentState.Exit(m_Owner);
        m_CurrentState = newState;
        m_CurrentState.Enter(m_Owner);
    }

    public void RevertToPreviousState()
    {
        ChangeState(m_PreviousState);
    }

    public bool InState(IYState<T> state)
    {
        if (m_CurrentState.StateID == state.StateID)
            return true;
        else
            return false;
    }

    public bool HandleMessage(Telegram telegram)
    {
        if(m_CurrentState != null && m_CurrentState.OnMessage(m_Owner,telegram))
        {
            return true;
        }
        if (m_GlobalState != null && m_GlobalState.OnMessage(m_Owner, telegram))
        {
            return true;
        }
        return false;
    }
}
