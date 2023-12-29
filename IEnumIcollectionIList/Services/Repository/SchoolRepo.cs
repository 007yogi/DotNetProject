using Models;
using Services.DataEntity;
using Services.Interface;

namespace Services.Repository
{
    public class SchoolRepo: ISchool
    {
        private readonly ApplicationDbContext _context;

        public SchoolRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public School SetSchoolData() 
        {
            IEnumerable<School> school_IE = _context.schools;
            ICollection<School> school_IC = _context.schools.ToList();
            //IList<School> school_IL = _context.schools.ToList();


            IEnumerable<School> Elist = _context.schools.Where(x => x.Address.Equals("Delhi") );
            Elist = Elist.Take<School>(3);

            IQueryable<School> Qlist = _context.schools.Where(x => x.Address.Equals("Delhi"));
            Qlist = Qlist.Take<School>(3);

            return school_IE.First();
        } 
    }
}
