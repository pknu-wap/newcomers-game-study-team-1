using UnityEngine;

public class TimeController
{
    public static void StopTime() {
        Time.timeScale = 0;
    }

    public static void RestartTime() {
        Time.timeScale = 1;
    }
}
