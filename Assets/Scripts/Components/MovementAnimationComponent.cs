namespace Components
{
    public struct MovementAnimationComponent
    {
        public int VelocityXHash;
        public int VelocityZHash;

        public MovementAnimationComponent(int velocityXHash, int velocityZHash)
        {
            VelocityXHash = velocityXHash;
            VelocityZHash = velocityZHash;
        }
    }
}