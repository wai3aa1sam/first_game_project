// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Player/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""4c6d94ff-4d1c-49cd-b960-6067edde6d78"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""3153566c-7434-4f99-a90f-3cf2b65ccbd3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""First"",
                    ""type"": ""Button"",
                    ""id"": ""7afc8dde-0105-4ecb-bebf-0244ffb02c41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Second"",
                    ""type"": ""Button"",
                    ""id"": ""df5525a7-ceb0-471c-9df1-ffce82de904c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Third"",
                    ""type"": ""Button"",
                    ""id"": ""a861e618-0a27-4e9b-bb11-b23ef3f54b30"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Fourth"",
                    ""type"": ""Button"",
                    ""id"": ""e39c761e-4cf8-4bf4-89e5-b552bd09eacd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dc361bc2-c4f4-4770-9129-79d06094b983"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e429c0c1-9c8b-4a77-879e-1a26a5da343d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""6594e838-7b91-45d4-8c4e-998912f75ca5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4158528e-5f98-4fae-a8d7-8c418c438f03"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c5609c9d-a7ea-4421-8838-0646cdaca53e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bad2fc00-b527-49cb-8c14-9b6da314d4c6"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3f3c2ec3-cc22-4460-9d65-21131abf814e"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""First"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45f3abbe-4066-4fe6-889f-cb1085ca1a1a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""First"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b67ed7f7-024b-4e25-9b93-344302aa4bc5"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3eccb548-af0e-4d51-b946-536d367867d9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Second"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cd712746-8ccc-4414-a349-1a1ef55571a5"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Third"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a31d5eaf-9556-427f-afeb-ed84a9133a81"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Third"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9741c944-79d9-42ec-8e2c-65593a15f211"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fourth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c40bfb9d-bc84-4bb9-8b50-f007c3097824"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fourth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_First = m_Player.FindAction("First", throwIfNotFound: true);
        m_Player_Second = m_Player.FindAction("Second", throwIfNotFound: true);
        m_Player_Third = m_Player.FindAction("Third", throwIfNotFound: true);
        m_Player_Fourth = m_Player.FindAction("Fourth", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_First;
    private readonly InputAction m_Player_Second;
    private readonly InputAction m_Player_Third;
    private readonly InputAction m_Player_Fourth;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @First => m_Wrapper.m_Player_First;
        public InputAction @Second => m_Wrapper.m_Player_Second;
        public InputAction @Third => m_Wrapper.m_Player_Third;
        public InputAction @Fourth => m_Wrapper.m_Player_Fourth;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @First.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFirst;
                @First.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFirst;
                @First.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFirst;
                @Second.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecond;
                @Second.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecond;
                @Second.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecond;
                @Third.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThird;
                @Third.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThird;
                @Third.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThird;
                @Fourth.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFourth;
                @Fourth.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFourth;
                @Fourth.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFourth;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @First.started += instance.OnFirst;
                @First.performed += instance.OnFirst;
                @First.canceled += instance.OnFirst;
                @Second.started += instance.OnSecond;
                @Second.performed += instance.OnSecond;
                @Second.canceled += instance.OnSecond;
                @Third.started += instance.OnThird;
                @Third.performed += instance.OnThird;
                @Third.canceled += instance.OnThird;
                @Fourth.started += instance.OnFourth;
                @Fourth.performed += instance.OnFourth;
                @Fourth.canceled += instance.OnFourth;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnFirst(InputAction.CallbackContext context);
        void OnSecond(InputAction.CallbackContext context);
        void OnThird(InputAction.CallbackContext context);
        void OnFourth(InputAction.CallbackContext context);
    }
}
