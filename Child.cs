using Godot;
using System;

public class Child : Node
{
    [Signal]
	delegate void child_signal();

    public override void _Ready()
    {
        
    }

	public void go()
	{
		EmitSignal("child_signal");
	}
}
