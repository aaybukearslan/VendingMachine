using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface MachineService
    {
        void YatırılanPara(string para);
        void SecimEkranı();
        void SecimYap(string secim);
        void GirisEkran();
        void AdminPanel();
        void Sayac();
    }
}
