using System.Collections.Generic;
using UnityEngine;

namespace Baxter
{
    public static class ReferenceHumanoid
    {
        public static IReadOnlyDictionary<HumanBodyBones, Pose> ReferenceBoneLocalPoseMap => BoneLocalPoseMap;
        
        private static readonly Dictionary<HumanBodyBones, Pose> BoneLocalPoseMap = new Dictionary<HumanBodyBones, Pose>()
        {
            [HumanBodyBones.Hips] = new Pose(
                new Vector3((float)0, (float)0.895375967, (float)0.00436774362),
                new Quaternion((float)0.06289843, (float)0, (float)0, (float)0.998019934)
            ),
            [HumanBodyBones.LeftUpperLeg] = new Pose(
                new Vector3((float)-0.06946878, (float)-0.03615541, (float)0.00123743294),
                new Quaternion((float)-0.05245477, (float)0, (float)0, (float)0.9986233)
            ),
            [HumanBodyBones.RightUpperLeg] = new Pose(
                new Vector3((float)0.06946878, (float)-0.03615541, (float)0.00123743294),
                new Quaternion((float)-0.05245477, (float)0, (float)0, (float)0.9986233)
            ),
            [HumanBodyBones.LeftLowerLeg] = new Pose(
                new Vector3((float)1.49011612E-08, (float)-0.364862382, (float)-5.77420053E-07),
                new Quaternion((float)0.02281151, (float)0, (float)0, (float)0.9997398)
            ),
            [HumanBodyBones.RightLowerLeg] = new Pose(
                new Vector3((float)-1.49011612E-08, (float)-0.364862382, (float)-5.77420053E-07),
                new Quaternion((float)0.02281151, (float)0, (float)0, (float)0.9997398)
            ),
            [HumanBodyBones.LeftFoot] = new Pose(
                new Vector3((float)0.000110670924, (float)-0.409190446, (float)0.00244377553),
                new Quaternion((float)-0.030529391, (float)0, (float)0, (float)0.9995339)
            ),
            [HumanBodyBones.RightFoot] = new Pose(
                new Vector3((float)-0.000110670924, (float)-0.409190446, (float)0.00244377553),
                new Quaternion((float)-0.030529391, (float)0, (float)0, (float)0.9995339)
            ),
            [HumanBodyBones.Spine] = new Pose(
                new Vector3((float)5.764622E-32, (float)0.05709782, (float)0.00532572158),
                new Quaternion((float)0.0127968127, (float)0, (float)0, (float)0.999918163)
            ),
            [HumanBodyBones.Chest] = new Pose(
                new Vector3((float)-1.95257E-17, (float)0.106512137, (float)-0.0127134509),
                new Quaternion((float)-0.136220947, (float)0, (float)0, (float)0.990678549)
            ),
            [HumanBodyBones.Neck] = new Pose(
                new Vector3((float)8.844927E-17, (float)0.124556974, (float)0.0069804024),
                new Quaternion((float)0.22686854, (float)0, (float)0, (float)0.9739255)
            ),
            [HumanBodyBones.Head] = new Pose(
                new Vector3((float)2.29384263E-08, (float)0.07178698, (float)0.000372026174),
                new Quaternion((float)-0.0543349423, (float)-2.20206815E-07, (float)-1.19824124E-08,
                    (float)0.998522758)
            ),
            [HumanBodyBones.LeftShoulder] = new Pose(
                new Vector3((float)-0.0201640911, (float)0.0993069857, (float)0.006152777),
                new Quaternion((float)0.167870387, (float)-0.0118837031, (float)0.06960712, (float)0.9832767)
            ),
            [HumanBodyBones.RightShoulder] = new Pose(
                new Vector3((float)0.0201640911, (float)0.0993069857, (float)0.006152777),
                new Quaternion((float)0.167870387, (float)0.0118837031, (float)-0.06960712, (float)0.9832767)
            ),
            [HumanBodyBones.LeftUpperArm] = new Pose(
                new Vector3((float)-0.06088206, (float)-5.086873E-05, (float)6.42612648E-08),
                new Quaternion((float)0, (float)-3.72528985E-09, (float)-0.070614256, (float)0.997503757)
            ),
            [HumanBodyBones.RightUpperArm] = new Pose(
                new Vector3((float)0.06088206, (float)-5.086873E-05, (float)6.42612648E-08),
                new Quaternion((float)0, (float)3.72528985E-09, (float)0.070614256, (float)0.997503757)
            ),
            [HumanBodyBones.LeftLowerArm] = new Pose(
                new Vector3((float)-0.253600717, (float)2.45141564E-07, (float)-6.962808E-09),
                new Quaternion((float)6.57646E-11, (float)-9.28997546E-10, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLowerArm] = new Pose(
                new Vector3((float)0.253600717, (float)2.45141564E-07, (float)-6.962808E-09),
                new Quaternion((float)6.57646E-11, (float)9.28997546E-10, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftHand] = new Pose(
                new Vector3((float)-0.226636559, (float)-2.23313663E-07, (float)1.44015166E-05),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightHand] = new Pose(
                new Vector3((float)0.226636559, (float)-2.23313663E-07, (float)1.44015166E-05),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftToes] = new Pose(
                new Vector3((float)0, (float)-0.0533945821, (float)0.0949369147),
                new Quaternion((float)0.002166694, (float)0, (float)0, (float)0.9999977)
            ),
            [HumanBodyBones.RightToes] = new Pose(
                new Vector3((float)0, (float)-0.0533945821, (float)0.0949369147),
                new Quaternion((float)0.002166694, (float)0, (float)0, (float)0.9999977)
            ),
            [HumanBodyBones.LeftThumbProximal] = new Pose(
                new Vector3((float)-0.00292626023, (float)-0.008359918, (float)0.0133339744),
                new Quaternion((float)0.70316565, (float)0.246799424, (float)-0.2439797, (float)0.620582)
            ),
            [HumanBodyBones.LeftThumbIntermediate] = new Pose(
                new Vector3((float)-0.0387900062, (float)0.000113679111, (float)-6.584452E-06),
                new Quaternion((float)-5.963444E-05, (float)-0.00279423571, (float)0.02235542, (float)0.9997462)
            ),
            [HumanBodyBones.LeftThumbDistal] = new Pose(
                new Vector3((float)-0.0238538887, (float)6.885161E-05, (float)-4.317247E-06),
                new Quaternion((float)0.000382486731, (float)0.008001726, (float)-0.040174637, (float)0.999160647)
            ),
            [HumanBodyBones.LeftIndexProximal] = new Pose(
                new Vector3((float)-0.0543729961, (float)0.00616454333, (float)0.0164190363),
                new Quaternion((float)1.6057756E-08, (float)-0.009704282, (float)-1.49005173E-08, (float)0.9999529)
            ),
            [HumanBodyBones.LeftIndexIntermediate] = new Pose(
                new Vector3((float)-0.0276240986, (float)7.08432824E-09, (float)-3.65220649E-06),
                new Quaternion((float)0.000137822048, (float)-0.009563294, (float)0.0144417938, (float)0.999850035)
            ),
            [HumanBodyBones.LeftIndexDistal] = new Pose(
                new Vector3((float)-0.01700817, (float)-2.86638E-06, (float)-3.8686E-06),
                new Quaternion((float)5.569016E-08, (float)0.0025898423, (float)0.00292624347, (float)0.9999924)
            ),
            [HumanBodyBones.LeftMiddleProximal] = new Pose(
                new Vector3((float)-0.0551136434, (float)0.006164664, (float)0.0017098363),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftMiddleIntermediate] = new Pose(
                new Vector3((float)-0.0307699442, (float)-1.11758709E-07, (float)-1.55996531E-08),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftMiddleDistal] = new Pose(
                new Vector3((float)-0.0189827085, (float)1.07102096E-07, (float)1.51339918E-09),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftRingProximal] = new Pose(
                new Vector3((float)-0.0544858277, (float)0.006164534, (float)-0.0113499584),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftRingIntermediate] = new Pose(
                new Vector3((float)-0.0285431147, (float)5.58793545E-09, (float)0),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftRingDistal] = new Pose(
                new Vector3((float)-0.01647222, (float)1.17346644E-07, (float)6.519258E-09),
                new Quaternion((float)-2.113115E-08, (float)-0.0114383567, (float)0.006218715, (float)0.9999153)
            ),
            [HumanBodyBones.LeftLittleProximal] = new Pose(
                new Vector3((float)-0.05073437, (float)0.006164537, (float)-0.02437002),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLittleIntermediate] = new Pose(
                new Vector3((float)-0.0261082649, (float)6.519258E-09, (float)0),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.LeftLittleDistal] = new Pose(
                new Vector3((float)-0.0150471926, (float)1.299195E-07, (float)1.86264515E-09),
                new Quaternion((float)-3.24364251E-08, (float)0.00960976351, (float)-0.00776876975,
                    (float)0.999923646)
            ),
            [HumanBodyBones.RightThumbProximal] = new Pose(
                new Vector3((float)0.00292626023, (float)-0.008359918, (float)0.0133339744),
                new Quaternion((float)0.70316565, (float)-0.246799424, (float)0.2439797, (float)0.620582)
            ),
            [HumanBodyBones.RightThumbIntermediate] = new Pose(
                new Vector3((float)0.0387900062, (float)0.000113679111, (float)-6.584452E-06),
                new Quaternion((float)-5.963444E-05, (float)0.00279423571, (float)-0.02235542, (float)0.9997462)
            ),
            [HumanBodyBones.RightThumbDistal] = new Pose(
                new Vector3((float)0.0238538887, (float)6.885161E-05, (float)-4.317247E-06),
                new Quaternion((float)0.000382486731, (float)-0.008001726, (float)0.040174637, (float)0.999160647)
            ),
            [HumanBodyBones.RightIndexProximal] = new Pose(
                new Vector3((float)0.0543729961, (float)0.00616454333, (float)0.0164190363),
                new Quaternion((float)1.6057756E-08, (float)0.009704282, (float)1.49005173E-08, (float)0.9999529)
            ),
            [HumanBodyBones.RightIndexIntermediate] = new Pose(
                new Vector3((float)0.0276240986, (float)7.08432824E-09, (float)-3.65220649E-06),
                new Quaternion((float)0.000137822048, (float)0.009563294, (float)-0.0144417938, (float)0.999850035)
            ),
            [HumanBodyBones.RightIndexDistal] = new Pose(
                new Vector3((float)0.01700817, (float)-2.86638E-06, (float)-3.8686E-06),
                new Quaternion((float)5.569016E-08, (float)-0.0025898423, (float)-0.00292624347, (float)0.9999924)
            ),
            [HumanBodyBones.RightMiddleProximal] = new Pose(
                new Vector3((float)0.0551136434, (float)0.006164664, (float)0.0017098363),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightMiddleIntermediate] = new Pose(
                new Vector3((float)0.0307699442, (float)-1.11758709E-07, (float)-1.55996531E-08),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightMiddleDistal] = new Pose(
                new Vector3((float)0.0189827085, (float)1.07102096E-07, (float)1.51339918E-09),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightRingProximal] = new Pose(
                new Vector3((float)0.0544858277, (float)0.006164534, (float)-0.0113499584),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightRingIntermediate] = new Pose(
                new Vector3((float)0.0285431147, (float)5.58793545E-09, (float)0),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightRingDistal] = new Pose(
                new Vector3((float)0.01647222, (float)1.17346644E-07, (float)6.519258E-09),
                new Quaternion((float)-2.113115E-08, (float)0.0114383567, (float)-0.006218715, (float)0.9999153)
            ),
            [HumanBodyBones.RightLittleProximal] = new Pose(
                new Vector3((float)0.05073437, (float)0.006164537, (float)-0.02437002),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLittleIntermediate] = new Pose(
                new Vector3((float)0.0261082649, (float)6.519258E-09, (float)0),
                new Quaternion((float)0, (float)0, (float)0, (float)1)
            ),
            [HumanBodyBones.RightLittleDistal] = new Pose(
                new Vector3((float)0.0150471926, (float)1.299195E-07, (float)1.86264515E-09),
                new Quaternion((float)-3.24364251E-08, (float)-0.00960976351, (float)0.00776876975,
                    (float)0.999923646)
            ),
            [HumanBodyBones.UpperChest] = new Pose(
                new Vector3((float)2.81833636E-17, (float)0.10239137, (float)-0.0013202579),
                new Quaternion((float)-0.107975617, (float)0, (float)0, (float)0.9941536)
            ),
        };
    }
}