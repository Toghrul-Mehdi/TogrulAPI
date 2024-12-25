namespace TogrulAPI.DTOs.Game
{
    public class GameStatusDto
    {
        public byte Success { get; set; }
        public byte Fail { get; set; }
        public byte Skip { get; set; }
        public Stack<Entities.Word> Words { get; set; }
        public int[] UsedWordIds { get; set; }
    }
}
