namespace Game
{
    public static class ConvertUtils
    {
        public static UnitData FromModel(UnitModel model)
        {
            UnitData data = new UnitData
            {
                id = model.Id,
                damage = model.Damage,
                health = model.Health,
                position = model.Position,
                velocityDirection = model.VelocityDirection,
                faceDirection = model.FaceDirection,
                speed = model.Speed,
                fireRate = model.FireRate,
                projectileSpeed = model.ProjectileSpeed
            };

            return data;
        }

        public static UnitModel ToModel(UnitData data)
        {
            UnitModel model = new UnitModel
            (
                data.id,
                data.damage,
                data.health,
                data.position,
                data.velocityDirection,
                data.faceDirection,
                data.speed,
                data.fireRate,
                data.projectileSpeed
            );

            return model;
        }

        public static ProjectileData FromModel(ProjectileModel model)
        {
            ProjectileData data = new ProjectileData
            {
                damage = model.Damage,
                position = model.Position,
                direction = model.Direction,
                speed = model.Speed,
                teamId = model.TeamId,
                color = model.Color
            };

            return data;
        }

        public static ProjectileModel ToModel(ProjectileData data)
        {
            ProjectileModel model = new ProjectileModel
            (
                data.damage,
                data.position,
                data.direction,
                data.speed,
                data.teamId,
                data.color
            );

            return model;
        }
    }
}
