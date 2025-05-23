// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using Stride.Core.Mathematics;
using Stride.Engine;
using Stride.Input;

namespace BepuSample.Game.Components.Utils
{
    //[DataContract("SpawnerComponent", Inherited = true)]
    [ComponentCategory("BepuDemo - Utils")]
    public class ThrowerComponent : Spawner
    {
        public Entity CameraEntity { get; set; }
        public Entity? SpawnPosition { get; set; }

        public float Speed { get; set; } = 20f;

        public override void Update()
        {
            DebugText.Print("Throw a prefab (T)", new(Game.Window.PreferredWindowedSize.X - 500, 125));

            if (SpawnPosition == null) return;

            if (Input.IsKeyPressed(Keys.T))
            {
                var forward = Vector3.TransformNormal(-Vector3.UnitZ, Matrix.RotationQuaternion(CameraEntity.Transform.GetWorldRot()));

                Spawn(SpawnPosition.Transform.GetWorldPos(), (forward * Speed), new());
            }
        }
    }
}
