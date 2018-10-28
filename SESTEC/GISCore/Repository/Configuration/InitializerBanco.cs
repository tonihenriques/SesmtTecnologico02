//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using GISModel.Entidades;

//namespace GISCore.Repository.Configuration
//{
//    public class InitializerBanco : DropCreateDatabaseIfModelChanges<GISContext>
//    {
//        protected override void Seed(GISContext context)
//        {
//            //criar alguns dados no banco

//            new List<ESDescricao>
//            {
//                new ESDescricao
//                {
//                    EsocialID = "14d57737-5611-4216-8f1d-cc120b16dbc3",
//                    Descricao ="Lesão corporal que cause morte",

//                },
//                 new ESDescricao
//                {
//                    EsocialID = "d0dc096d-2929-4a85-88ff-993779d91778",
//                    Descricao ="Pertubação funcional que cause morte",

//                }

//            }.ForEach(p => context.ESDescricao.Add(p));



//            base.Seed(context); 
//        }
//    }
//}
