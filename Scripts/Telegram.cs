
public struct Telegram
{
    public int Sender;
    public int Receiver;
    public TeleMessage Msg;
    public float DispatchTime;
    public object ExtraInfo;
    
    public Telegram(int sender, int receiver, TeleMessage msg, object extraInfo)
    {
        Sender = sender;
        Receiver = receiver;
        Msg = msg;
        ExtraInfo = extraInfo;
        DispatchTime = 0;
    }
}

public enum TeleMessage
{
    Msg_HiHoneyInHome = 1,
    Msg_StewReady = 2
}
