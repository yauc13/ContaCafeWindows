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
    class SemanaParse
    {
        public const string CLASS = "Semana";
        public const string C_ID_SEM = "objectId";
        public const string C_NAME_SEM = "nom_semana";
       
        public const string C_CREATEDAT = "createdAt";





        public async void insertPlaneta(Semana semana)
        {
            ParseObject parseObject = new ParseObject(CLASS);
            parseSemana(parseObject, semana);
            await parseObject.SaveAsync();
        }

        private void parseSemana(ParseObject parseObject, Semana semana)
        {
            parseObject[C_NAME_SEM] = semana.NombreSemana;
            
        }


        public async Task<ObservableCollection<Semana>> getAllSemana()
        {
            ObservableCollection<Semana> listPlaneta = new ObservableCollection<Semana>();
            ParseQuery<ParseObject> query = ParseObject.GetQuery(CLASS);
            IEnumerable<ParseObject> results = await query.FindAsync();

            ParseObject listObject;
            Semana semana;

            int sizeResult = results.Count();

            for (int i = 0; i < sizeResult; i++)
            {
                listObject = results.ElementAt<ParseObject>(i);

                semana = new Semana
                {
                    IdSemana = listObject.ObjectId,
                    NombreSemana = listObject.Get<string>(C_NAME_SEM)                 
                };


                listPlaneta.Add(semana);
            }
            return listPlaneta;
        }

    }
}
