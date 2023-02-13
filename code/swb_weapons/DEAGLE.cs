﻿using System.Collections.Generic;
using Sandbox;
using SWB_Base;
using SWB_Base.Attachments;
using SWB_Base.Bullets;

namespace SWB_WEAPONS;

[Library("swb_deagle", Title = "Desert Eagle")]
public class DEAGLE : WeaponBase
{
    public override int Bucket => 1;
    public override HoldType HoldType => HoldType.Pistol;
    public override string HandsModelPath => "weapons/swb/hands/rebel/v_hands_rebel.vmdl";
    public override string ViewModelPath => "weapons/swb/pistols/deagle/v_deagle.vmdl";
    public override AngPos ViewModelOffset => new()
    {
        Angle = new Angles(0, -5, 0),
        Pos = new Vector3(-5, 0, 0)
    };
    public override string WorldModelPath => "weapons/swb/pistols/deagle/w_deagle.vmdl";
    public override string Icon => "code/swb_weapons/textures/deagle.png";

    public DEAGLE()
    {
        General = new WeaponInfo
        {
            FOV = 90,
            ZoomWeaponFOV = 70,

            DrawTime = 1f,
            ReloadTime = 1.8f,
            ReloadEmptyTime = 2.9f
        };

        Primary = new ClipInfo
        {
            Ammo = 7,
            AmmoType = AmmoTypes.Revolver,
            ClipSize = 7,

            BulletSize = 4f,
            BulletType = new DeagleBullet(),
            Damage = 50f,
            Force = 5f,
            HitFlinch = 3f,
            Spread = 0.06f,
            Recoil = 1f,
            RPM = 300,
            FiringType = FiringType.semi,
            ScreenShake = new ScreenShake
            {
                Length = 0.08f,
                Delay = 0.02f,
                Size = 2f,
                Rotation = 0.1f
            },

            DryFireSound = "swb_pistol.empty",
            ShootSound = "deagle.fire",

            BulletEjectParticle = "particles/pistol_ejectbrass.vpcf",
            MuzzleFlashParticle = "particles/swb/muzzle/flash_medium.vpcf",
            BulletTracerParticle = "particles/swb/tracer/tracer_medium_v2.vpcf",

            InfiniteAmmo = InfiniteAmmoType.reserve
        };

        ZoomAnimData = new AngPos
        {
            Angle = new Angles(0.25f, 4.95f, -0.4f),
            Pos = new Vector3(-5f, -2f, 2.45f)
        };

        RunAnimData = new AngPos
        {
            Angle = new Angles(-30, 0, 0),
            Pos = new Vector3(0, -3, -8)
        };

        CustomizeAnimData = new AngPos
        {
            Angle = new Angles(-19.2f, 69.6f, 0f),
            Pos = new Vector3(10.4f, -16.2f, 2.6f)
        };

        // Attachments //
        var singleRail = new SingleRail
        {
            ViewParentBone = "talon",
            ViewTransform = new Transform
            {
                Position = new Vector3(0f, 3.3f, 5f),
                Rotation = Rotation.From(new Angles(90f, 0f, 90f)),
                Scale = 1.9f
            },
            WorldParentBone = "talon",
            WorldTransform = new Transform
            {
                Position = new Vector3(1f, 5f, 5.6f),
                Rotation = Rotation.From(new Angles(90f, 0f, 90f)),
                Scale = 2f
            },
        };

        AttachmentCategories = new List<AttachmentCategory>()
        {
            new AttachmentCategory
            {
                Name = AttachmentCategoryName.Sight,
                BoneOrAttachment = "muzzle",
                Attachments = new List<AttachmentBase>()
                {
                    new ReflexSight
                    {
                        ZoomWeaponFOV = 50,
                        ZoomPlayerFOV = 70,
                        ZoomAnimData = new AngPos {
                            Angle = new Angles(-0.18f, 5.08f, 0f),
                            Pos = new Vector3(-4.946f, -5.1f, 1.417f)
                        },
                        RequiresAttachmentWithName = singleRail.Name,
                        ViewParentBone = "talon",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 4.12f, 4f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 4f
                        },
                        WorldParentBone = "talon",
                        WorldTransform = new Transform {
                            Position = new Vector3(1f, 5.828f, 4.55f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 4f
                        },
                    }
                }
            },
            new AttachmentCategory
            {
                Name = AttachmentCategoryName.Muzzle,
                BoneOrAttachment = "muzzle",
                Attachments = new List<AttachmentBase>()
                {
                    new PistolSilencer
                    {
                        MuzzleFlashParticle = "particles/swb/muzzle/flash_medium_silenced.vpcf",
                        ShootSound = "swb_heavy.silenced.fire",
                        ViewParentBone = "talon",
                        ViewTransform = new Transform
                        {
                            Position = new Vector3(0f, 2.6f, 14.8f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 90f)),
                            Scale = 9f
                        },
                        WorldParentBone = "talon",
                        WorldTransform = new Transform {
                            Position = new Vector3(1f, 4.4f, 16.5f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 0f)),
                            Scale = 9f
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
                    new SmallLaserRed
                    {
                        Color = Color.Red,
                        ViewParentBone = "talon",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 0.8f, 8.5f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                        WorldParentBone = "talon",
                        WorldTransform = new Transform {
                            Position = new Vector3(0.978f, 2.3f, 9f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                    },
                    new SmallLaserBlue
                    {
                        Color = Color.Blue,
                        ViewParentBone = "talon",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 0.8f, 8.5f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                        WorldParentBone = "talon",
                        WorldTransform = new Transform {
                            Position = new Vector3(0.978f, 2.3f, 9f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                    },
                    new SmallLaserGreen
                    {
                        Color = Color.Green,
                        ViewParentBone = "talon",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 0.8f, 8.5f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                        WorldParentBone = "talon",
                        WorldTransform = new Transform {
                            Position = new Vector3(0.978f, 2.3f, 9f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                    },
                    new SmallLaserRainbow
                    {
                        RainbowColor = true,
                        ViewParentBone = "talon",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 0.8f, 8.5f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
                        },
                        WorldParentBone = "talon",
                        WorldTransform = new Transform {
                            Position = new Vector3(0.978f, 2.3f, 9f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 180f)),
                            Scale = 5f
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
                    singleRail
                }
            }
        };
    }
}


