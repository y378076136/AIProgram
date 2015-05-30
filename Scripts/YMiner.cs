using UnityEngine;
using System.Collections;

public class YMiner : YAIEntity
{
    #region Miner
    private StateMachine<YMiner> m_StateMachine;

    protected Transform m_Transform;

    protected int m_GoldCarried;

    protected int m_Money;

    protected int m_Thirst;

    protected int m_Fatigue;

    protected override void Awake()
    {
        base.Awake();
        m_GoldCarried = 0;
        m_Money = 0;
        m_Thirst = 0;
        m_Fatigue = 0;
        m_StateMachine = new StateMachine<YMiner>(this);
        m_Transform = transform;
    }

    protected override void Update()
    {
        m_StateMachine.Update();
    }

    public override bool HandleMessage(Telegram telegram)
    {
        return m_StateMachine.HandleMessage(telegram);
    }
    #endregion
    #region MinerState.EnterMineAndDigForNugget
    public class Miner_EnterMineAndDigForNugget : IYState<YMiner>
    {
        public int StateID { get; set; }

        private Miner_EnterMineAndDigForNugget() 
        {
            StateID = StateIDGenerator.GenerateID();  
        }

        public static void Destroy()
        {
            m_Instance = null;
        }

        private static Miner_EnterMineAndDigForNugget m_Instance = null;
        public static Miner_EnterMineAndDigForNugget Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Miner_EnterMineAndDigForNugget();
                }
                return m_Instance;
            }
        }

        public void Enter(YMiner miner)
        {

        }

        public void Execute(YMiner miner)
        {

        }

        public void Exit(YMiner miner)
        {

        }

        public bool OnMessage(YMiner entity, Telegram telegram)
        {
            return true;
        }
    }
    #endregion
    #region MinerState.VisitBankAndDepositGold
    public class Miner_VisitBackAndDepositGold : IYState<YMiner>
    {
        public int StateID { get; set; }

        private static Miner_VisitBackAndDepositGold m_Instance = null;
        public static Miner_VisitBackAndDepositGold Instance
        {
            get { if (m_Instance == null) m_Instance = new Miner_VisitBackAndDepositGold(); return m_Instance; }
        }
        public static void Destroy()
        {
            m_Instance = null;
        }
        private Miner_VisitBackAndDepositGold() { StateID = StateIDGenerator.GenerateID(); }
        public void Enter(YMiner miner)
        {

        }

        public void Execute(YMiner miner)
        {

        }

        public void Exit(YMiner miner)
        {

        }

        public bool OnMessage(YMiner entity, Telegram telegram)
        {
            return true;
        }
    }
    #endregion
    #region MinerState.GoHomeAndSleepTilRested
    public class Miner_GoHomeAndSleepTilRested : IYState<YMiner>
    {
        public int StateID { get; set; }
        private static Miner_GoHomeAndSleepTilRested m_Instance = null;
        public static Miner_GoHomeAndSleepTilRested Instance { get { if (m_Instance == null) m_Instance = new Miner_GoHomeAndSleepTilRested(); return m_Instance; } }
        public void Destroy() { m_Instance = null; }
        private Miner_GoHomeAndSleepTilRested() { StateID = StateIDGenerator.GenerateID(); }
        public void Enter(YMiner miner)
        {

        }

        public void Execute(YMiner miner)
        {

        }

        public void Exit(YMiner miner)
        {

        }

        public bool OnMessage(YMiner entity, Telegram telegram)
        {
            return true;
        }
    }
    #endregion
    #region MinerState.QuenchThirst
    public class Miner_QuenchThirst : IYState<YMiner>
    {
        public int StateID { get; set; }
        private static Miner_QuenchThirst m_Instance = null;
        public static Miner_QuenchThirst Instance { get { if (m_Instance == null) m_Instance = new Miner_QuenchThirst(); return m_Instance; } }
        public static void Destroy() { m_Instance = null; }
        private Miner_QuenchThirst() { StateID = StateIDGenerator.GenerateID(); }
        public void Enter(YMiner miner)
        {

        }

        public void Execute(YMiner miner)
        {

        }

        public void Exit(YMiner miner)
        {

        }

        public bool OnMessage(YMiner entity, Telegram telegram)
        {
            return true;
        }
    }
    #endregion
}


