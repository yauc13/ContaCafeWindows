using ContaCafe.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaCafe.Parse
{
    class TrabajadorParse
    {
        public const  String CLASS = "Trabajador";
        public const String C_ID_TRA = "objectId";
        public const String C_NAME_TRA = "nombre";
        public const String C_KLU = "klu";
        public const String C_KMA = "kma";
        public const String C_KMI = "kmi";
        public const String C_KJU = "kju";
        public const String C_KVI = "kvi";
        public const String C_KSA = "ksa";
        public const String C_KDOM = "kdom";
        public const String C_CREATEDAT = "createdAt";
        public const String C_IDSEMANA = "idsemana";





        public async void insertTrabajador(Trabajador trabajador)
        {
            ParseObject parseObject = new ParseObject(CLASS);
            parseTrabajador(parseObject, trabajador);
            await parseObject.SaveAsync();
        }

        private void parseTrabajador(ParseObject parseObject, Trabajador trabajador)
        {
            parseObject[C_NAME_TRA] = trabajador.NombreTrabajador;
            parseObject[C_KLU] = trabajador.Klu;
            parseObject[C_KMA] = trabajador.Kma;
            parseObject[C_KMI] = trabajador.Kmi;
            parseObject[C_KJU] = trabajador.Kju;
            parseObject[C_KVI] = trabajador.Kvi;
            parseObject[C_KSA] = trabajador.Ksa;
            parseObject[C_KDOM] = trabajador.Kdo;
        }

        public async void updateTrabajador(Trabajador trabajador)
        {
            string idinsu = trabajador.IdTrabajador;
            ParseQuery<ParseObject> query = ParseObject.GetQuery(CLASS);
            ParseObject parseObject = await query.GetAsync(idinsu);
            parseObject[C_NAME_TRA] = trabajador.NombreTrabajador;
            parseObject[C_KLU] = trabajador.Klu;
            parseObject[C_KMA] = trabajador.Kma;
            parseObject[C_KMI] = trabajador.Kmi;
            parseObject[C_KJU] = trabajador.Kju;
            parseObject[C_KVI] = trabajador.Kvi;
            parseObject[C_KSA] = trabajador.Ksa;
            parseObject[C_KDOM] = trabajador.Kdo;
            await parseObject.SaveAsync();
        }


        public async Task<ObservableCollection<Trabajador>> getAllTrabajador()
        {
            ObservableCollection<Trabajador> listTrabajador = new ObservableCollection<Trabajador>();
            ParseQuery<ParseObject> query = ParseObject.GetQuery(CLASS);
            IEnumerable<ParseObject> results = await query.FindAsync();

            ParseObject listObject;
            Trabajador trabajador;

            int sizeResult = results.Count();

            for (int i = 0; i < sizeResult; i++)
            {
                listObject = results.ElementAt<ParseObject>(i);

                trabajador = new Trabajador
                {
                    IdTrabajador = listObject.ObjectId,
                    NombreTrabajador = listObject.Get<string>(C_NAME_TRA),
                    Klu = listObject.Get<int>(C_KLU),
                    Kma = listObject.Get<int>(C_KMA),
                    Kmi = listObject.Get<int>(C_KMI),
                    Kju = listObject.Get<int>(C_KJU),
                    Kvi = listObject.Get<int>(C_KVI),
                    Ksa = listObject.Get<int>(C_KSA),
                    Kdo = listObject.Get<int>(C_KDOM)
                };


                listTrabajador.Add(trabajador);
            }
            return listTrabajador;
        }

    }
}
