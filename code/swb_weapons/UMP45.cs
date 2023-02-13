﻿using System.Collections.Generic;
using Sandbox;
using SWB_Base;
using SWB_Base.Attachments;
using SWB_Base.Bullets;

namespace SWB_WEAPONS;

[Library("swb_ump45", Title = "UMP-45")]
public class UMP45 : WeaponBase
{
    public override int Bucket => 3;
    public override HoldType HoldType => HoldType.Rifle;
    public override string HandsModelPath => "weapons/swb/hands/police/v_hands_police.vmdl";
    public override string ViewModelPath => "weapons/swb/smgs/ump45/v_ump45.vmdl";
    public override string WorldModelPath => "weapons/swb/smgs/ump45/w_ump45.vmdl";
    public override string Icon => "code/swb_weapons/textures/ump45.png";

    public UMP45()
    {
        General = new WeaponInfo
        {
            FOV = 90,
            WalkAnimationSpeedMod = 1f,
            ZoomWeaponFOV = 70,

            DrawTime = 1.2f,
            ReloadTime = 1.6f,
            ReloadEmptyTime = 2.47f
        };

        Primary = new ClipInfo
        {
            Ammo = 25,
            AmmoType = AmmoTypes.SMG,
            ClipSize = 25,

            BulletSize = 2f,
            BulletType = new SMGBullet(),
            Damage = 15f,
            Force = 3f,
            HitFlinch = 1.25f,
            Spread = 0.08f,
            Recoil = 0.35f,
            RPM = 600,
            FiringType = FiringType.auto,
            ScreenShake = new ScreenShake
            {
                Length = 0.08f,
                Delay = 0.02f,
                Size = 0.5f,
                Rotation = 0.1f
            },

            DryFireSound = "swb_smg.empty",
            ShootSound = "ump45.fire",

            BulletEjectParticle = "particles/pistol_ejectbrass.vpcf",
            MuzzleFlashParticle = "particles/swb/muzzle/flash_medium.vpcf",
            BulletTracerParticle = "particles/swb/tracer/tracer_medium_v2.vpcf",

            InfiniteAmmo = InfiniteAmmoType.reserve
        };

        ZoomAnimData = new AngPos
        {
            Angle = new Angles(0.27f, -0.06f, 0f),
            Pos = new Vector3(-10.004f, -8.12f, 4.278f)
        };

        RunAnimData = new AngPos
        {
            Angle = new Angles(8.41f, 36.54f, 0f),
            Pos = new Vector3(9.937f, 0f, 1.137f)
        };

        CustomizeAnimData = new AngPos
        {
            Angle = new Angles(-3.71f, 48.72f, 0f),
            Pos = new Vector3(27.694f, -4.96f, 2.24f)
        };

        // Attachments //
        var singleRail = new SingleRail
        {
            ViewParentBone = "smg45",
            ViewTransform = new Transform
            {
                Position = new Vector3(0f, 13.6f, 7f),
                Rotation = Rotation.From(new Angles(90f, 0f, 90f)),
                Scale = 5f
            },
            WorldParentBone = "smg45",
            WorldTransform = new Transform
            {
                Position = new Vector3(0f, 6.1f, 2.4f),
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
                        ZoomPlayerFOV = 70,
                        ZoomAnimData = new AngPos {
                            Angle = new Angles(0f, 0f, 0f),
                            Pos = new Vector3(-9.973f, -8.12f, 2.197f)
                        },
                        RequiresAttachmentWithName = singleRail.Name,
                        ViewParentBone = "smg45",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 16f, 4.2f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 11f
                        },
                        WorldParentBone = "smg45",
                        WorldTransform = new Transform {
                            Position = new Vector3(0.004f, 7f, 1.725f),
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
                    new RifleSilencer
                    {
                        Enabled = false,
                        MuzzleFlashParticle = "particles/swb/muzzle/flash_medium_silenced.vpcf",
                        ShootSound = "swb_smg.silenced.fire",
                        ViewParentBone = "smg45",
                        ViewTransform = new Transform {
                            Position = new Vector3(0f, 8f, 51f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 90f)),
                            Scale = 29f
                        },
                        WorldParentBone = "smg45",
                        WorldTransform = new Transform {
                            Position = new Vector3(0f, 4f, 19.3f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, 90f)),
                            Scale = 10f
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
                        ViewParentBone = "smg45",
                        ViewTransform = new Transform {
                            Position = new Vector3(2.8f, 7.5f, 32.053f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 8f
                        },
                        WorldParentBone = "smg45",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.3f, 3.9f, 12.4f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 3f
                        },
                    },
                    new SmallLaserBlue
                    {
                        Color = Color.Blue,
                        ViewParentBone = "smg45",
                        ViewTransform = new Transform {
                            Position = new Vector3(2.8f, 7.5f, 32.053f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 8f
                        },
                        WorldParentBone = "smg45",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.3f, 3.9f, 12.4f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 3f
                        },
                    },
                    new SmallLaserGreen
                    {
                        Color = Color.Green,
                        ViewParentBone = "smg45",
                        ViewTransform = new Transform {
                            Position = new Vector3(2.8f, 7.5f, 32.053f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 8f
                        },
                        WorldParentBone = "smg45",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.3f, 3.9f, 12.4f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 3f
                        },
                    },
                    new SmallLaserRainbow
                    {
                        RainbowColor = true,
                        ViewParentBone = "smg45",
                        ViewTransform = new Transform {
                            Position = new Vector3(2.8f, 7.5f, 32.053f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 8f
                        },
                        WorldParentBone = "smg45",
                        WorldTransform = new Transform {
                            Position = new Vector3(1.3f, 3.9f, 12.4f),
                            Rotation = Rotation.From(new Angles(-90f, 0f, -90f)),
                            Scale = 3f
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
