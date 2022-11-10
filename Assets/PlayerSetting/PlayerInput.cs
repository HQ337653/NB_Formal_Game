// GENERATED AUTOMATICALLY FROM 'Assets/PlayerSetting/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Universal"",
            ""id"": ""7ab68978-6527-4ee0-b49a-ecea4e0b0c59"",
            ""actions"": [
                {
                    ""name"": ""changeChara1"",
                    ""type"": ""Button"",
                    ""id"": ""5c8e1af8-e8c7-4ea7-b44b-b3bdf74c8f24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""changeChara2"",
                    ""type"": ""Button"",
                    ""id"": ""22e28cb7-e44a-4357-b372-145f10b7b28c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""changeChara3"",
                    ""type"": ""Button"",
                    ""id"": ""ce89947b-245e-4e8e-8bef-4201f63d734a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""changeChara4"",
                    ""type"": ""Button"",
                    ""id"": ""f2ed4c78-7eab-4ece-8f52-8a0125e02faf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""pick"",
                    ""type"": ""Button"",
                    ""id"": ""dbb414f8-2002-4695-8098-530705118705"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d514c066-1919-4ebe-99ea-7b5391bb53ee"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""changeChara1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b8be0571-7d7a-4bf8-8d35-96b2ba701364"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""changeChara2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""756537ed-bda1-4b72-a3d8-29ffbb0025ef"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""changeChara3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d535ffca-2c67-49b8-a187-6587c0535761"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""changeChara4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""366a9ce9-6c6c-4d36-abd0-46b429cf0740"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""In3d"",
            ""id"": ""a67ade01-ea1d-423c-8712-dd0c3bf45cf8"",
            ""actions"": [
                {
                    ""name"": ""E"",
                    ""type"": ""Button"",
                    ""id"": ""19118cb8-46f7-460a-ae59-0e2a22c2c4b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Q"",
                    ""type"": ""Button"",
                    ""id"": ""56887b03-ae1e-4d85-93d9-198dbd4ddbe9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NormalAtk"",
                    ""type"": ""Button"",
                    ""id"": ""500dca53-223e-4e8a-b003-9c0f543d9649"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NormalAtkLongPress"",
                    ""type"": ""Button"",
                    ""id"": ""93b2daf8-3063-4505-b07b-b0b24b83022c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""NormalAtkTap"",
                    ""type"": ""Button"",
                    ""id"": ""54770515-3a85-4bdb-8d19-5b79c39698a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Tap""
                },
                {
                    ""name"": ""MoveDirection"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f2ca512d-64d3-4ef4-b30b-116dccda9d3a"",
                    ""expectedControlType"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""0343406c-c5e1-47bf-8a61-eb1ef1207338"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Moving"",
                    ""type"": ""Button"",
                    ""id"": ""2a8e6508-2d88-4f87-a6e4-a2e80f635d87"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NotInUse"",
                    ""type"": ""Button"",
                    ""id"": ""3f734737-72cf-49a0-bd22-1032bda1b09a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e4875c0e-b724-4dd5-aedd-d181a04d5817"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0df931b0-69a9-4c96-bda6-beaead6b11ca"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""E"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a05667dc-c5f0-463e-b36f-f65e8c94103c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08669a15-c9f2-4936-8ca2-c871606d0cbb"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Q"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cba6716d-6339-4e57-9bc1-15fab1ab5375"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NormalAtkLongPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8aeeed85-66d5-47b3-860e-03932faad433"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NormalAtkTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35fef1d0-58fc-4f6c-998e-619e8e716b38"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""06fcdeb2-8f2d-4f56-9d7f-ee0655cf5bcb"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55f301b6-f7da-430b-94e9-dca2d598d498"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b745e45-aa8c-4901-809d-ae91c41b3b87"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12533904-5006-46d5-8dd6-097ecd31d394"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Moving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbfdf4d2-df75-4465-8c55-00ce8c6fc6c8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NormalAtk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3d0f6ed-3ff4-4ebc-967e-0d11248b102f"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""84754cc8-4bb4-44ec-a265-0aa25f4ad0c1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30d6285b-1ea7-4d17-a18a-83632a6d9b0b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": ""VectorFromCenter"",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b2dc49e-8238-45f5-8c7a-4861fa514ed5"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""In2d"",
            ""id"": ""2acfdf73-63b4-41c8-b8fe-41bf950ac294"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""26c6482c-2001-499e-9251-5226de361b0c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftRight"",
                    ""type"": ""Value"",
                    ""id"": ""ee1d433b-8e2d-48a6-9299-eb02c5cf00e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""87852355-8933-4aff-849c-29d235c5c854"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1c355f62-79eb-4c41-9245-727ae25483b3"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""gamePad"",
                    ""id"": ""58d5e2d1-aa64-4237-bab0-97bc914355d2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9a820a81-b97d-4c3f-ae96-8632cbfc24c6"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""a5455461-3f37-4892-9c2a-994aaa92d4db"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ec9ae517-72b7-4210-bf06-fc11234eb57b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""17e2717b-4f0f-4fd6-a773-3a690f9a81d2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9a61ed12-9286-42db-8518-0c9ca7ea3799"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6e2a70cb-099c-4d81-b56d-956d7ea4001a"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b51c5e8b-2393-4e53-aed9-87ccc594e6f5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Dialogue"",
            ""id"": ""3aacfdd0-7501-43cb-bb61-a11126a5b175"",
            ""actions"": [
                {
                    ""name"": ""playNext"",
                    ""type"": ""Button"",
                    ""id"": ""d38985cf-da70-4b77-87bc-5abbe4375e01"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b7400458-5f49-4638-9e1b-4c91f65792b2"",
                    ""path"": ""<Keyboard>/#(')"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""playNext"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Universal
        m_Universal = asset.FindActionMap("Universal", throwIfNotFound: true);
        m_Universal_changeChara1 = m_Universal.FindAction("changeChara1", throwIfNotFound: true);
        m_Universal_changeChara2 = m_Universal.FindAction("changeChara2", throwIfNotFound: true);
        m_Universal_changeChara3 = m_Universal.FindAction("changeChara3", throwIfNotFound: true);
        m_Universal_changeChara4 = m_Universal.FindAction("changeChara4", throwIfNotFound: true);
        m_Universal_pick = m_Universal.FindAction("pick", throwIfNotFound: true);
        // In3d
        m_In3d = asset.FindActionMap("In3d", throwIfNotFound: true);
        m_In3d_E = m_In3d.FindAction("E", throwIfNotFound: true);
        m_In3d_Q = m_In3d.FindAction("Q", throwIfNotFound: true);
        m_In3d_NormalAtk = m_In3d.FindAction("NormalAtk", throwIfNotFound: true);
        m_In3d_NormalAtkLongPress = m_In3d.FindAction("NormalAtkLongPress", throwIfNotFound: true);
        m_In3d_NormalAtkTap = m_In3d.FindAction("NormalAtkTap", throwIfNotFound: true);
        m_In3d_MoveDirection = m_In3d.FindAction("MoveDirection", throwIfNotFound: true);
        m_In3d_Dash = m_In3d.FindAction("Dash", throwIfNotFound: true);
        m_In3d_Moving = m_In3d.FindAction("Moving", throwIfNotFound: true);
        m_In3d_NotInUse = m_In3d.FindAction("NotInUse", throwIfNotFound: true);
        // In2d
        m_In2d = asset.FindActionMap("In2d", throwIfNotFound: true);
        m_In2d_Newaction = m_In2d.FindAction("New action", throwIfNotFound: true);
        m_In2d_LeftRight = m_In2d.FindAction("LeftRight", throwIfNotFound: true);
        m_In2d_Jump = m_In2d.FindAction("Jump", throwIfNotFound: true);
        // Dialogue
        m_Dialogue = asset.FindActionMap("Dialogue", throwIfNotFound: true);
        m_Dialogue_playNext = m_Dialogue.FindAction("playNext", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Universal
    private readonly InputActionMap m_Universal;
    private IUniversalActions m_UniversalActionsCallbackInterface;
    private readonly InputAction m_Universal_changeChara1;
    private readonly InputAction m_Universal_changeChara2;
    private readonly InputAction m_Universal_changeChara3;
    private readonly InputAction m_Universal_changeChara4;
    private readonly InputAction m_Universal_pick;
    public struct UniversalActions
    {
        private @PlayerInput m_Wrapper;
        public UniversalActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @changeChara1 => m_Wrapper.m_Universal_changeChara1;
        public InputAction @changeChara2 => m_Wrapper.m_Universal_changeChara2;
        public InputAction @changeChara3 => m_Wrapper.m_Universal_changeChara3;
        public InputAction @changeChara4 => m_Wrapper.m_Universal_changeChara4;
        public InputAction @pick => m_Wrapper.m_Universal_pick;
        public InputActionMap Get() { return m_Wrapper.m_Universal; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UniversalActions set) { return set.Get(); }
        public void SetCallbacks(IUniversalActions instance)
        {
            if (m_Wrapper.m_UniversalActionsCallbackInterface != null)
            {
                @changeChara1.started -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara1;
                @changeChara1.performed -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara1;
                @changeChara1.canceled -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara1;
                @changeChara2.started -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara2;
                @changeChara2.performed -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara2;
                @changeChara2.canceled -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara2;
                @changeChara3.started -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara3;
                @changeChara3.performed -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara3;
                @changeChara3.canceled -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara3;
                @changeChara4.started -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara4;
                @changeChara4.performed -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara4;
                @changeChara4.canceled -= m_Wrapper.m_UniversalActionsCallbackInterface.OnChangeChara4;
                @pick.started -= m_Wrapper.m_UniversalActionsCallbackInterface.OnPick;
                @pick.performed -= m_Wrapper.m_UniversalActionsCallbackInterface.OnPick;
                @pick.canceled -= m_Wrapper.m_UniversalActionsCallbackInterface.OnPick;
            }
            m_Wrapper.m_UniversalActionsCallbackInterface = instance;
            if (instance != null)
            {
                @changeChara1.started += instance.OnChangeChara1;
                @changeChara1.performed += instance.OnChangeChara1;
                @changeChara1.canceled += instance.OnChangeChara1;
                @changeChara2.started += instance.OnChangeChara2;
                @changeChara2.performed += instance.OnChangeChara2;
                @changeChara2.canceled += instance.OnChangeChara2;
                @changeChara3.started += instance.OnChangeChara3;
                @changeChara3.performed += instance.OnChangeChara3;
                @changeChara3.canceled += instance.OnChangeChara3;
                @changeChara4.started += instance.OnChangeChara4;
                @changeChara4.performed += instance.OnChangeChara4;
                @changeChara4.canceled += instance.OnChangeChara4;
                @pick.started += instance.OnPick;
                @pick.performed += instance.OnPick;
                @pick.canceled += instance.OnPick;
            }
        }
    }
    public UniversalActions @Universal => new UniversalActions(this);

    // In3d
    private readonly InputActionMap m_In3d;
    private IIn3dActions m_In3dActionsCallbackInterface;
    private readonly InputAction m_In3d_E;
    private readonly InputAction m_In3d_Q;
    private readonly InputAction m_In3d_NormalAtk;
    private readonly InputAction m_In3d_NormalAtkLongPress;
    private readonly InputAction m_In3d_NormalAtkTap;
    private readonly InputAction m_In3d_MoveDirection;
    private readonly InputAction m_In3d_Dash;
    private readonly InputAction m_In3d_Moving;
    private readonly InputAction m_In3d_NotInUse;
    public struct In3dActions
    {
        private @PlayerInput m_Wrapper;
        public In3dActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @E => m_Wrapper.m_In3d_E;
        public InputAction @Q => m_Wrapper.m_In3d_Q;
        public InputAction @NormalAtk => m_Wrapper.m_In3d_NormalAtk;
        public InputAction @NormalAtkLongPress => m_Wrapper.m_In3d_NormalAtkLongPress;
        public InputAction @NormalAtkTap => m_Wrapper.m_In3d_NormalAtkTap;
        public InputAction @MoveDirection => m_Wrapper.m_In3d_MoveDirection;
        public InputAction @Dash => m_Wrapper.m_In3d_Dash;
        public InputAction @Moving => m_Wrapper.m_In3d_Moving;
        public InputAction @NotInUse => m_Wrapper.m_In3d_NotInUse;
        public InputActionMap Get() { return m_Wrapper.m_In3d; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(In3dActions set) { return set.Get(); }
        public void SetCallbacks(IIn3dActions instance)
        {
            if (m_Wrapper.m_In3dActionsCallbackInterface != null)
            {
                @E.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnE;
                @E.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnE;
                @E.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnE;
                @Q.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnQ;
                @Q.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnQ;
                @Q.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnQ;
                @NormalAtk.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtk;
                @NormalAtk.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtk;
                @NormalAtk.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtk;
                @NormalAtkLongPress.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtkLongPress;
                @NormalAtkLongPress.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtkLongPress;
                @NormalAtkLongPress.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtkLongPress;
                @NormalAtkTap.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtkTap;
                @NormalAtkTap.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtkTap;
                @NormalAtkTap.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnNormalAtkTap;
                @MoveDirection.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnMoveDirection;
                @MoveDirection.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnMoveDirection;
                @MoveDirection.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnMoveDirection;
                @Dash.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnDash;
                @Moving.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnMoving;
                @Moving.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnMoving;
                @Moving.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnMoving;
                @NotInUse.started -= m_Wrapper.m_In3dActionsCallbackInterface.OnNotInUse;
                @NotInUse.performed -= m_Wrapper.m_In3dActionsCallbackInterface.OnNotInUse;
                @NotInUse.canceled -= m_Wrapper.m_In3dActionsCallbackInterface.OnNotInUse;
            }
            m_Wrapper.m_In3dActionsCallbackInterface = instance;
            if (instance != null)
            {
                @E.started += instance.OnE;
                @E.performed += instance.OnE;
                @E.canceled += instance.OnE;
                @Q.started += instance.OnQ;
                @Q.performed += instance.OnQ;
                @Q.canceled += instance.OnQ;
                @NormalAtk.started += instance.OnNormalAtk;
                @NormalAtk.performed += instance.OnNormalAtk;
                @NormalAtk.canceled += instance.OnNormalAtk;
                @NormalAtkLongPress.started += instance.OnNormalAtkLongPress;
                @NormalAtkLongPress.performed += instance.OnNormalAtkLongPress;
                @NormalAtkLongPress.canceled += instance.OnNormalAtkLongPress;
                @NormalAtkTap.started += instance.OnNormalAtkTap;
                @NormalAtkTap.performed += instance.OnNormalAtkTap;
                @NormalAtkTap.canceled += instance.OnNormalAtkTap;
                @MoveDirection.started += instance.OnMoveDirection;
                @MoveDirection.performed += instance.OnMoveDirection;
                @MoveDirection.canceled += instance.OnMoveDirection;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Moving.started += instance.OnMoving;
                @Moving.performed += instance.OnMoving;
                @Moving.canceled += instance.OnMoving;
                @NotInUse.started += instance.OnNotInUse;
                @NotInUse.performed += instance.OnNotInUse;
                @NotInUse.canceled += instance.OnNotInUse;
            }
        }
    }
    public In3dActions @In3d => new In3dActions(this);

    // In2d
    private readonly InputActionMap m_In2d;
    private IIn2dActions m_In2dActionsCallbackInterface;
    private readonly InputAction m_In2d_Newaction;
    private readonly InputAction m_In2d_LeftRight;
    private readonly InputAction m_In2d_Jump;
    public struct In2dActions
    {
        private @PlayerInput m_Wrapper;
        public In2dActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_In2d_Newaction;
        public InputAction @LeftRight => m_Wrapper.m_In2d_LeftRight;
        public InputAction @Jump => m_Wrapper.m_In2d_Jump;
        public InputActionMap Get() { return m_Wrapper.m_In2d; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(In2dActions set) { return set.Get(); }
        public void SetCallbacks(IIn2dActions instance)
        {
            if (m_Wrapper.m_In2dActionsCallbackInterface != null)
            {
                @Newaction.started -= m_Wrapper.m_In2dActionsCallbackInterface.OnNewaction;
                @Newaction.performed -= m_Wrapper.m_In2dActionsCallbackInterface.OnNewaction;
                @Newaction.canceled -= m_Wrapper.m_In2dActionsCallbackInterface.OnNewaction;
                @LeftRight.started -= m_Wrapper.m_In2dActionsCallbackInterface.OnLeftRight;
                @LeftRight.performed -= m_Wrapper.m_In2dActionsCallbackInterface.OnLeftRight;
                @LeftRight.canceled -= m_Wrapper.m_In2dActionsCallbackInterface.OnLeftRight;
                @Jump.started -= m_Wrapper.m_In2dActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_In2dActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_In2dActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_In2dActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Newaction.started += instance.OnNewaction;
                @Newaction.performed += instance.OnNewaction;
                @Newaction.canceled += instance.OnNewaction;
                @LeftRight.started += instance.OnLeftRight;
                @LeftRight.performed += instance.OnLeftRight;
                @LeftRight.canceled += instance.OnLeftRight;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public In2dActions @In2d => new In2dActions(this);

    // Dialogue
    private readonly InputActionMap m_Dialogue;
    private IDialogueActions m_DialogueActionsCallbackInterface;
    private readonly InputAction m_Dialogue_playNext;
    public struct DialogueActions
    {
        private @PlayerInput m_Wrapper;
        public DialogueActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @playNext => m_Wrapper.m_Dialogue_playNext;
        public InputActionMap Get() { return m_Wrapper.m_Dialogue; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DialogueActions set) { return set.Get(); }
        public void SetCallbacks(IDialogueActions instance)
        {
            if (m_Wrapper.m_DialogueActionsCallbackInterface != null)
            {
                @playNext.started -= m_Wrapper.m_DialogueActionsCallbackInterface.OnPlayNext;
                @playNext.performed -= m_Wrapper.m_DialogueActionsCallbackInterface.OnPlayNext;
                @playNext.canceled -= m_Wrapper.m_DialogueActionsCallbackInterface.OnPlayNext;
            }
            m_Wrapper.m_DialogueActionsCallbackInterface = instance;
            if (instance != null)
            {
                @playNext.started += instance.OnPlayNext;
                @playNext.performed += instance.OnPlayNext;
                @playNext.canceled += instance.OnPlayNext;
            }
        }
    }
    public DialogueActions @Dialogue => new DialogueActions(this);
    public interface IUniversalActions
    {
        void OnChangeChara1(InputAction.CallbackContext context);
        void OnChangeChara2(InputAction.CallbackContext context);
        void OnChangeChara3(InputAction.CallbackContext context);
        void OnChangeChara4(InputAction.CallbackContext context);
        void OnPick(InputAction.CallbackContext context);
    }
    public interface IIn3dActions
    {
        void OnE(InputAction.CallbackContext context);
        void OnQ(InputAction.CallbackContext context);
        void OnNormalAtk(InputAction.CallbackContext context);
        void OnNormalAtkLongPress(InputAction.CallbackContext context);
        void OnNormalAtkTap(InputAction.CallbackContext context);
        void OnMoveDirection(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnMoving(InputAction.CallbackContext context);
        void OnNotInUse(InputAction.CallbackContext context);
    }
    public interface IIn2dActions
    {
        void OnNewaction(InputAction.CallbackContext context);
        void OnLeftRight(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IDialogueActions
    {
        void OnPlayNext(InputAction.CallbackContext context);
    }
}
