namespace SQLlitleForIS_19_03.DB
{

  public class Email
  {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return $"{Title}";
        }
  }


}