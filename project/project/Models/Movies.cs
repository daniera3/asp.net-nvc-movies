
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace project.Models
{
    public class Movies
    {

        static int num = 1;
        public Movies()
        {
            Idmovie = num;
            num++;
            this.Str = new List<Star>();
            this.Dir = new List<Director>();
            this.Ganer = new List<Ganers>();
            this.Img=new Imge();
        }
        public Movies(int idmovie, string t, int idimg, string time, int rating, string Certificate, string outline)
        {
            this.Idmovie = idmovie;
            this.Title = t;
            this.Idimg = idimg;
            this.Time = time;
            this.Rating = rating;
            this.Outline = outline;
            this.Certificate = Certificate;

            this.Str = new List<Star>();
            this.Dir = new List<Director>();
            this.Ganer = new List<Ganers>();
        }
        
        

       


        [Key]
        public int Idmovie { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Length must be between 2 and 50 characters")]
        public string Title { get; set; }
        public int Idimg { get; set; }
        public Imge Img { get; set; }

        [Required]
        public string Outline { get; set; }

        [Required]
        [RegularExpression("^[0-9]{1,4}$", ErrorMessage = "Time should contain between 1 and 4 digits")]
        public string Time { get; set; }
        [Required]
        [RegularExpression("^[0-9]{1,2}$", ErrorMessage = "Time should contain between 1 and 2 digits")]
        public int Rating { get; set; }
        [Required]
        public string Certificate { get; set; }

        public List<Star> Str { get; set; }
        public List<Ganers> Ganer { get; set; }
        public List<Director> Dir { get; set; }
      

    
        public void addG(Ganers G)
        {
            G.Idmovie = Idmovie;
            Ganer.Add(G);
        }
        public void addS(Star S)
        {
            S.Idmovie = Idmovie;
            Str.Add(S);
        }
        public void addD(Director d)
        {
            d.idmovie = Idmovie;
            Dir.Add(d);
        }
    }

}