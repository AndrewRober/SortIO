namespace TestProject.TestingObjects
{
    public class CustomObject : IComparable<CustomObject>
    {
        public int Id { get; }
        public int Value { get; }

        public CustomObject(int id, int value)
        {
            Id = id;
            Value = value;
        }

        public int CompareTo(CustomObject other) => Value.CompareTo(other.Value);
    }
}
