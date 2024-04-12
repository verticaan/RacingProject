using UnityEngine;
using System.Collections;

public class BoulderDestroy : MonoBehaviour
{
    public float dissolveDuration = 2;
    public float dissolveStrength;

    public void StartDissolver()
    {
        StartCoroutine(Dissolver());
    }

    IEnumerator Dissolver()
    {
        float elapsedTime = 0;

        Material dissolveMaterial = GetComponent<Renderer>().material;

        while (elapsedTime < dissolveDuration)
        {
            elapsedTime += Time.deltaTime;

            dissolveStrength = Mathf.Lerp(0, 1, elapsedTime / dissolveDuration);
            dissolveMaterial.SetFloat("_DissolveStrength", dissolveStrength);

            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boulder"))
        {
            StartDissolver();
        }
    }
}
