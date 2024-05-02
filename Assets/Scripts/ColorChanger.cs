using UnityEngine;

public class ColorChanger
{
    public void ChangeColor(Material material)
    {
        material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }
}