using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    internal class CourseManager
    {
        public void Add()
        {
            //course kullanılabiliyor aynı assambyl'de olması ve internal erişim bildirgecine sahiptir.
            Course course = new Course();
        }
    }
}
