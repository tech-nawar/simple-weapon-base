﻿using System.Collections.Generic;
using Sandbox;
using SWB_Base;
using SWB_Base.Attachments;
using SWB_Base.Bullets;

namespace SWB_WEAPONS;

[Library("swb_l96a1", Title = "L96a1")]
public class L96A1 : WeaponBaseSniper
{
    public override int Bucket => 5;
    public override HoldType HoldType => HoldType.Rifle;
    public override string HandsModelPath => "weapons/swb/hands/rebel/v_hands_rebel.vmdl";
    public override string ViewModelPath => "weapons/swb/snipers/l96a1/v_l96a1.vmdl";
    public override AngPos ViewModelOffset => new()
    {
        Angle = new Angles(0, -5, 0),
        Pos = new Vector3(-5, -2, 0)
    };
    public override string WorldModelPath => "weapons/swb/snipers/l96a1/w_l96a1.vmdl";
    public override string Icon => "code/swb_weapons/textures/l96a1.png";

    public override string LensTexture => "/materials/swb/scopes/swb_lens_hunter.png";
    public override string ScopeTexture => "/materials/swb/scopes/swb_scope_hunter.png";
    public override string ZoomInSound => "swb_sniper.zoom_in";
    public override bool UseRenderTarget => false;

    public L96A1()
    {
        UISettings = new UISettings
        {
            ShowCrosshair = false
        };

        General = new WeaponInfo
        {
            FOV = 90,
            ZoomPlayerFOV = 15,
            ZoomOutFOVSpeed = 10,
            WalkAnimationSpeedMod = 0.8f,
            AimSensitivity = 0.25f,

            DrawTime = 0.5f,
            ReloadTime = 1.8f,
            BoltBackTime = 1.6f,
            BoltBackEjectDelay = 0.5f
        };

        Primary = new ClipInfo
        {
            Ammo = 5,
            AmmoType = AmmoTypes.Sniper,
            ClipSize = 5,

            BulletSize = 4f,
            BulletType = new SniperBullet(),
            Damage = 100f,
            Force = 7f,
            HitFlinch = 5f,
            Spread = 0.75f,
            Recoil = 2f,
            RPM = 125,
            FiringType = FiringType.semi,
            ScreenShake = new ScreenShake
            {
                Length = 0.08f,
                Delay = 0.02f,
                Size = 2f,
                Rotation = 0.2f
            },

            DryFireSound = "swb_sniper.empty",
            ShootSound = "l96a1.fire",

            BulletEjectParticle = "particles/pistol_ejectbrass.vpcf",
            MuzzleFlashParticle = "particles/swb/muzzle/flash_large.vpcf",
            BulletTracerParticle = "particles/swb/tracer/tracer_large_v2.vpcf",

            InfiniteAmmo = InfiniteAmmoType.reserve
        };

        ZoomAnimData = new AngPos
        {
            Angle = new Angles(0f, 2.5f, -2f),
            Pos = new Vector3(-6f, 4f, -2f)
        };

        RunAnimData = new AngPos
        {
            Angle = new Angles(10, 40, 0),
            Pos = new Vector3(5, 0, 0)
        };

        CustomizeAnimData = new AngPos
        {
            Angle = new Angles(-2.25f, 51.84f, 0f),
            Pos = new Vector3(11.22f, -4.96f, 1.078f)
        };

        // Attachments //
        var quadRail = new QuadRail
        {
            Enabled = false,
            ViewParentBone = "sniper",
            ViewTransform = new Transform
            {
                Position = new Vector3(0f, 3.9f, 25.7f),
                Rotation = Rotation.From(new Angles(90.863f, 0f, 0f)),
                Scale = 4f
            },
            WorldParentBone = "sniper",
            WorldTransform = new Transform
            {
                Position = new Vector3(0f, 1.3f, 26.5f),
                Rotation = Rotation.From(new Angles(90.863f, 0f, 0f)),
                Scale = 4f
            }
        };

        AttachmentCategories = new List<AttachmentCategory>()
        {
            new AttachmentCategory
            {
                Name = AttachmentCategoryName.Muzzle,
                BoneOrAttachment = "muzzle",
                Attachments = new List<AttachmentBase>()
                {
                    new SniperSilencer
                    {
                        Enabled = false,
                        MuzzleFlashParticle = "particles/swb/muzzle/flash_medium_silenced.vpcf",
                        ShootSound = "swb_sniper.silenced.fire",
                        ViewParentBone = "sniper",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 4.1f, 48.7f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 90f)),
                            Scale = 15f
                        },
                        WorldParentBone = "sniper",
                        WorldTransform = new Transform {
                            Position = new Vector3(0f, 1.25f, 50f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 90f)),
                            Scale = 15f
                        },
                    }
                }
            },
            new AttachmentCategory
            {
                Name = AttachmentCategoryName.Tactical,
                BoneOrAttachment = "",
                Attachments = new List<AttachmentBase>()
                {
                    new RifleLaserRed
                    {
                        RequiresAttachmentWithName = quadRail.Name,
                        Color = Color.Red,
                        ViewParentBone = "sniper",
                        ViewTransform = new Transform {
                            Position = new Vector3(1.512f, 4f, 25.073f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                        WorldParentBone = "sniper",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.512f, 1.5f, 25.9f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                    },
                    new RifleLaserBlue
                    {
                        RequiresAttachmentWithName = quadRail.Name,
                        Color = Color.Blue,
                        ViewParentBone = "sniper",
                        ViewTransform = new Transform {
                            Position = new Vector3(1.512f, 4f, 25.073f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                        WorldParentBone = "sniper",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.512f, 1.5f, 25.9f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                    },
                    new RifleLaserGreen
                    {
                        RequiresAttachmentWithName = quadRail.Name,
                        Color = Color.Green,
                        ViewParentBone = "sniper",
                        ViewTransform = new Transform {
                            Position = new Vector3(1.512f, 4f, 25.073f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                        WorldParentBone = "sniper",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.512f, 1.5f, 25.9f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                    },
                    new RifleLaserRainbow
                    {
                        RequiresAttachmentWithName = quadRail.Name,
                        RainbowColor = true,
                        ViewParentBone = "sniper",
                        ViewTransform = new Transform {
                            Position = new Vector3(1.512f, 4f, 25.073f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                        WorldParentBone = "sniper",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.512f, 1.5f, 25.9f),
                            Rotation = Rotation.From(new Angles(90f, 0f, 0f)),
                            Scale = 4f
                        },
                    },
                }
            },
            new AttachmentCategory
            {
                Name = AttachmentCategoryName.Rail,
                Selectable = false,
                BoneOrAttachment = "",
                Attachments = new List<AttachmentBase>()
                {
                    quadRail
                }
            }
        };
    }
}
