using UnityEngine;


class Target : MonoBehaviour
{
   public void Hit()
   {
       transform.position = TargetBounds.Instance.GetRandomPosition();
   }
}

