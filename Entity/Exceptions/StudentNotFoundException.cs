namespace Entity.Exceptions
{
    public sealed class StudentNotFoundException : NotFoundException
    {
        public StudentNotFoundException(int id)
            : base($"The Student With id:{id} could not found")
        {

        }
    }

}
