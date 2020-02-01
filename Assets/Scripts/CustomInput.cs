using UnityEngine;

public static class CustomInput
{
    public static bool Jump { get { return Input.GetButtonDown("Jump"); } }

    public static bool Down { get { return Input.GetAxisRaw("Vertical") < 0; } }

    public static bool Right { get { return Input.GetAxisRaw("Horizontal") > 0; } }

    public static bool Left { get { return Input.GetAxisRaw("Horizontal") < 0; } }
}
