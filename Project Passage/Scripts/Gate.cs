using Godot;
using System;

public class Gate : Area2D
{
    [Export]
    string nextScenePath;
    AnimatedSprite animator;
    CollisionShape2D collision;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        animator = GetNode("AnimatedSprite") as AnimatedSprite;
        collision = GetNode("StaticBody2D/CollisionShape2D") as CollisionShape2D;
    }

    void OpenGate(string label){
        collision.SetDeferred("disabled", true);
        animator.Play();
    }

    void NextScene(PhysicsBody2D body2D){
        if(body2D is Player){
            GetTree().ChangeScene(nextScenePath);
        }
    }
}
