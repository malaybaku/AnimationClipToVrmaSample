// Auto-Generated File
// Source Object: vroid_sample_a
using System.Collections.Generic;
using UnityEngine;

namespace Baxter
{
    public static class ReferenceHumanoid
    {
        public static IReadOnlyDictionary<HumanBodyBones, Pose> BoneLocalPoseMap => Values;

        private static readonly Dictionary<HumanBodyBones, Pose> Values = new()
        {
            [HumanBodyBones.Hips] = new Pose(
                new Vector3((float)2.1066051E-05, (float)0.896144331, (float)0.00661799824),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftUpperLeg] = new Pose(
                new Vector3((float)-0.0691543, (float)-0.0354265571, (float)-0.005371396),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightUpperLeg] = new Pose(
                new Vector3((float)0.0691543147, (float)-0.0354265571, (float)-0.005371399),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLowerLeg] = new Pose(
                new Vector3((float)0.0209028013, (float)-0.363107681, (float)-0.00645617349),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLowerLeg] = new Pose(
                new Vector3((float)-0.020903334, (float)-0.363107771, (float)-0.006456107),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftFoot] = new Pose(
                new Vector3((float)0.0103328936, (float)-0.4056067, (float)-0.02177025),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightFoot] = new Pose(
                new Vector3((float)-0.0103337839, (float)-0.405607, (float)-0.02177044),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.Spine] = new Pose(
                new Vector3((float)-2.67573341E-09, (float)0.0579315424, (float)0.0101128668),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.Chest] = new Pose(
                new Vector3((float)-1.26110535E-08, (float)0.11408025, (float)0.0114005171),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.Neck] = new Pose(
                new Vector3((float)5.173206E-09, (float)0.102773428, (float)-0.0299452953),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.Head] = new Pose(
                new Vector3((float)-4.18986019E-08, (float)0.0694720745, (float)0.008954108),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftShoulder] = new Pose(
                new Vector3((float)-0.0200728066, (float)0.078248024, (float)-0.02460752),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightShoulder] = new Pose(
                new Vector3((float)0.0200727824, (float)0.0782510042, (float)-0.0246074758),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftUpperArm] = new Pose(
                new Vector3((float)-0.0621720962, (float)-0.0107127428, (float)0.0038644),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightUpperArm] = new Pose(
                new Vector3((float)0.0621684268, (float)-0.0107131, (float)0.00386413932),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLowerArm] = new Pose(
                new Vector3((float)-0.239997283, (float)-0.0111750364, (float)0.0020134598),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLowerArm] = new Pose(
                new Vector3((float)0.239999443, (float)-0.0111689568, (float)0.0019104816),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftHand] = new Pose(
                new Vector3((float)-0.233359829, (float)-0.000508666039, (float)0.0192630254),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightHand] = new Pose(
                new Vector3((float)0.233353823, (float)-0.0004891157, (float)0.01929703),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftToes] = new Pose(
                new Vector3((float)-0.00192014873, (float)-0.05312383, (float)0.09754397),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightToes] = new Pose(
                new Vector3((float)0.00191964954, (float)-0.0531237125, (float)0.09754397),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftThumbProximal] = new Pose(
                new Vector3((float)-0.0016746521, (float)-0.006003499, (float)0.0156316273),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftThumbIntermediate] = new Pose(
                new Vector3((float)-0.0273039788, (float)-0.00229871273, (float)0.0293801576),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftThumbDistal] = new Pose(
                new Vector3((float)-0.0180413127, (float)-0.00128817558, (float)0.0167348385),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftIndexProximal] = new Pose(
                new Vector3((float)-0.0541668981, (float)0.004896164, (float)0.0187538527),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftIndexIntermediate] = new Pose(
                new Vector3((float)-0.0278349519, (float)-0.000106811523, (float)0.00445537642),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftIndexDistal] = new Pose(
                new Vector3((float)-0.01723051, (float)-0.000583052635, (float)0.00197479874),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftMiddleProximal] = new Pose(
                new Vector3((float)-0.05608569, (float)0.00732004642, (float)0.00404827669),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftMiddleIntermediate] = new Pose(
                new Vector3((float)-0.0313050747, (float)-0.00117385387, (float)0.00204564258),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftMiddleDistal] = new Pose(
                new Vector3((float)-0.0192452073, (float)-0.00209915638, (float)0.0007592365),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftRingProximal] = new Pose(
                new Vector3((float)-0.0566125959, (float)0.00723302364, (float)-0.009844717),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftRingIntermediate] = new Pose(
                new Vector3((float)-0.0291240215, (float)-0.0004698038, (float)5.503744E-05),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftRingDistal] = new Pose(
                new Vector3((float)-0.0167976618, (float)0.0006119013, (float)0.000165320933),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLittleProximal] = new Pose(
                new Vector3((float)-0.0537554473, (float)0.00267958641, (float)-0.023816552),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLittleIntermediate] = new Pose(
                new Vector3((float)-0.02664262, (float)-0.0002387762, (float)-6.88992441E-05),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLittleDistal] = new Pose(
                new Vector3((float)-0.0153269768, (float)0.000590920448, (float)-0.000881899148),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightThumbProximal] = new Pose(
                new Vector3((float)0.00167137384, (float)-0.00600636, (float)0.0156308338),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightThumbIntermediate] = new Pose(
                new Vector3((float)0.0272906423, (float)-0.00228726864, (float)0.0293942653),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightThumbDistal] = new Pose(
                new Vector3((float)0.0180346966, (float)-0.00128161907, (float)0.0167426318),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightIndexProximal] = new Pose(
                new Vector3((float)0.05416447, (float)0.004886508, (float)0.0187632143),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightIndexIntermediate] = new Pose(
                new Vector3((float)0.0278341174, (float)-0.000110864639, (float)0.00445996225),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightIndexDistal] = new Pose(
                new Vector3((float)0.0172302127, (float)-0.00058555603, (float)0.001977563),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightMiddleProximal] = new Pose(
                new Vector3((float)0.0560857654, (float)0.00731265545, (float)0.00405834243),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightMiddleIntermediate] = new Pose(
                new Vector3((float)0.0313049555, (float)-0.00117778778, (float)0.00205038488),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightMiddleDistal] = new Pose(
                new Vector3((float)0.0192446113, (float)-0.00210142136, (float)0.0007619038),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightRingProximal] = new Pose(
                new Vector3((float)0.056614995, (float)0.007228017, (float)-0.009834565),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightRingIntermediate] = new Pose(
                new Vector3((float)0.0291239619, (float)-0.0004733801, (float)5.967915E-05),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightRingDistal] = new Pose(
                new Vector3((float)0.0167979, (float)0.0006098747, (float)0.0001681745),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLittleProximal] = new Pose(
                new Vector3((float)0.0537593961, (float)0.00267732143, (float)-0.0238076225),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLittleIntermediate] = new Pose(
                new Vector3((float)0.0266428, (float)-0.000241756439, (float)-6.41681254E-05),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLittleDistal] = new Pose(
                new Vector3((float)0.0153268576, (float)0.000589489937, (float)-0.0008790381),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.UpperChest] = new Pose(
                new Vector3((float)6.39010977E-09, (float)0.111280918, (float)-0.0122334734),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
        };
    }
}
