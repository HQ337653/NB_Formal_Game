using System.Collections;
using UnityEngine;
using DG.Tweening;
using NBGame.HealthSystem;
using System;

namespace NBGame.Player
{
    // this script is the script that control character04 
    public class charaTest : charaControllerThreeD
    {
        #region characterState
        [SerializeField] KnightControl Animation;
        bool CanWalk =true;
        bool CanAtk=true;
        bool CanDash=true;
        private States _states=States.idle;
        public States states
        {
           
            get { return _states; }
            set { 
                 if (value == States.walk&& _states != States.walk)
                {
                        CanWalk = true;
                        CanAtk = true;
                        CanDash = true;
                        Animation.running(); 
                   
                }
                else if (value == States.idle && _states != States.idle)
                {
                    CanWalk = true;
                    CanAtk = true;
                    CanDash = true;
                    Animation.idle();
                }
                else if (value == States.preformAtk1)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.attack_1();
                }
                else if (value == States.skill1)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.skill_1();
                }
                else if (value == States.skill2)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.skill_3();
                }
                else if (value == States.preformAtk2)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.attack_2();
                }
                else if (value == States.preformAtk3)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.attack_1();
                }
                else if (value == States.preformAtk4)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.attack_2();
                }
                else if (value == States.preformAtk5)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.attack_1();
                }
                if (value == States.dash)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.skill_3();
                }
                if (value == States.stun)
                {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.stun();
                }
                else if (value == States.specialAtk) {
                    CanWalk = false;
                    CanAtk = false;
                    CanDash = false;
                    Animation.skill_2();
                    
                }
                _states = value;
            }

        }

        public enum States
        {
            walk, idle, dash, preformAtk1, preformAtk2, preformAtk3, preformAtk4, preformAtk5, specialAtk, emptyState, skill1, skill2, stun, enterScene

        }

        #endregion

        #region speed
        private float _AtkSpeed;
        public override float AtkSpeed { get { return _AtkSpeed; }set{ _AtkSpeed = value; Animation.changeAtkSpeed(value); } }
        public override float SpeedFactor { get { return base.SpeedFactor; } set { base. SpeedFactor = value; Animation.changeWalkSpeed(value); } }

        #endregion

        [SerializeField] CharacterHp hpScript;
        // current number of combat
        int combatNum;
        //when the normal atk input action is preformed or canceld 
        bool AtkKeyInputed;
        bool AtkKeyCanceld;
        // prebeb for the shield(both E and Q)
        [SerializeField] GameObject shield;
        [SerializeField] Sprite EBuffIcon;
        [SerializeField] Sprite QBuffIcon;


        #region unityMethods
        private void Awake()
        {
            base.Awake();
            AtkSpeed = 1;
            SpeedFactor = 1;
        }
        private void Start()
        {
            base.Start();
            CanWalk = true;
            combatNum = 0;
            inputActions.In3d.NormalAtk.performed += ctx => { if(isActiveAndEnabled) {AtkKeyInputed = true; if (combatNum == 0) { StartCoroutine(normalAtkProcess()); } } };
            //inputActions.In3d.NormalAtkLongPress.performed += ctx => { AtkKeyInputed = true; if (combatNum == 0) { StartCoroutine(normalAtkProcess()); } };
            inputActions.In3d.NormalAtk.canceled += ctx => AtkKeyCanceld = true;
            inputActions.In3d.Dash.performed += ctx => { if (isActiveAndEnabled && CanDash) StartCoroutine(dashProcess()); };
            inputActions.In3d.E.performed += ctx => { if (isActiveAndEnabled && CanAtk) { StartCoroutine(E()); } };
            inputActions.In3d.Q.performed += ctx => { if (isActiveAndEnabled && CanAtk) { StartCoroutine(Q()); } };
            hpScript.stun +=stun ;

        }

        private void OnTriggerEnter(Collider other)
        {
            if (states==States.dash)
            {
                gameObject.transform.DOPause();
                Debug.Log("hited");
                selfRb.transform.position = gameObject.transform.position;
                gameObject.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        private void FixedUpdate()
        {
            if (states!= States.dash && MovingFromInput && CanWalk)
            {
                states = States.walk;
                selfRb.velocity = new Vector3(movingDirection.x * WalkSpeed*SpeedFactor / Time.timeScale , selfRb.velocity.y, movingDirection.y * WalkSpeed * SpeedFactor / Time.timeScale);
            }
            else if(states != States.dash && !MovingFromInput && CanWalk && states!= States.idle)
            {
                states = States.idle;
            }
        }

        public override void SwitchToScene()
        {
            Animation.backToActive();
            _states = States.enterScene;

        }

        public override void LeaveScene()
        {
            

        }

        private void OnEnable()
        {
            
            
            base.OnEnable();
            //states = States.idle;
            combatNum = 0;
        }

        private void OnDisable()
        {
           // states = States.idle;
        }
        #endregion


        private void stun()
        {
            StartCoroutine(stunProcess());
        }

        private IEnumerator stunProcess()
        {
            states = States.stun;
            yield return new WaitForSecondsRealtime(0.5f);
            states = States.idle;
        }

        #region Q
        private IEnumerator Q()
        {
            states = States.skill2;
            TeamShield s = new TeamShield();
            s.buffIcon = QBuffIcon;
            s.shieldPrefab = shield;
            gameObject.transform.parent.parent.gameObject.GetComponent<teamScripts>().addBuff(s);
            yield return new WaitForSecondsRealtime(1.5f / AtkSpeed);
            states = States.idle;
        }
        public class TeamShield : MonoBehaviour, TeamBuff
        {
            public Sprite buffIcon;
            public GameObject shieldPrefab;
            public GameObject shieldObj;
            teamScripts targetScript;
            public bool breaked;


            public int id;
            public void initiate(teamScripts target)
            {
                targetScript = target;
                targetScript.addBuffIcon(buffIcon);
                //create a shield graphic
                shieldObj = Instantiate(shieldPrefab);
                target.addObject(shieldObj);
                // add shield Hp
                id = targetScript.addShield(50);
                targetScript.TeamShieldBreak += shieldbreak;

            }

            public void overlying(TeamBuff overlayedBuff, teamScripts target)
            {
                id = (overlayedBuff as TeamShield).id;
                targetScript = target;
                shieldObj = (overlayedBuff as TeamShield).shieldObj;

                targetScript.FindShield(id).hp = 50 + target.FindShield(id).hp;
                targetScript.TeamShieldBreak += shieldbreak;

            }

            public void overlayed()
            {
                breaked = true;
                targetScript.TeamShieldBreak -= shieldbreak;
            }


            void shieldbreak(int i)
            {
                //id and the shield match
                if (i == id && !breaked)
                {
                    targetScript.RemoveBuffIcon(buffIcon);
                    targetScript.removeBuff(this);
                    // Debug.Log(shieldObj);
                    Destroy(shieldObj);
                    targetScript.TeamShieldBreak -= shieldbreak;
                    breaked = true;

                }
                else
                {
                    Debug.Log(id + " " + i + "|" + breaked);
                }
            }
        }
        #endregion

        #region E
        private IEnumerator E()
        {
            states = States.skill1;
            ShieldHp s = new ShieldHp();
            s.shieldObj = shield;
            s.buffIcon = EBuffIcon;
            characterScripts thisCharacter = gameObject.transform.parent.gameObject.GetComponent<characterScripts>();
            thisCharacter.addBuff(s);
            yield return new WaitForSecondsRealtime(1.5f / AtkSpeed);
            states = States.idle;
        }
        public class ShieldHp : Buff
        {
            public Sprite buffIcon;
            public GameObject shieldObj;
            characterScripts targetChara;
            CharacterHp targetScript;
            public bool breaked;
            GameObject currentShield;
            public int id;
            public void initiate(characterScripts target)
            {
                targetChara = target;
                targetScript = targetChara.HpScript;
                //create a shield graphic
                currentShield = Instantiate(shieldObj);
                currentShield.transform.parent = target.position.transform;
                currentShield.transform.localPosition = new Vector3(0, 0, 0);
                //add buff icon
                targetChara.AddBuffIcon(buffIcon);
                // add shield Hp
                id = targetScript.addShield(50);
                targetScript.shieldBreak += shieldbreak;

            }

            public void overlying(Buff overlayedBuff, characterScripts target)
            {
                if (overlayedBuff != null && target.HpScript.FindShield((overlayedBuff as ShieldHp).id) != null)
                {
                    id = (overlayedBuff as ShieldHp).id;
                    targetChara = target;
                    currentShield = (overlayedBuff as ShieldHp).currentShield;
                    targetScript = targetChara.HpScript;

                    targetScript.FindShield(id).hp = 50 + target.HpScript.FindShield(id).hp;
                    targetScript.shieldBreak += shieldbreak;
                }
                else
                {

                    Debug.Log("bug:" + overlayedBuff + " " + target);
                }
            }

            public void overlayed()
            {
                breaked = true;
                targetScript.shieldBreak -= shieldbreak;
            }


            void shieldbreak(int i)
            {
                //id and the shield match
                if (i == id && !breaked)
                {
                    targetChara.RemoveBuffIcon(buffIcon);
                    targetChara.removeBuff(this);
                    Destroy(currentShield);
                    targetScript.shieldBreak -= shieldbreak;
                    breaked = true;

                }
                else
                {
                    Debug.Log(id + " " + i + "|" + breaked);
                }
            }
        }
        #endregion

        #region normalAtk
        protected virtual IEnumerator normalAtkProcess()
        {
           
            if (combatNum < 5)
            {
                combatNum += 1;
            }
            else
            {
                combatNum = 1;
            }
            StartCoroutine(normalAtk(combatNum));
            yield return new WaitForSecondsRealtime(0.3f/ AtkSpeed);
            float waitTime = 0;

            //第三下可以蓄力攻击，最大蓄力时间为2秒，最小0.5秒，等待0.5秒，
            if (combatNum == 2)
            {
                AtkKeyCanceld = false;
                while (waitTime <= 1.4)
                {
                        if (AtkKeyInputed&& CanAtk)//玩家点了
                    {
                      //  Debug.Log("玩家点了");
                        AtkKeyInputed = false;
                        float HoldTime = 0;
                        while (HoldTime <= 1)//等2秒
                        {
                            if (AtkKeyCanceld)//玩家松手
                            {
                                
                                AtkKeyCanceld = false;
                                if (HoldTime <= 0.3)//没蓄力
                                {
                                   //normalAtk(combatNum);
                                    //Debug.Log("没蓄力");
                                    StartCoroutine(normalAtkProcess());
                                    yield break;
                                }
                                else//蓄力
                                {
                                    Debug.Log("蓄力");
                                    StartCoroutine(specialAtk(HoldTime));
                                    combatNum = 0;
                                }
                                yield break;
                            }
                            HoldTime += Time.unscaledDeltaTime;
                            yield return null;
                        }//按了两秒
                        //Debug.Log("蓄力");
                      StartCoroutine(  specialAtk(HoldTime));
                        combatNum = 0;
                        yield break;
                    }
                    waitTime += Time.unscaledDeltaTime;
                    yield return null;
                }
                //0.5秒啥都没点
                combatNum = 0;
                yield break;

            }
            else
            {
                while (waitTime <= 1.5)
                {
                    if (AtkKeyInputed && CanAtk)
                    {
                        //StartCoroutine( normalAtk(combatNum));
                        AtkKeyInputed = false;
                        StartCoroutine(normalAtkProcess());
                        yield break;
                    }
                    waitTime += Time.unscaledDeltaTime;
                    yield return null;
                }
            }
           // Debug.Log("断了");
            combatNum = 0;
            yield break;
        }
        IEnumerator normalAtk(int combatNumber)
        {
            float beforeHitSec= 0.5f;
            AtkKeyInputed = false;
            if (combatNumber==1)
            {
                states = States.preformAtk1;
            }
          else  if (combatNumber == 2)
            {
                states = States.preformAtk2;
                beforeHitSec = 0.55f;
            }
           else if (combatNumber == 3)
            {
                states = States.preformAtk3;

            }
          else  if (combatNumber == 4)
            {
                states = States.preformAtk4;
                beforeHitSec = 0.55f;
            }
           else
            {
                states = States.preformAtk5;
            }
            yield return new WaitForSecondsRealtime(beforeHitSec / AtkSpeed);
            Vector3 center = gameObject.transform.position + gameObject.transform.forward * 0.4f;
            Vector3 half = new Vector3(0.15f, 0.25f, 0.13f);
            //testRange(center, half);
            bool hited = false;
            Collider[] c = Physics.OverlapBox(center, half);
            foreach (Collider Enemy in c)
            {
                EnemyHp script = Enemy.gameObject.GetComponent<EnemyHp>();
                if (script != null)
                {
                    EffectsManager.addCombo();
                    script.damage(100, false);
                    hited = true;
                }
            }
            
            if (hited)
            {

                Animation.changeSpeed(0.1f);
                yield return new WaitForSecondsRealtime(0.07f / AtkSpeed);
                Animation.changeSpeed(1);
                yield return new WaitForSecondsRealtime(1.1f -0.07f - beforeHitSec / AtkSpeed);

            }
            else
            {
                //testRange( center,  half);
                yield return new WaitForSecondsRealtime(1.1f- beforeHitSec / AtkSpeed);
            }
            states = States.idle;
        }

        IEnumerator specialAtk(float time)
        {
            states = States.specialAtk;
            AtkKeyInputed = false;
            yield return new WaitForSecondsRealtime(1.1f / AtkSpeed);
            states = States.idle;
        }
        #endregion

        private IEnumerator dashProcess()
        {
            states = States.dash;
            Dashing = true;
            int direction = -1;
            if (movingDirection.x > 0)
            {
                direction = 1;
            }
            flip(direction == 1);

            gameObject.transform.DOLocalMoveX(direction * 4, 0.5f);
            yield return new WaitForSecondsRealtime(0.5f);
            states = States.idle;
            Dashing = false;
            selfRb.transform.position = gameObject.transform.position;
            gameObject.transform.localPosition = new Vector3(0, 0, 0);
        }
        void testRange(Vector3 center, Vector3 half)
        {
            EffectsManager.RedCubeTester(center + half);
            EffectsManager.RedCubeTester(center - half);
            EffectsManager.RedCubeTester(new Vector3(center.x - half.x, center.y + half.y, center.z + half.z));
            EffectsManager.RedCubeTester(new Vector3(center.x + half.x, center.y - half.y, center.z + half.z));
            EffectsManager.RedCubeTester(new Vector3(center.x - half.x, center.y + half.y, center.z - half.z));
            EffectsManager.RedCubeTester(new Vector3(center.x + half.x, center.y - half.y, center.z - half.z));
        }

    }
}
