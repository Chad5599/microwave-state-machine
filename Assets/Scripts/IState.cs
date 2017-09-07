using System;

public class IState
{
	public virtual void OnEnter(MicrowaveSM sm) {}
	public virtual IState OnEvent(MEvent e) { return this; }

	protected bool CameFromState(MicrowaveSM sm, Type state)
	{
		return (sm.previousState.GetType() == state);
	}
}