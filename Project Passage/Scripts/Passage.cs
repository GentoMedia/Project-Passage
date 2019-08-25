using Godot;
using System;

public class Passage : Area2D
{
    [Export]
    string passageText;
    [Signal]
    public delegate void Hit(string label);

    // Called when the node enters the scene tree for the first time.
    public override void _Ready(){
        Connect("body_entered", this, "OnBodyEntered");
    } 

    public void OnBodyEntered(PhysicsBody2D body){
        if (body is Player){
            Hide();
            EmitSignal("Hit", passageText);
        }
    }

}
