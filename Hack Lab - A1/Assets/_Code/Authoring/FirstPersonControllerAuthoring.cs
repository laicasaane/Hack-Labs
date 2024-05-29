using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace A1
{
    public class FirstPersonControllerAuthoring : MonoBehaviour
    {
        [Header("Walk")]
        public float walkForwardTopSpeed     = 5f;
        public float walkForwardAcceleration = 50f;
        public float walkForwardDeceleration = 50f;
        [Space]
        public float walkReverseTopSpeed     = 3f;
        public float walkReverseAcceleration = 30f;
        public float walkReverseDeceleration = 50f;
        [Space]
        public float walkStrafeTopSpeed     = 5f;
        public float walkStrafeAcceleration = 30f;
        public float walkStrafeDeceleration = 30f;

        [Header("Air Move")]
        public float airForwardTopSpeed     = 7f;
        public float airForwardAcceleration = 10f;
        public float airForwardDeceleration = 10f;
        [Space]
        public float airReverseTopSpeed     = 7f;
        public float airReverseAcceleration = 10f;
        public float airReverseDeceleration = 10f;
        [Space]
        public float airStrafeTopSpeed     = 7f;
        public float airStrafeAcceleration = 10f;
        public float airStrafeDeceleration = 10f;

        [Header("Collision")]
        public float capsuleRadius                         = 0.3f;
        public float capsuleHeight                         = 1.2f;
        public float skinWidth                             = 0.01f;
        public float targetHoverHeight                     = 0.5f;
        public float extraGroundCheckDistanceWhileGrounded = 0.6f;
        public float extraGroundCheckDistanceWhileInAir    = 0.1f;

        [Header("Dynamics")]
        public float springFrequency    = 10f;
        public float springDampingRatio = 1f;
        public float fallGravity        = 9.81f;
        public float maxFallSpeed       = 100f;
        public float coyoteTime         = 0.033f;
    }

    public class FirstPersonControllerAuthoringBaker : Baker<FirstPersonControllerAuthoring>
    {
        public override void Bake(FirstPersonControllerAuthoring authoring)
        {
            var entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent<FirstPersonDesiredActions>(  entity);
            AddComponent<PlayerTag>(                  entity);
            AddComponent<FirstPersonControllerState>( entity);
            AddComponent(                             entity, new FirstPersonControllerStats
            {
                walkStats = new FirstPersonControllerStats.MovementStats
                {
                    forwardTopSpeed     = authoring.walkForwardTopSpeed,
                    forwardAcceleration = authoring.walkForwardAcceleration,
                    forwardDeceleration = authoring.walkForwardDeceleration,
                    reverseTopSpeed     = authoring.walkReverseTopSpeed,
                    reverseAcceleration = authoring.walkReverseAcceleration,
                    reverseDeceleration = authoring.walkReverseDeceleration,
                    strafeTopSpeed      = authoring.walkStrafeTopSpeed,
                    strafeAcceleration  = authoring.walkStrafeAcceleration,
                    strafeDeceleration  = authoring.walkStrafeDeceleration
                },
                airStats = new FirstPersonControllerStats.MovementStats
                {
                    forwardTopSpeed     = authoring.airForwardTopSpeed,
                    forwardAcceleration = authoring.airForwardAcceleration,
                    forwardDeceleration = authoring.airForwardDeceleration,
                    reverseTopSpeed     = authoring.airReverseTopSpeed,
                    reverseAcceleration = authoring.airReverseAcceleration,
                    reverseDeceleration = authoring.airReverseDeceleration,
                    strafeTopSpeed      = authoring.airStrafeTopSpeed,
                    strafeAcceleration  = authoring.airStrafeAcceleration,
                    strafeDeceleration  = authoring.airStrafeDeceleration
                },
                capsuleRadius                         = authoring.capsuleRadius,
                capsuleHeight                         = authoring.capsuleHeight,
                skinWidth                             = authoring.skinWidth,
                targetHoverHeight                     = authoring.targetHoverHeight,
                extraGroundCheckDistanceWhileGrounded = authoring.extraGroundCheckDistanceWhileGrounded,
                extraGroundCheckDistanceWhileInAir    = authoring.extraGroundCheckDistanceWhileInAir,
                springFrequency                       = authoring.springFrequency,
                springDampingRatio                    = authoring.springDampingRatio,
                fallGravity                           = authoring.fallGravity,
                maxFallSpeed                          = authoring.maxFallSpeed,
                coyoteTime                            = authoring.coyoteTime
            });
        }
    }
}

