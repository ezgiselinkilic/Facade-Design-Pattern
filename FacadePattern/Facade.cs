using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class Facade
    {
        private ReceteOlustur _receteOlustur;
        private Taburcuİslem _taburcuİslem;
        public Facade()
        {
            _receteOlustur = new ReceteOlustur();
            _taburcuİslem = new Taburcuİslem();
        }
        public void ReceteYaz()
        {
            _receteOlustur.ReceteYaz();
        }
        public List<ReceteliHasta> ReceteYazdır()
        {
          return  _receteOlustur.ReceteListele();
        }

        public void TaburcuBilgisiVer()
        {
            _taburcuİslem.TaburcuBilgisiVer();

        }
    }
}
