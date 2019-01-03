
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace asp.net_nvc_movies.Models
{
    public class Movies
    {
        public Movies()
        {
            this.Str = new List<Star>();
            this.Dir = new List<Director>();
            this.Ganer = new List<Ganers>();
            this.Img = new Imge();
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

        public int TOP { get; set; }
        public Imge Img { get; set; }
        public string Outline { get; set; }
        [Key]
        public int Idmovie { get; set; }
        public string Title { get; set; }
        public int Idimg { get; set; }
        public string Time { get; set; }
        public int Rating { get; set; }
        public string Certificate { get; set; }

        public List<Star> Str { get; set; }
        public List<Ganers> Ganer { get; set; }
        public List<Director> Dir { get; set; }

    }

}