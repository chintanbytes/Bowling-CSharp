namespace Bowling
{
    public interface IFrame
    {
        bool IsFrameComplete();
        void AddRoll(int pins);
        int Score();
    }
}
