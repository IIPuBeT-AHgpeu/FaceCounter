namespace FaceCounter.Models
{
    public class Recognize
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public int Result { get; set; }
    }
}