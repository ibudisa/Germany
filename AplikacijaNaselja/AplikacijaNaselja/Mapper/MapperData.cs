using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using AplikacijaNaselja.Models;

namespace AplikacijaNaselja.Mapper
{
    public class MapperData
    {

        public static NaseljaViewModel MapToView(Naselja naselja)
        {
            NaseljaViewModel model = new NaseljaViewModel();
            model.Id = naselja.Id;
            model.Naziv = naselja.Naziv;
            model.PostanskiBroj = naselja.PostanskiBroj;
            model.Drzava = naselja.Drzava;

            return model;
        }

        public static Naselja MapToDomain(NaseljaViewModel model)
        {
            Naselja data = new Naselja();
            data.Id = model.Id;
            data.Naziv = model.Naziv;
            data.PostanskiBroj = model.PostanskiBroj;
            data.Drzava = model.Drzava;

            return data;
        }

    }
}