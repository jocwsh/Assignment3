using UnityEngine;

public class targetspawnmod : MonoBehaviour
{

    public float spawntimemod;

    public void targetspawnfrequency()
    {
        spawntimemod -= 0.1f;
    }
}
