using UnityEngine;
using UnityEngine.UI;

namespace NekoLegends
{
    public class DemoSceneCombat : DemoScenes
    {

        [SerializeField] private DemoNekoCombatCharacter _nekoCharacter;
        [Space]
        [SerializeField] private Button IdleBtn;
        [SerializeField] private Button WalkBtn;
        [SerializeField] private Button RunBtn;
        [SerializeField] private Button ImpairedBtn;
        [SerializeField] private Button AlertBtn;
        [SerializeField] private Button AttackABtn;
        [SerializeField] private Button AttackBBtn;
        [SerializeField] private Button SpecialABtn;
        [SerializeField] private Button SpecialBBtn;
        [SerializeField] private Button UltimateBtn;

        #region Singleton
        public static new DemoSceneCombat Instance
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(DemoSceneCombat)) as DemoSceneCombat;

                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
        private static DemoSceneCombat _instance;
        #endregion



        protected override void Start()
        {
            base.Start();
            
        }

        protected override void OnEnable()
        {
            if(IdleBtn)
                RegisterButtonAction(IdleBtn, () => _nekoCharacter.PlayAnimation("Idle"));
            if (AlertBtn)
                RegisterButtonAction(AlertBtn, () => _nekoCharacter.PlayAnimation("Alert"));
            if (WalkBtn)
                RegisterButtonAction(WalkBtn, () => _nekoCharacter.PlayAnimation("Walk"));
            if (RunBtn)
                RegisterButtonAction(RunBtn, () => _nekoCharacter.PlayAnimation("Run"));
            if (ImpairedBtn)
                RegisterButtonAction(ImpairedBtn, () => _nekoCharacter.PlayAnimation("Impaired"));
            if (AttackABtn)
                RegisterButtonAction(AttackABtn, () => _nekoCharacter.PlayAnimation("AttackA"));
            if (AttackBBtn)
                RegisterButtonAction(AttackBBtn, () => _nekoCharacter.PlayAnimation("AttackB"));
            if (SpecialABtn)
                RegisterButtonAction(SpecialABtn, () => _nekoCharacter.PlayAnimation("SpecialA"));
            if (SpecialBBtn)
                RegisterButtonAction(SpecialBBtn, () => _nekoCharacter.PlayAnimation("SpecialB"));
            if (UltimateBtn)
                RegisterButtonAction(UltimateBtn, () => _nekoCharacter.PlayAnimation("Ultimate"));


            base.OnEnable();
        }
    }
}
