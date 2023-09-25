using UnityEngine;
using Modding;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GlobalEnums;
using MonoMod.Cil;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Satchel.BetterMenus;
using SFCore.Utils;
using HKMirror;
using HKMirror.Hooks.ILHooks;
using HKMirror.Reflection.SingletonClasses;

namespace CharmOverhaul
{
    #region Menu
    public static class ModMenu
    {
        private static Menu? MenuRef;
        public static MenuScreen CreateModMenu(MenuScreen modlistmenu)
        {
            MenuRef ??= new Menu("CharmOverhaul Options", new Element[]
            {
                Blueprints.HorizontalBoolOption
                (
                    "Avaricious Swarm",
                    "Gathering Swarm + Fragile/Unbreakable Strength",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.AvariciousSwarm = b;
                    },
                    () => CharmOverhaulMod.LS.AvariciousSwarm
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Balanced Blow",
                    "Heavy Blow + Steady Body",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.BalancedBlow = b;
                    },
                    () => CharmOverhaulMod.LS.BalancedBlow
                 ),

                //Blueprints.HorizontalBoolOption
                //(
                //    "Blazing Speed",
                //    "Fury of the Fallen + Sprintmaster",
                //    (b) =>
                //    {
                //        CharmOverhaulMod.LS.BlazingSpeed = b;
                //    },
                //    () => CharmOverhaulMod.LS.BlazingSpeed
                // ),

                Blueprints.HorizontalBoolOption
                (
                    "Burning Odor",
                    "Defender's Crest + Fury of the Fallen",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.BurningOdor = b;
                    },
                    () => CharmOverhaulMod.LS.BurningOdor
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Depraved Womb",
                    "Glowing Womb + Soul Eater",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.DepravedWomb = b;
                    },
                    () => CharmOverhaulMod.LS.DepravedWomb
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Doom Desire",
                    "Fury of the Fallen + Fragile/Unbreakable Strength",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.DoomDesire = b;
                    },
                    () => CharmOverhaulMod.LS.DoomDesire
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Entrenched Shell",
                    "Stalwart Shell + Baldur Shell",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.EntrenchedShell = b;
                    },
                    () => CharmOverhaulMod.LS.EntrenchedShell
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Gilded Hunger",
                    "Fragile/Unbreakable Strength + Soul Eater",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.GildedHunger = b;
                    },
                    () => CharmOverhaulMod.LS.GildedHunger
                 ),

                //Blueprints.HorizontalBoolOption
                //(
                //    "Hiveshell",
                //    "Hiveblood + Baldur Shell",
                //    (b) =>
                //    {
                //        CharmOverhaulMod.LS.HiveShell = b;
                //    },
                //    () => CharmOverhaulMod.LS.HiveShell
                // ),

                Blueprints.HorizontalBoolOption
                (
                    "Hivesong",
                    "Hiveblood + Grubsong",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.HiveSong = b;
                    },
                    () => CharmOverhaulMod.LS.HiveSong
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Kinematic Shell",
                    "Stalwart Shell + Defender's Crest",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.KinematicShell = b;
                    },
                    () => CharmOverhaulMod.LS.KinematicShell
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Lifeblood Elegy",
                    "Joni's Blessing + Grubberfly's Elegy",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.LifebloodElegy = b;
                    },
                    () => CharmOverhaulMod.LS.LifebloodElegy
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Lifeblood Melody",
                    "Joni's Blessing + Carefree Melody",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.LifebloodMelody = b;
                    },
                    () => CharmOverhaulMod.LS.LifebloodMelody
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Shadow Thief",
                    "Sharp Shadow + Voidheart + Soul Catcher",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.ShadowThief = b;
                    },
                    () => CharmOverhaulMod.LS.ShadowThief
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Shield Breacher",
                    "Heavy Blow + Nailmaster's Glory",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.ShieldBreacher = b;
                    },
                    () => CharmOverhaulMod.LS.ShieldBreacher
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Sorcerer Stone",
                    "Shaman Stone + Kingsoul",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.SorcererStone = b;
                    },
                    () => CharmOverhaulMod.LS.SorcererStone
                ),

                Blueprints.HorizontalBoolOption
                (
                    "Umbral Vision",
                    "Sharp Shadow + Sprintmaster",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.UmbralVision = b;
                    },
                    () => CharmOverhaulMod.LS.UmbralVision
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Vengeful Melody",
                    "Carefree Melody + Fury of the Fallen",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.VengefulMelody = b;
                    },
                    () => CharmOverhaulMod.LS.VengefulMelody
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Void Twister",
                    "Voidheart + Spell Twister",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.VoidTwister = b;
                    },
                    () => CharmOverhaulMod.LS.VoidTwister
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Wayward Swarm",
                    "Wayward Compass + Gathering Swarm",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.WaywardSwarm = b;
                    },
                    () => CharmOverhaulMod.LS.WaywardSwarm
                 ),

                Blueprints.HorizontalBoolOption
                (
                    "Worldsoul / Godsoul",
                    "Kingsoul + Soul Catcher / Soul Eater",
                    (b) =>
                    {
                        CharmOverhaulMod.LS.WorldSoul = b;
                    },
                    () => CharmOverhaulMod.LS.WorldSoul
                 )
            });
            return MenuRef.GetMenuScreen(modlistmenu);
        }
    }
    #endregion
    public class CharmOverhaulMod : Mod, ICustomMenuMod, ILocalSettings<LocalSettings>
    {
        #region Boilerplate
        private static CharmOverhaulMod? _instance;

        internal static CharmOverhaulMod Instance
        {
            get
            {
                if (_instance == null)
                {
                    throw new InvalidOperationException($"An instance of {nameof(CharmOverhaulMod)} was never constructed");
                }
                return _instance;
            }
        }

        public MenuScreen GetMenuScreen(MenuScreen modListMenu, ModToggleDelegates? toggleDelegates) => ModMenu.CreateModMenu(modListMenu);
        public bool ToggleButtonInsideMenu => false;
        public static LocalSettings LS { get; private set; } = new();
        public void OnLoadLocal(LocalSettings s) => LS = s;
        public LocalSettings OnSaveLocal() => LS;
        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();
        public CharmOverhaulMod() : base("CharmOverhaul")
        {
            _instance = this;
        }
        #endregion

        #region Custom Variables
        private bool shield = false;

        private bool kinematic = false;

        private float avariciousTimer;

        private AudioClip? geoCollect;
        #endregion

        #region Init
        public override void Initialize()
        {
            Log("Initializing");

            On.HeroController.Awake += OnHCAwake;
            On.HeroController.CharmUpdate += OnCharmUpdate;
            On.HeroController.TakeDamage += OnHCTakeDamage;
            On.HeroController.AddGeo += OnAddGeo;
            On.HeroController.CancelDash += OnCancelDash;
            On.HeroController.ShouldHardLand += OnShouldHardLand;

            On.HealthManager.TakeDamage += OnHMTakeDamage;

            On.NailSlash.SetFury += OnSetFury;

            On.PlayMakerFSM.OnEnable += OnFSMEnable;

            On.HutongGames.PlayMaker.Actions.SetPlayerDataInt.OnEnter += OnSetPlayerDataIntAction;
            On.HutongGames.PlayMaker.Actions.SetPlayerDataBool.OnEnter += OnSetPlayerDataBoolAction;
            On.HutongGames.PlayMaker.Actions.SendMessage.OnEnter += OnSendMessageAction;
            On.HutongGames.PlayMaker.Actions.SendMessageV2.DoSendMessage += OnSendMessageV2Action;
            On.HutongGames.PlayMaker.Actions.Wait.OnEnter += OnWaitAction;
            On.HutongGames.PlayMaker.Actions.SpawnObjectFromGlobalPoolOverTime.OnUpdate += OnSpawnObjectFromGlobalPoolOverTimeAction;

            ModHooks.GetPlayerIntHook += OnGetPlayerIntHook;
            ModHooks.HeroUpdateHook += OnHeroUpdateHook;
            ModHooks.AttackHook += OnAttackHook;
            ModHooks.SoulGainHook += OnSoulGainHook;

            On.GeoControl.OnEnable += OnGeoEnable;

            On.SpellFluke.OnEnable += OnSpellFluke;
            On.ExtraDamageable.GetDamageOfType += OnExtraDamageGetType;
            On.KnightHatchling.OnEnable += OnHatchlingEnable;

            geoCollect = Resources.FindObjectsOfTypeAll<AudioClip>().First(c => c.name == "geo_small_collect_1");

            // Joni's Blessing 1.4x -> 1.5x
            ILHeroController.orig_CharmUpdate += (il) =>
            {
                ILCursor cursor = new ILCursor(il).Goto(0);
                cursor.GotoNext(i => i.MatchLdcR4(1.4f));
                cursor.GotoNext();
                cursor.EmitDelegate<Func<float, float>>(x => 1.5f);
            };

            Log("Initialized");
        }
        #endregion

        #region Changes
        // Glowing Womb Buffs
        private void OnHatchlingEnable(On.KnightHatchling.orig_OnEnable orig, KnightHatchling self)
        {
            self.normalDetails.damage = 10;
            self.dungDetails.damage = 6;

            orig(self);
        }

        // Rebalancing Soul Eater
        private int OnSoulGainHook(int num)
        {
            num -= PlayerDataAccess.equippedCharm_21 ? 2 : 0;

            return num;
        }

        // Kingsoul + Shaman Stone
        private void OnAttackHook(AttackDirection dir)
        {
            int totalMP = PlayerDataAccess.MPCharge + PlayerDataAccess.MPReserve;

            if (dir == AttackDirection.normal && PlayerDataAccess.royalCharmState == 3 && PlayerDataAccess.equippedCharm_36 && PlayerDataAccess.equippedCharm_19 && totalMP >= 99 && LS.SorcererStone)
            {
                if (UnityEngine.Random.Range(1, 101) <= (totalMP - 66) / 33 * 11)
                {
                    HeroController.instance.TakeMP(11);
                    HeroController.instance.spell1Prefab.Spawn(HeroController.instance.transform.position + new Vector3(0f, 0.3f, 0.3f));
                }
            }
        }

        // Glowing Womb + Soul Eater
        private void OnWaitAction(On.HutongGames.PlayMaker.Actions.Wait.orig_OnEnter orig, Wait self)
        {
            if (self.Fsm.GameObject.name == "Charm Effects" && self.Fsm.Name == "Hatchling Spawn" && self.State.Name == "Equipped")
            {
                self.time.Value = PlayerDataAccess.equippedCharm_21 && LS.DepravedWomb ? 3 : 4;
            }

            orig(self);
        }

        // Set Crystal Heart damage on getting Crystal Heart
        private void OnSetPlayerDataBoolAction(On.HutongGames.PlayMaker.Actions.SetPlayerDataBool.orig_OnEnter orig, SetPlayerDataBool self)
        {
            if (self.Name == "hasSuperDash" && self.value.Value == true)
            {
                HeroController.instance.transform.Find("SuperDash Damage").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("damageDealt").Value = (PlayerDataAccess.equippedCharm_34 ? 2 : 1) * (13 + (PlayerDataAccess.nailSmithUpgrades * 4));
                HeroController.instance.transform.Find("Effects/SD Burst").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("damageDealt").Value = (PlayerDataAccess.equippedCharm_34 ? 2 : 1) * (13 + (PlayerDataAccess.nailSmithUpgrades * 4));
            }

            orig(self);
        }

        private int OnExtraDamageGetType(On.ExtraDamageable.orig_GetDamageOfType orig, ExtraDamageTypes extraDamageTypes)
        {
            // Defender's Crest + Fury of the Fallen
            if (LS.BurningOdor && (HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").ActiveStateName == "Activate" || HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").ActiveStateName == "Stay Furied" && extraDamageTypes == ExtraDamageTypes.Dung))
            {
                return 3;
            }

            return orig(extraDamageTypes);
        }
        private void OnSpawnObjectFromGlobalPoolOverTimeAction(On.HutongGames.PlayMaker.Actions.SpawnObjectFromGlobalPoolOverTime.orig_OnUpdate orig, SpawnObjectFromGlobalPoolOverTime self)
        {
            if (self.Fsm.GameObject.name == "Dung" && self.Fsm.Name == "Control" && self.State.Name == "Equipped")
            {
                self.frequency.Value = 0.75f - (LS.BurningOdor && ((HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").ActiveStateName == "Activate" || HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").ActiveStateName == "Stay Furied")) ? 0.375f : 0);
            }

            orig(self);
        }


        // Increases Flukenest damage
        private void OnSpellFluke(On.SpellFluke.orig_OnEnable orig, SpellFluke self)
        {
            orig(self);

            ReflectionHelper.SetField(self, "damage", PlayerDataAccess.equippedCharm_19 ? 7 : 5);
        }

        private void OnSendMessageV2Action(On.HutongGames.PlayMaker.Actions.SendMessageV2.orig_DoSendMessage orig, SendMessageV2 self)
        {
            // Kingsoul + Soul Catcher / Soul Eater
            if (self.Fsm.GameObject.name == "Charm Effects" && self.Fsm.Name == "White Charm" && self.State.Name == "Soul UP")
            {
                self.functionCall.IntParameter = 4 + (LS.WorldSoul && PlayerDataAccess.equippedCharm_20 ? (PlayerDataAccess.equippedCharm_21 ? 3 : 1) : LS.WorldSoul && PlayerDataAccess.equippedCharm_21 ? 2 : 0);
            }

            orig(self);
        }

        // Fury of the Fallen + Sprintmaster Speed Boost
        private void OnSetFury(On.NailSlash.orig_SetFury orig, NailSlash self, bool set)
        {
            if (PlayerDataAccess.equippedCharm_37)
            {
                HeroController.instance.RUN_SPEED_CH += set ? 2f : -2f;
                HeroController.instance.RUN_SPEED_CH_COMBO += set ? 2f : -2f;
            }

            orig(self, set);
        }

        // Sharp Shadow + Sprintmaster i-frames
        private void OnCancelDash(On.HeroController.orig_CancelDash orig, HeroController self)
        {
            if (LS.UmbralVision && self.cState.shadowDashing && PlayerDataAccess.equippedCharm_16 && PlayerDataAccess.equippedCharm_37)
            {
                HeroController.instance.StartCoroutine("Invulnerable", 0.25f);
            }

            orig(self);
        }

        // Sharp Shadow + Voidheart + Soul Catcher SOUL gain
        private void OnHMTakeDamage(On.HealthManager.orig_TakeDamage orig, HealthManager self, HitInstance hitInstance)
        {
            if (LS.ShadowThief && hitInstance.AttackType == AttackTypes.SharpShadow && PlayerDataAccess.equippedCharm_36 && PlayerDataAccess.royalCharmState == 4 && PlayerDataAccess.equippedCharm_20)
            {
                HeroController.instance.AddMPCharge(8);
            }

            // Carefree Melody + Fury of the Fallen Crits
            if (LS.VengefulMelody && hitInstance.AttackType == AttackTypes.Nail && PlayerDataAccess.equippedCharm_6 && HeroController.instance.carefreeShieldEquipped && !(HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").ActiveStateName == "Activate") && !(HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").ActiveStateName == "Stay Furied"))
            {
                hitInstance.DamageDealt = (int)(hitInstance.DamageDealt * ((UnityEngine.Random.Range(0, 100) < ((2 * (PlayerDataAccess.maxHealth - PlayerDataAccess.health)) + ((PlayerDataAccess.maxHealth == PlayerDataAccess.health) ? 1 : 0))) ? 1.25f : 1.0f));
            }

            // Greed + Fury of the Fallen Geo
            if (LS.DoomDesire && hitInstance.AttackType == AttackTypes.Nail && PlayerDataAccess.equippedCharm_6 && PlayerDataAccess.equippedCharm_24 && !PlayerDataAccess.brokenCharm_24)
            {
                HeroController.instance.AddGeo((int)(hitInstance.DamageDealt * hitInstance.Multiplier * 0.2f));
            }

            orig(self, hitInstance);
        }

        private void OnSendMessageAction(On.HutongGames.PlayMaker.Actions.SendMessage.orig_OnEnter orig, SendMessage self)
        {
            // Voidheart + Spell Twister reduced costs
            if (self.Fsm.GameObject.name == "Knight" && self.Fsm.Name == "Spell Control")
            {
                if (self.State.Name == "Fireball 2" && self.functionCall.FunctionName == "TakeMP")
                {
                    self.Fsm.FsmComponent.GetFsmIntVariable("MP Cost").Value = (LS.VoidTwister && PlayerDataAccess.equippedCharm_33 && PlayerDataAccess.equippedCharm_36 && PlayerDataAccess.royalCharmState == 4) ? 22 : PlayerDataAccess.equippedCharm_33 ? 24 : 33;
                }

                else if (self.State.Name == "Scream Burst 2" && self.functionCall.FunctionName == "TakeMP")
                {
                    self.Fsm.FsmComponent.GetFsmIntVariable("MP Cost").Value = (LS.VoidTwister && PlayerDataAccess.equippedCharm_33 && PlayerDataAccess.equippedCharm_36 && PlayerDataAccess.royalCharmState == 4) ? 22 : PlayerDataAccess.equippedCharm_33 ? 24 : 33;
                }

                else if (self.State.Name == "Level Check 2" && self.functionCall.FunctionName == "TakeMP")
                {
                    self.Fsm.FsmComponent.GetFsmIntVariable("MP Cost").Value = (LS.VoidTwister && PlayerDataAccess.equippedCharm_33 && PlayerDataAccess.equippedCharm_36 && PlayerDataAccess.royalCharmState == 4 && self.Fsm.FsmComponent.GetFsmIntVariable("Spell Level").Value == 2) ? 22 : LS.VoidTwister && PlayerDataAccess.equippedCharm_33 ? 24 : 33;
                }
            }

            // Hiveblood + Grubsong MP Amount
            else if (self.Fsm.GameObject.name == "Health" && self.Fsm.Name == "Hive Health Regen")
            {
                if (self.State.Name == "SOUL 1")
                {
                    self.functionCall.IntParameter.Value = LS.HiveSong && PlayerDataAccess.equippedCharm_3 ? (PlayerDataAccess.equippedCharm_35 ? 10 : 5) : 0;
                }

                else if (self.State.Name == "SOUL 2")
                {
                    self.functionCall.IntParameter.Value = LS.HiveSong && PlayerDataAccess.equippedCharm_3 ? (PlayerDataAccess.equippedCharm_35 ? 15 : 10) : 0;
                }
            }

            orig(self);
        }

        // Wayward Compass + Gathering Swarm instant money
        private void OnGeoEnable(On.GeoControl.orig_OnEnable orig, GeoControl self)
        {
            orig(self);

            if (LS.WaywardSwarm && PlayerDataAccess.equippedCharm_1 && PlayerDataAccess.equippedCharm_2)
            {
                HeroController.instance.AddGeo((int)Math.Pow(5, self.type));
                self.Disable(0f);
            }
        }

        // Soul Eater + Greed granting SOUL
        private void OnAddGeo(On.HeroController.orig_AddGeo orig, HeroController self, int amount)
        {
            if (LS.GildedHunger && PlayerDataAccess.equippedCharm_21 && PlayerDataAccess.equippedCharm_24 && !PlayerDataAccess.brokenCharm_24)
            {
                self.AddMPCharge(amount);
                GameManager.instance.StartCoroutine(SoulUpdate());
            }

            orig(self, amount);
        }

        private int OnGetPlayerIntHook(string name, int orig)
        {
            // Heavy Blow increases Nail damage
            if (name == "nailDamage")
            {
                orig = (int)(orig * (PlayerDataAccess.equippedCharm_15 ? 1.15f : 1.0f));
            }

            return orig;
        }

        private void OnHCTakeDamage(On.HeroController.orig_TakeDamage orig, HeroController self, GameObject go, CollisionSide damageSide, int damageAmount, int hazardType)
        {
            // Stalwart Shell + Defender's Crest
            if (LS.KinematicShell && PlayerDataAccess.equippedCharm_4 && PlayerDataAccess.equippedCharm_10 && self.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0 - self.MAX_FALL_VELOCITY && !self.cState.spellQuake && !self.cState.shadowDashing)
            {
                damageAmount = 0;
                if (!kinematic)
                {
                    go.GetComponent<HealthManager>().ApplyExtraDamage(20);
                    kinematic = true;
                    GameManager.instance.StartCoroutine(Kinematic());
                }
            }

            // Joni's Blessing + Carefree Melody
            if (HeroControllerR.hitsSinceShielded != 0 && hazardType == 1 && PlayerDataAccess.equippedCharm_27 && HeroController.instance.carefreeShieldEquipped)
            {
                shield = true;
            }

            orig(self, go, damageSide, damageAmount, hazardType);

            // Joni's Blessing + Carefree Melody
            if (LS.LifebloodMelody && HeroControllerR.hitsSinceShielded == 0 && shield)
            {
                EventRegister.SendEvent("ADD BLUE HEALTH");
                if (PlayerDataAccess.equippedCharm_23 && !PlayerDataAccess.brokenCharm_23 && PlayerDataAccess.gotCharm_9)
                {
                    EventRegister.SendEvent("ADD BLUE HEALTH");
                }

                shield = false;
            }

            // Joni's Blessing + Grubberfly's Elegy
            if (LS.LifebloodElegy && PlayerDataAccess.equippedCharm_27 && PlayerDataAccess.equippedCharm_35)
            {
                HeroControllerR.joniBeam = true;
            }
        }

        private void OnSetPlayerDataIntAction(On.HutongGames.PlayMaker.Actions.SetPlayerDataInt.orig_OnEnter orig, HutongGames.PlayMaker.Actions.SetPlayerDataInt self)
        {
            // Changes cost of Carefree Melody
            if (self.Fsm.GameObject.name == "Nymm NPC" && self.Fsm.Name == "Conversation Control" && self.State.Name == "Get Charm" && self.intName.Value == "charmCost_40")
            {
                self.value.Value = 2;
            }

            // Changes cost of Kingsoul
            if (self.Fsm.GameObject.name == "UI Msg Get WhiteCharm" && self.Fsm.Name == "Msg Control" && self.State.Name == "Set Full" && self.intName.Value == "charmCost_36")
            {
                self.value.Value = 4;
            }

            //Increases Crystal Heart damage when Nail damage is changed
            if (self.intName.Value == "nailDamage")
            {
                HeroController.instance.transform.Find("SuperDash Damage").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("damageDealt").Value = (PlayerDataAccess.equippedCharm_34 ? 2 : 1) * (13 + (PlayerDataAccess.nailSmithUpgrades * 4));
                HeroController.instance.transform.Find("Effects/SD Burst").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("damageDealt").Value = (PlayerDataAccess.equippedCharm_34 ? 2 : 1) * (13 + (PlayerDataAccess.nailSmithUpgrades * 4));
            }

            orig(self);
        }

        private void OnCharmUpdate(On.HeroController.orig_CharmUpdate orig, HeroController self)
        {
            orig(self);

            // Increase Walking Speed if Sprintmaster is equipped
            self.WALK_SPEED = 6f + (PlayerDataAccess.equippedCharm_37 ? 0.85f : 0);

            // Changes charge time of Crystal Heart based on Deep Focus & Quick Focus
            self.gameObject.LocateMyFSM("Superdash").GetFsmFloatVariable("Charge Time").Value = 0.8f + (PlayerDataAccess.equippedCharm_34 ? 0.2f : 0) - (PlayerDataAccess.equippedCharm_7 ? 0.2f : 0);

            // Increases Crystal Heart damage (including Nail upgrades and Deep Focus scaling)
            HeroController.instance.gameObject.transform.Find("SuperDash Damage").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("damageDealt").Value = (PlayerDataAccess.equippedCharm_34 ? 2 : 1) * (13 + (PlayerDataAccess.nailSmithUpgrades * 4));

            // Apparently the parent is removed at first, so we wait for it to exist again
            GameManager.instance.StartCoroutine(CDash());

            // Stalwart Shell & Baldur Shell increase i-frames
            self.INVUL_TIME_STAL = LS.EntrenchedShell && PlayerDataAccess.equippedCharm_5 ? 2.05f : 1.75f;

            // Heavy Blow + Nailmaster's Glory Spell Damage
            self.gameObject.transform.Find("Attacks/Great Slash").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("attackType").Value = (LS.ShieldBreacher && PlayerDataAccess.equippedCharm_15 && PlayerDataAccess.equippedCharm_26) ? 3 : 0;
            self.gameObject.transform.Find("Attacks/Dash Slash").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("attackType").Value = (LS.ShieldBreacher && PlayerDataAccess.equippedCharm_15 && PlayerDataAccess.equippedCharm_26) ? 3 : 0;
            self.gameObject.transform.Find("Attacks/Cyclone Slash/Hits/Hit L").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("attackType").Value = (LS.ShieldBreacher && PlayerDataAccess.equippedCharm_15 && PlayerDataAccess.equippedCharm_26) ? 3 : 0;
            self.gameObject.transform.Find("Attacks/Cyclone Slash/Hits/Hit R").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("attackType").Value = (LS.ShieldBreacher && PlayerDataAccess.equippedCharm_15 && PlayerDataAccess.equippedCharm_26) ? 3 : 0;

            // Fury of the Fallen Overcharming
            if (PlayerDataAccess.equippedCharm_6 && PlayerDataAccess.overcharmed)
            {
                PlayerData.instance.SetInt("maxHealth", 1);
                PlayerData.instance.SetInt("health", 1);
                HeroController.instance.gameObject.transform.Find("Charm Effects").gameObject.LocateMyFSM("Fury").SendEvent("HERO DAMAGED");
            }

            // Heavy Blow + Steady Body
            HeroController.instance.INVUL_TIME_PARRY = (LS.BalancedBlow && PlayerDataAccess.equippedCharm_14 && PlayerDataAccess.equippedCharm_15) ? 0.4f : 0.25f;
            HeroController.instance.INVUL_TIME_CYCLONE = (LS.BalancedBlow && PlayerDataAccess.equippedCharm_14 && PlayerDataAccess.equippedCharm_15) ? 0.4f : 0.25f;
        }

        private bool OnShouldHardLand(On.HeroController.orig_ShouldHardLand orig, HeroController self, Collision2D collision)
        {
            // Makes Steady Body prevent hard landings
            if (PlayerDataAccess.equippedCharm_14)
            {
                return false;
            }

            // Failsafe to reset Kinematic Shell bool in case of StopAllCoroutines
            kinematic = false;

            return orig(self, collision);
        }

        private void OnFSMEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self)
        {
            orig(self);

            // Hiveblood + Grubsong Interaction
            if (self.FsmName == "Hive Health Regen" && self.gameObject.name == "Health")
            {
                self.AddFsmState("SOUL 1");
                self.AddFsmState("SOUL 2");
                self.ChangeFsmTransition("Recover 1", "DAMAGE TAKEN", "SOUL 1");
                self.ChangeFsmTransition("Recover 2", "DAMAGE TAKEN", "SOUL 2");
                self.AddFsmTransition("SOUL 1", "FINISHED", "Start Recovery");
                self.AddFsmTransition("SOUL 2", "FINISHED", "Start Recovery");

                self.AddFsmAction("SOUL 1", new SendMessage()
                {
                    gameObject = new FsmOwnerDefault()
                    {
                        OwnerOption = OwnerDefaultOption.SpecifyGameObject,
                        GameObject = HeroController.instance.gameObject
                    },
                    delivery = 0,
                    options = SendMessageOptions.DontRequireReceiver,
                    functionCall = new FunctionCall()
                    {
                        FunctionName = "AddMPCharge",
                        ParameterType = "int",
                        IntParameter = 0
                    }
                });

                self.AddFsmAction("SOUL 2", new SendMessage()
                {
                    gameObject = new FsmOwnerDefault()
                    {
                        OwnerOption = OwnerDefaultOption.SpecifyGameObject,
                        GameObject = HeroController.instance.gameObject
                    },
                    delivery = 0,
                    options = SendMessageOptions.DontRequireReceiver,
                    functionCall = new FunctionCall()
                    {
                        FunctionName = "AddMPCharge",
                        ParameterType = "int",
                        IntParameter = 0
                    }
                });
            }

            // Baldur Shell + Hiveblood Regeneration
            if (self.FsmName == "Control" && self.gameObject.name == "Blocker Shield")
            {
                self.AddFsmFloatVariable("Timer");
                self.AddFsmState("Block Checker");
                self.AddFsmState("3 Blocks");
                self.AddFsmState("2 Blocks");
                self.AddFsmState("1 Blocks");
                self.AddFsmState("0 Blocks");
                self.AddFsmState("Restore");

                self.AddFsmTransition("Equipped", "HIVEBLOOD", "Block Checker");
                self.AddFsmTransition("Block Checker", "FOCUS START", "Hits Left?");
                self.AddFsmTransition("Block Checker", "3", "3 Blocks");
                self.AddFsmTransition("Block Checker", "2", "2 Blocks");
                self.AddFsmTransition("Block Checker", "1", "1 Blocks");
                self.AddFsmTransition("Block Checker", "0", "0 Blocks");
                self.AddFsmTransition("3 Blocks", "FOCUS START", "Hits Left?");
                self.AddFsmTransition("2 Blocks", "FOCUS START", "Hits Left?");
                self.AddFsmTransition("1 Blocks", "FOCUS START", "Hits Left?");
                self.AddFsmTransition("0 Blocks", "FOCUS START", "Hits Left?");
                self.AddFsmTransition("3 Blocks", "RESTORE", "Restore");
                self.AddFsmTransition("2 Blocks", "RESTORE", "Restore");
                self.AddFsmTransition("1 Blocks", "RESTORE", "Restore");
                self.AddFsmTransition("0 Blocks", "RESTORE", "Restore");
                self.AddFsmTransition("Restore", "FINISHED", "Equipped");

                self.AddFsmAction("Equipped", new PlayerDataBoolTest()
                {
                    gameObject = new FsmOwnerDefault()
                    {
                        OwnerOption = OwnerDefaultOption.SpecifyGameObject,
                        GameObject = GameManager.instance.gameObject,
                    },
                    boolName = "equippedCharm_29",
                    isTrue = FsmEvent.GetFsmEvent("HIVEBLOOD"),
                    isFalse = null
                });

                self.AddFsmAction("Block Checker", new GetPlayerDataInt()
                {
                    gameObject = new FsmOwnerDefault()
                    {
                        OwnerOption = OwnerDefaultOption.SpecifyGameObject,
                        GameObject = GameManager.instance.gameObject
                    },
                    intName = "blockerHits",
                    storeValue = self.GetFsmIntVariable("Blocks")
                });

                self.AddFsmAction("Block Checker", new IntCompare()
                {
                    integer1 = self.GetFsmIntVariable("Blocks"),
                    integer2 = 1,
                    equal = FsmEvent.GetFsmEvent("1"),
                    lessThan = FsmEvent.GetFsmEvent("0"),
                    greaterThan = null,
                    everyFrame = false
                });

                self.AddFsmAction("Block Checker", new IntCompare()
                {
                    integer1 = self.GetFsmIntVariable("Blocks"),
                    integer2 = 3,
                    equal = FsmEvent.GetFsmEvent("3"),
                    lessThan = FsmEvent.GetFsmEvent("2"),
                    greaterThan = null,
                    everyFrame = false
                });

                self.AddFsmAction("3 Blocks", new SetFloatValue()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    floatValue = 0f,
                    everyFrame = false
                });
                self.AddFsmAction("3 Blocks", new FloatAdd()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    add = 1f,
                    everyFrame = true,
                    perSecond = true
                });
                self.AddFsmAction("3 Blocks", new FloatCompare()
                {
                    float1 = self.GetFsmFloatVariable("Timer"),
                    float2 = 20f,
                    tolerance = 0f,
                    equal = FsmEvent.GetFsmEvent("RESTORE"),
                    lessThan = null,
                    greaterThan = FsmEvent.GetFsmEvent("RESTORE"),
                    everyFrame = true
                });


                self.AddFsmAction("2 Blocks", new SetFloatValue()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    floatValue = 0f,
                    everyFrame = false
                });
                self.AddFsmAction("2 Blocks", new FloatAdd()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    add = 1f,
                    everyFrame = true,
                    perSecond = true
                });
                self.AddFsmAction("2 Blocks", new FloatCompare()
                {
                    float1 = self.GetFsmFloatVariable("Timer"),
                    float2 = 24f,
                    tolerance = 0f,
                    equal = FsmEvent.GetFsmEvent("RESTORE"),
                    lessThan = null,
                    greaterThan = FsmEvent.GetFsmEvent("RESTORE"),
                    everyFrame = true
                });


                self.AddFsmAction("1 Blocks", new SetFloatValue()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    floatValue = 0f,
                    everyFrame = false
                });
                self.AddFsmAction("1 Blocks", new FloatAdd()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    add = 1f,
                    everyFrame = true,
                    perSecond = true
                });
                self.AddFsmAction("1 Blocks", new FloatCompare()
                {
                    float1 = self.GetFsmFloatVariable("Timer"),
                    float2 = 28f,
                    tolerance = 0f,
                    equal = FsmEvent.GetFsmEvent("RESTORE"),
                    lessThan = null,
                    greaterThan = FsmEvent.GetFsmEvent("RESTORE"),
                    everyFrame = true
                });

                self.AddFsmAction("0 Blocks", new SetFloatValue()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    floatValue = 0f,
                    everyFrame = false
                });
                self.AddFsmAction("0 Blocks", new FloatAdd()
                {
                    floatVariable = self.GetFsmFloatVariable("Timer"),
                    add = 1f,
                    everyFrame = true,
                    perSecond = true
                });
                self.AddFsmAction("0 Blocks", new FloatCompare()
                {
                    float1 = self.GetFsmFloatVariable("Timer"),
                    float2 = 32f,
                    tolerance = 0f,
                    equal = FsmEvent.GetFsmEvent("RESTORE"),
                    lessThan = null,
                    greaterThan = FsmEvent.GetFsmEvent("RESTORE"),
                    everyFrame = true
                });


                self.AddFsmAction("Restore", new PlayerDataIntAdd()
                {
                    gameObject = new FsmOwnerDefault()
                    {
                        OwnerOption = OwnerDefaultOption.SpecifyGameObject,
                        GameObject = GameManager.instance.gameObject
                    },
                    intName = "blockerHits",
                    amount = 1
                });

                self.AddMethod("Restore", () =>
                {
                    var blockerHUD = self.GetAction<Tk2dPlayAnimation>("HUD 1", 0).gameObject.GameObject.Value;
                    if (PlayerDataAccess.blockerHits > 0)
                    {
                        if (PlayerDataAccess.blockerHits < 4)
                        {
                            blockerHUD.GetComponent<tk2dSpriteAnimator>().Play($"UI Break {4 - PlayerDataAccess.blockerHits}");
                            self.gameObject.Find("Hit Crack").SetActive(true);
                        }
                        else if (PlayerDataAccess.blockerHits == 4)
                        {
                            blockerHUD.GetComponent<tk2dSpriteAnimator>().Play($"UI Appear");
                            self.gameObject.Find("Hit Crack").SetActive(false);
                        }
                        self.gameObject.Find("Pusher").SetActive(false);
                    }
                });
            }
        }

        // Sets Wayward Compass, Flukenest, Hiveblood, Dashmaster, Deep Focus, Dreamshield, and Carefree Melody costs.
        private void OnHCAwake(On.HeroController.orig_Awake orig, HeroController self)
        {
            orig(self);

            PlayerData.instance.SetInt("charmCost_2", 0);
            PlayerData.instance.SetInt("charmCost_11", 2);
            PlayerData.instance.SetInt("charmCost_29", 3);
            PlayerData.instance.SetInt("charmCost_31", 1);
            PlayerData.instance.SetInt("charmCost_34", 3);
            PlayerData.instance.SetInt("charmCost_38", 2);
            PlayerData.instance.SetInt("charmCost_40", 2);
        }

        // Avaricious Swarm
        public void OnHeroUpdateHook()
        {
            if (LS.AvariciousSwarm && PlayerDataAccess.equippedCharm_1 && PlayerDataAccess.equippedCharm_24 && !PlayerDataAccess.brokenCharm_24)
            {
                // Don't do it if in dream scene and not with dream wielder
                if (!(dreamZones.Contains(PlayerDataAccess.mapZone) && !PlayerDataAccess.equippedCharm_30))
                {
                    avariciousTimer += Time.deltaTime;

                    float procTime = PlayerDataAccess.equippedCharm_2 ? 8 : 10;

                    if (avariciousTimer > procTime)
                    {
                        avariciousTimer = 0f;

                        HeroController.instance.AddGeo((int)(UnityEngine.Random.Range(PlayerDataAccess.equippedCharm_10 ? 5 : 1, 25) * (PlayerDataAccess.equippedCharm_10 ? 1.25f : 1f)));
                        HeroController.instance.GetComponent<AudioSource>().PlayOneShot(geoCollect);
                    }
                }
            }
        }

        private IEnumerator Kinematic()
        {
            yield return new WaitForSeconds(0.5f);
            kinematic = false;
        }

        private IEnumerator SoulUpdate()
        {
            yield return new WaitForSeconds(0.5f);
            GameCameras.instance.gameObject.transform.Find("HudCamera/Hud Canvas/Soul Orb").gameObject.LocateMyFSM("Soul Orb Control").SendEvent("MP GAIN");
        }

        private IEnumerator CDash()
        {
            while (HeroController.instance.gameObject.transform.Find("Effects/SD Burst").gameObject == null)
            {
                yield return null;
            }

            HeroController.instance.gameObject.transform.Find("Effects/SD Burst").gameObject.LocateMyFSM("damages_enemy").GetFsmIntVariable("damageDealt").Value = (PlayerDataAccess.equippedCharm_34 ? 2 : 1) * (13 + (PlayerDataAccess.nailSmithUpgrades * 4));
        }

        private readonly List<MapZone> dreamZones = new()
        {
            MapZone.DREAM_WORLD, MapZone.ROYAL_QUARTER, MapZone.WHITE_PALACE, MapZone.FINAL_BOSS, MapZone.GODSEEKER_WASTE, MapZone.GODS_GLORY
        };
        #endregion
    }
    #region Settings
    public class LocalSettings
    {
        public bool AvariciousSwarm = true;
        public bool BalancedBlow = true;
        //public bool BlazingSpeed = true;
        public bool BurningOdor = true;
        public bool DepravedWomb = true;
        public bool DoomDesire = true;
        public bool EntrenchedShell = true;
        public bool GildedHunger = true;
        //public bool HiveShell = true;
        public bool HiveSong = true;
        public bool KinematicShell = true;
        public bool LifebloodElegy = true;
        public bool LifebloodMelody = true;
        public bool ShadowThief = true;
        public bool ShieldBreacher = true;
        public bool SorcererStone = true;
        public bool UmbralVision = true;
        public bool VengefulMelody = true;
        public bool VoidTwister = true;
        public bool WaywardSwarm = true;
        public bool WorldSoul = true;
    }
    #endregion
}
