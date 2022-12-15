using System.ComponentModel.DataAnnotations;

namespace GIDOCS
{
    public class Games
    {
        [Key]
        public int Id { get; set; }
       
        public string Title { get; set; }

        public string Genre { get; set; }

        public string Developer { get; set; }

        public string Publisher { get; set; }

    }
}