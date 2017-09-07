public interface IState
{
    void OnEnter();
    IState OnEvent(MEvent e);
}