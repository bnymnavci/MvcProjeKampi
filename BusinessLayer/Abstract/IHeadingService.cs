using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void AddHeading(Heading category);
        Heading GetById(int id);
        void DeleteHeading(Heading category);
        void UpdateHeading(Heading category);
    }
}
