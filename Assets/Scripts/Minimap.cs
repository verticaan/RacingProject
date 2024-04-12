using UnityEngine;

public class Minimap : MonoBehaviour
{
    private Transform player;
    public float height = 10f;
    public float distance = 10f;

    private void Start()
    {
        player = FindObjectOfType<CarController>().transform;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position - player.forward * distance + Vector3.up * height;
            newPosition.y = transform.position.y;

            transform.position = newPosition;

            transform.rotation = Quaternion.Euler(22.5f, player.eulerAngles.y, 0f);
        }
    }
}
