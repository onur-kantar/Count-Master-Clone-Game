using UnityEngine;

public class HumanCreatorController : MonoBehaviour
{
    bool isTaken;
    public void Take()
    {
        isTaken = true;
        Destroy(gameObject);
    }
    public bool GetIsTaken()
    {
        return isTaken;
    }
}
