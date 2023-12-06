using UnityEngine;

public class FoodScript : RocketScript //INHERITANCE
{
    public override void OnTriggerEnter(Collider other) //POLYMORPHISM
    {
        if (other.CompareTag("Player"))
        {
            mainManager.UpdateLife(1);
        }

        Destroy(gameObject);
    }
}
