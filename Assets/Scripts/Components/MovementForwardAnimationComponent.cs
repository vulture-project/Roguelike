namespace Components
{
    public struct MovementForwardAnimationComponent
    {
        public int VelocityXHash;
        public int VelocityZHash;

        public MovementForwardAnimationComponent(int velocityXHash, int velocityZHash)
        {
            VelocityXHash = velocityXHash;
            VelocityZHash = velocityZHash;
        }
    }
}