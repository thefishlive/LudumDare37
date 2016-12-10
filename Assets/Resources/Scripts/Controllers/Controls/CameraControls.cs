using System.Collections;
using System.Collections.Generic;
using InControl;
using UnityEngine;

public class CameraControls : PlayerActionSet
{
    public PlayerAction MoveLeft;
    public PlayerAction MoveRight;
    public PlayerAction MoveForward;
    public PlayerAction MoveBackwards;
    public PlayerAction MoveUp;
    public PlayerAction MoveDown;
    public PlayerTwoAxisAction MoveXZ;
    public PlayerOneAxisAction MoveY;

    public PlayerAction LookLeft;
    public PlayerAction LookRight;
    public PlayerAction LookUp;
    public PlayerAction LookDown;
    public PlayerTwoAxisAction Look;

    public PlayerAction ZoomIn;
    public PlayerAction ZoomOut;
    public PlayerOneAxisAction Zoom;
    
    public CameraControls()
    {
        MoveLeft = CreatePlayerAction("input.move.left");
        MoveRight = CreatePlayerAction("input.move.right");
        MoveForward = CreatePlayerAction("input.move.forward");
        MoveBackwards = CreatePlayerAction("input.move.backwards");
        MoveUp = CreatePlayerAction("input.move.up");
        MoveDown = CreatePlayerAction("input.move.down");

        MoveXZ = CreateTwoAxisPlayerAction(MoveLeft, MoveRight, MoveBackwards, MoveForward);
        MoveY = CreateOneAxisPlayerAction(MoveUp, MoveDown);

        LookLeft = CreatePlayerAction("input.look.left");
        LookRight = CreatePlayerAction("input.look.right");
        LookUp = CreatePlayerAction("input.look.up");
        LookDown = CreatePlayerAction("input.look.down");

        Look = CreateTwoAxisPlayerAction(LookLeft, LookRight, LookDown, LookUp);

        ZoomIn = CreatePlayerAction("input.zoom.in");
        ZoomOut = CreatePlayerAction("input.zoom.out");

        Zoom = CreateOneAxisPlayerAction(ZoomOut, ZoomIn);

        SetupDefaultKeyboard();
    }

    public void SetupDefaultKeyboard()
    {
        MoveLeft.AddDefaultBinding(Key.A);
        MoveRight.AddDefaultBinding(Key.D);
        MoveForward.AddDefaultBinding(Key.W);
        MoveBackwards.AddDefaultBinding(Key.S);
        MoveUp.AddDefaultBinding(Key.Shift);
        MoveDown.AddDefaultBinding(Key.Space);

        LookLeft.AddDefaultBinding(Mouse.NegativeX);
        LookRight.AddDefaultBinding(Mouse.PositiveX);
        LookUp.AddDefaultBinding(Mouse.NegativeY);
        LookDown.AddDefaultBinding(Mouse.PositiveY);

        ZoomIn.AddDefaultBinding(Mouse.NegativeScrollWheel);
        ZoomOut.AddDefaultBinding(Mouse.PositiveScrollWheel);
    }
}
