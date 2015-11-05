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
    public class InsumoParse
    {

        public const String CLASS = "Insumos";
        public const String C_ID_INS = "objectId";
        public const String C_NAME_INS = "nom_insumo";
        public const String C_PRE_INS = "costo_insumo";
        public const String C_CREATEDAT = "createdAt";
        





        public async void insertInsumo(Insumo insumo)
        {
            ParseObject parseObject = new ParseObject(CLASS);
            parseInsumo(parseObject, insumo);
            await parseObject.SaveAsync();
        }

        public async void updateInsumo(Insumo insumo)
        {
            string idinsu = insumo.IdInsumo;
            ParseQuery<ParseObject> query = ParseObject.GetQuery(CLASS);
            ParseObject parseObject = await query.GetAsync(idinsu);
            parseObject[C_NAME_INS] = insumo.NombreInsumo;
            parseObject[C_PRE_INS] = insumo.PrecioInsumo;
            await parseObject.SaveAsync();
        }



        private void parseInsumo(ParseObject parseObject, Insumo insumo)
        {
            parseObject[C_NAME_INS] = insumo.NombreInsumo;
            parseObject[C_PRE_INS] = insumo.PrecioInsumo;
        }


        public async Task<ObservableCollection<Insumo>> getAllInsumo()
        {
            ObservableCollection<Insumo> listInsumo = new ObservableCollection<Insumo>();
            ParseQuery<ParseObject> query = ParseObject.GetQuery(CLASS);
            IEnumerable<ParseObject> results = await query.FindAsync();

            ParseObject listObject;
            Insumo insumo;

            int sizeResult = results.Count();

            for (int i = 0; i < sizeResult; i++)
            {
                listObject = results.ElementAt<ParseObject>(i);

                insumo = new Insumo
                {
                    IdInsumo = listObject.ObjectId,
                    NombreInsumo = listObject.Get<string>(C_NAME_INS),
                    PrecioInsumo = listObject.Get<double>(C_PRE_INS)    
                };


                listInsumo.Add(insumo);
            }
            return listInsumo;
        }

    }
}
