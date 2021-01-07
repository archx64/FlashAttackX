using UnityEngine;

public class GameManager
{
    private GameObject gameObject;
    private static GameManager m_Instance;

    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new GameManager
                {
                    gameObject = new GameObject("GameManager")
                };
                m_Instance.gameObject.AddComponent<InputController>();
                m_Instance.gameObject.AddComponent<Weapon>();
                m_Instance.gameObject.AddComponent<ThirdPersonCamera>();
                m_Instance.gameObject.AddComponent<Timer>();
            }
            return m_Instance;
        }
    }

    private InputController m_inputController;
    public InputController InputController
    {
        get
        {
            if (m_inputController == null)
            {
                m_inputController = gameObject.GetComponent<InputController>();
            }
            return m_inputController;
        }
    }

    private Weapon m_Weapon;
    public Weapon Weapon
    {
        get
        {
            if(m_Weapon == null)
            {
                m_Weapon = gameObject.GetComponent<Weapon>();
            }
            return m_Weapon;
        }
    }

    private ThirdPersonCamera m_ThirdPersonCamera;
    public ThirdPersonCamera ThirdPersonCamera
    {
        get
        {
            if(m_ThirdPersonCamera == null)
            {
                m_ThirdPersonCamera = gameObject.GetComponent<ThirdPersonCamera>();
            }
            return m_ThirdPersonCamera;
        }
    }

    private Timer m_Timer;
    public Timer Timer
    {
        get
        {
            if(m_Timer == null)
            {
                m_Timer = gameObject.GetComponent<Timer>();
            }
            return m_Timer;
        }
    }

}
