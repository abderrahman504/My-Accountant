using System;
using Godot;


public class SignalTest : Node
{

	public override void _Ready()
	{
		Child child = GetNode<Child>("Child");
		child.Connect("child_signal", this, "signal_method");
		child.go();
	}

	void signal_method()
	{
		GD.Print("Signal Emitted");
	}

}

