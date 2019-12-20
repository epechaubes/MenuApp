using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public interface IAlimentsManager
    {
        List<Aliments> GetAllAliments();

        List<Aliments> GetAlimentsByCategory(int cate);
    }
}
