using UnityEngine;

public static class CustomInput
{
    public static bool Jump { get { return Input.GetButtonDown("Jump"); } }

    public static bool Down { get { return Input.GetAxisRaw("Vertical") < 0; } }

    public static bool Right { get { return Input.GetAxisRaw("Horizontal") > 0; } }

    public static bool Left { get { return Input.GetAxisRaw("Horizontal") < 0; } }

    public static bool Repair { get { return Input.GetButtonDown("Fire1"); } }

    public static bool AnyButton { get { return Jump || Down || Right || Left || Repair; } }
}
