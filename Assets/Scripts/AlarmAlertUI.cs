using System.Collections;
using TMPro;
using UnityEngine;

public class AlarmAlertUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text messageText;

    [Header("Timing")]
    [SerializeField] private float showSeconds = 2.5f;

    private Coroutine routine;

    private void Awake()
    {
        if (panel != null) panel.SetActive(false);
    }

    private void OnEnable()
    {
        GuardRobot.FirstAlarmTriggered += ShowAlert;
    }

    private void OnDisable()
    {
        GuardRobot.FirstAlarmTriggered -= ShowAlert;
    }

    private void ShowAlert()
    {
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(ShowRoutine());
    }

    private IEnumerator ShowRoutine()
    {
        if (panel != null) panel.SetActive(true);

        if (messageText != null)
            messageText.text = "¡ALERTA! Has activado una alarma.\nEl guardia va a por ti.";


        yield return new WaitForSecondsRealtime(showSeconds);

        if (panel != null) panel.SetActive(false);
        routine = null;
    }
}
