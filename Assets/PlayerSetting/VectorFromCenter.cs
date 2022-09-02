using UnityEditor;
namespace UnityEngine.InputSystem.Processors
{
#if UNITY_EDITOR
    [InitializeOnLoad]
#endif
    public class VectorFromCenter : InputProcessor<Vector2>
    {
#if UNITY_EDITOR
        static VectorFromCenter()
        {
            Initialize();
        }
#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void Initialize()
        {
            InputSystem.RegisterProcessor<VectorFromCenter>();
        }

        public override Vector2 Process(Vector2 value, InputControl control)
        {
            return (value - new Vector2(Screen.width / 2, Screen.height / 2)).normalized;
        }
    }
}





