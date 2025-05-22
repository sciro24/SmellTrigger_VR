using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DiffuserController : MonoBehaviour
{
    [Header("Configurazione Diffusore")]
    [Tooltip("Indirizzo base del diffusore")]
    public string deviceAddress = "http://inov3-D8BC3888F686.local";

    [Tooltip("Slot del diffusore (default: 1)")]
    public int slot = 1;

    [Tooltip("Intensità della diffusione (0-100)")]
    [Range(0, 100)]
    public int intensity = 100;

    [Tooltip("Durata in secondi della diffusione")]
    public int duration = 30;

    /// <summary>
    /// Avvia la diffusione del profumo inviando una richiesta HTTP GET.
    /// </summary>
    public void StartDiffusion()
    {
        Debug.Log("StartDiffusion() chiamato.");
        string url = $"{deviceAddress}/start_diffusion?slot={slot}&intensity={intensity}&duration={duration}";
        StartCoroutine(SendRequest(url));
    }

    /// <summary>
    /// Interrompe manualmente la diffusione (opzionale, se serve)
    /// </summary>
    public void StopDiffusion()
    {
        string url = $"{deviceAddress}/stop_diffusion?slot={slot}";
        StartCoroutine(SendRequest(url));
    }

    /// <summary>
    /// Esegue una richiesta HTTP GET all’URL specificato.
    /// </summary>
    private IEnumerator SendRequest(string url)
    {
        Debug.Log($"Invio richiesta a: {url}");

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Errore HTTP: {www.error}");
            }
            else
            {
                Debug.Log("Richiesta HTTP inviata con successo.");
            }
        }
    }
}
