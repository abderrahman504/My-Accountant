using Godot;
using System;

public class ErrorLabel : Label
{
    int timeToDie;

	public ErrorLabel(String msg, int timeToDie = 7)
	{
		Text = msg;
		this.timeToDie = timeToDie;
		SelfModulate = new Color("f24f4f");
	}
	public ErrorLabel()
	{
		Text = "";
		timeToDie = 7;
	}
    public override void _Ready()
    {
        SceneTreeTimer timer = GetTree().CreateTimer(timeToDie);
		timer.Connect("timeout", this, "queue_free");
    }
}
