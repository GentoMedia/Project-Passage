using Godot;
using System;

public class Jam : Area2D
{
    
    void OnBodyEntered(PhysicsBody2D body2D){
        if (body2D is Player){
            QueueFree();
            Player player = body2D as Player;
            player.LifeMath(3);
        }
    }

}
