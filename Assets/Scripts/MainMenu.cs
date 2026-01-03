using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;

    [Header("Dificultades (assets)")]
    [SerializeField] private DifficultySettings easy;
    [SerializeField] private DifficultySettings medium;
    [SerializeField] private DifficultySettings hard;

    [Header("Referencias en escena")]
    [SerializeField] private AlarmFactory alarmFactory;
    [SerializeField] private GuardRobot[] guards; 

    private void Start()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        Time.timeScale = 0f;
    }


    public void StartEasy() 
    {  StartWith(easy); }
    public void StartMedium() 
    { StartWith(medium); }
    public void StartHard()
    { StartWith(hard); }





    private void StartWith(DifficultySettings s)
    {

        Debug.Log($"Dificultad aplicada: {s.name} | enum={s.difficulty} | alarms={s.alarmsCount} | guardSpeed={s.guardMoveSpeed} | id={s.GetInstanceID()}");


        if (s == null)
        {
            Debug.LogWarning("MainMenu: dificultad no asignada.");
            return;
        }


        if (guards == null || guards.Length == 0)
            guards = Object.FindObjectsByType<GuardRobot>(FindObjectsSortMode.None);

        foreach (var g in guards)
        {
            if (g == null) continue;
            g.moveSpeed = s.guardMoveSpeed;
            g.rotationSpeed = s.guardRotationSpeed;
            g.checkDistance = s.checkDistance;
            g.avoidAngle = s.avoidAngle;
        }

        if (alarmFactory == null)
            alarmFactory = FindFirstObjectByType<AlarmFactory>();

        if (alarmFactory != null)
        {
            alarmFactory.SetAlarmsCount(s.alarmsCount);
            alarmFactory.CreateAlarms();
        }
        else
        {
            Debug.LogWarning("MainMenu: No se encontró AlarmFactory en escena.");
        }


        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        Time.timeScale = 1f;

        
    }


   
    public void ShowMainMenu()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}
