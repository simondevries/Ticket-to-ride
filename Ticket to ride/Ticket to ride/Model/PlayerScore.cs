namespace Ticket_to_ride.Model
{
    public class PlayerScore
    {
        public PlayerScore()
        {
            Score = 0;
            Message = "";
        }

        public void AddMessage(string message)
        {
            Message+= message;
        }

        public void AddScore(int score)
        {
            Score += score;
        }
 
        public int Score { get; set; }
        public string Message { get; set; }
    }
}