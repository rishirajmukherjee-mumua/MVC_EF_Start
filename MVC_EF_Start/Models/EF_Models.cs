using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_EF_Start.Models
{
   


    public class ClassMate
    {

        public int ClassMateId { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string loginhash { get; set; }
        public string symbol { get; set; }
        public List<SongGenre> SongGenres {get; set;} 
        public List<ClassMateFood> ClassMateFoods { get; set; }
        public List<ClassMateVacation> ClassMateVacations { get; set; }
        public List<IdealSaturdayClassMate> IdealSaturdayClassMates { get; set; }
    }

    public class IdealSaturday
    {
        public int IdealSaturdayId { get; set; }
        public string idealSaturday { get; set; }
        public List<IdealSaturdayClassMate> IdealSaturdayClassMates { get; set; }
    }

    public class IdealSaturdayClassMate
    {
        public int IdealSaturdayClassMateId { get; set; }
        public int ClassMateId { get; set; }
        public int IdealSaturdayId { get; set; }
    }


    public class SongGenre
    {

        public int ClassMateId { get; set; }
        public string genre { get; set; }
        public int SongGenreId { get; set; }
    }

    public class Food
    {
        public int FoodId { get; set; }
        public string food { get; set; }
        public List<ClassMateFood> ClassMateFoods { get; set; }
    }

    public class ClassMateFood
    {
        public int ClassMateId { get; set; }
        public int FoodId { get; set; }
        public int ClassMateFoodId { get; set; }
    }

    public class Vacation
    {
        public int VacationId { get; set; }
        public string vacation { get; set; }
        public List<ClassMateVacation> ClassMateVacations { get; set; }
    }

    public class ClassMateVacation
    {
        public int ClassMateVacationId { get; set; }
        public int VacationId { get; set; }
        public int ClassMateId { get; set; }
    }






}