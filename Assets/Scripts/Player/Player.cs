using UnityEngine;

public partial class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private void Awake()
    {
        StackAwake();
    }

    private void Start()
    {
        MovementStart();
    }

    private void OnEnable()
    {
        Subcribe();
    }

    private void OnDisable()
    {
    }

    private void OnDestroy()
    {
        Unsubscribe();   
    }

    private void Lose()
    {
        SetZeroMove();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovementFixedUpdate();
    }

    private void LateUpdate()
    {
        
    }
}
